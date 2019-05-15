<template>
  <div class="toiletinfo">
    <h4>蹲位详情</h4>
    <p>{{id}}</p>
    <p>{{name}}</p>
  </div>
</template>

<script>
export default {
  name: "toiletinfo",
  data() {
    return {
      toiletData: null
    };
  },

  computed: {
    id() {
      return this.$route.query.id;
    },
    name() {
      if (this.toiletData) {
        return this.toiletData.name;
      } else {
        return "";
      }
    }
  },
  created: function() {
    var that = this;
    // console.log("creat toiletdata");
    $.get("/data/toiletinfo", { id: that.id }, function(data) {
      // console.log(data.data);
      that.toiletData = data.data;
    });
  }
};
</script>
