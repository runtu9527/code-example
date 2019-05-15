<template>
  <div id="container" v-cloak>
    <div class="device">
      <ul>
        <li
          v-for="(item, index) in list"
          :key="index"
          :class="{active:item==current}"
          @click="onClick(item)"
        >{{item.name}}</li>
      </ul>
    </div>
    <div class="points">
      <table
        cellspacing="0"
        cellpadding="0"
        v-if="current && current.restData && current.restData.site"
      >
        <thead>
          <tr>
            <th>名称</th>
            <th>属性1</th>
            <th>属性2</th>
            <th>属性3</th>
            <th>操作</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in current.restData.site" :key="index">
            <td>{{item.name?item.name:""}}</td>
            <td>{{item.p1?item.p1.value:""}}</td>
            <td>{{item.p2?item.p2.value:""}}</td>
            <td>{{item.p3?item.p3.value:""}}</td>
            <td>
              <div>
                <router-link :to="{name:'toiletinfo',query:{id:item.id}}">xxx</router-link>
                <!-- <a href="#" @click="ontoiletInfoClick(item)"
                >查看详情</a> -->
                <a href="#">修改</a>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
var refreshTimeSpan = 10 * 1000;
var net = {
  getPostOption: function() {
    var option = {
      type: "POST",
      url: "/",
      data: "",
      async: true,
      success: null,
      complete: null
    };
    return option;
  },
  doPost: function(path, params, callback) {
    var option = this.getPostOption();
    option.url = path;
    option.data = params;
    option.success = function(data) {
      var objData = null;
      var result = "";
      if (data && data.code == 0) {
        objData = data.data;
      } else {
        result = "请求失败";
        if (data && data.msg) {
          result = data.msg;
        }
      }
      callback(result, objData);
    };
    option.complete = function(XMLHttpRequest, status) {
      if (status == "timeout") {
        //超时
        console.log("请求[" + path + "] 结果 ：超时");
        callback("请求数据超时", null);
      }

      if (status == "error") {
        //出错
        console.log("请求[" + path + "] 结果 ：超时");
        callback("请求数据出错", null);
      }
    };
    $.ajax(option);
  }
};

export default {
  name: "device",
  data() {
    return {
      refreshTimer:true,
      count: 0,
      list: [],
      current: null
    };
  },

  // mounted: function () {
  //   this.startRefresh()
  // },

  created: function() {
    console.log('created');
    this.refreshTimer=true;
    this.startRefresh();
  },

  destroyed:function(){
    console.log('destroyed');
    this.refreshTimer=false;
  },

  methods: {
    ontoiletInfoClick: function(item) {
      if (!item) {
        return;
      }

    },

    onClick: function(item) {
      if (!item) {
        return;
      }

      if (item == this.current) {
        return;
      }

      this.current = item;
    },
    getToilets: function(cb) {
      net.doPost("/data/toilet", {}, function(err, data) {
        cb(err, data);
      });
    },
    startRefresh: function() {
      var that = this;
      that.doRefresh(function() {
        if(that.refreshTimer){
 that.timer = setTimeout(function() {
          that.startRefresh();
        }, refreshTimeSpan);
        }
       
      });
    },
    doRefresh: function(cb) {
      var that = this;
      that.getToilets(function(err, data) {
        // console.log(err);
        // console.log(data);
        that.count++;
        that.list = data || [];
        if (that.current) {
          var item = that.list.find(function(p) {
            return p.id == that.current.id;
          });
          if (item) {
            that.current = item;
          } else {
            that.current = null;
          }
        }
        cb && cb();
      });
    }
  }
};
</script>

<style>
[v-cloak] {
  display: none;
}

#container {
  position: relative;
  width: 100%;
  height: 100%;
}

.device {
  position: absolute;
  width: 200px;
  height: 100%;
  left: 0;
  top: 0;
  /* border-right: 2px solid gray; */
  overflow-x: hidden;
  overflow-y: auto;
}

.device ul {
  position: relative;
  width: 100%;
  height: auto;
  padding: 0;
  margin: 0;
}

.device ul li {
  position: relative;
  height: 50px;
  border-bottom: 1px solid lightgray;
  line-height: 50px;
  text-indent: 15px;
  cursor: pointer;
}

.device ul li.active {
  background-color: #6693b2;
  color: white;
}
.device ul li:hover {
  background-color: #6693b2;
  opacity: 0.5;
  color: white;
}
.points {
  position: absolute;
  left: 200px;
  height: 100%;
  top: 0;
  right: 0;
  bottom: 0;
  border-left: 2px solid gray;
  overflow-x: hidden;
  overflow-y: auto;
}

.points table {
  position: relative;
  width: 100%;
  height: auto;
  border: none;
}

.points table thead tr th {
  font-weight: normal;
  background-color: #6693b2;
  color: white;
}

.points table thead tr th,
.points table tbody tr td {
  width: 10%;
  height: 50px;
  text-align: center;
  border: 1px solid lightgray;
}

button {
  width: 60px;
  height: 36px;
}
</style>