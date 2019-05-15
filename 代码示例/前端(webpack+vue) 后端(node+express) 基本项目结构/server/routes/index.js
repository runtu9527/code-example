const express = require('express');
const router = express.Router();
const request = require('request');
let config = require('../config/web_config');

let getOption = function (path, data) {
    let url = 'http://' + config.host + ':' + config.port + '/' + path;
    let option = {
        url: url,
        method: "POST",
        json: true,
        headers: {
            "content-type": "application/json",
        },
        body: data
    };

    return option;
};

let requestData = function (option, callback) {
    request(option, function (error, response, body) {
        let bag = {
            code: 0,
            msg: '',
            data: null
        };

        if (!error && response.statusCode == 200) {
            let result = body;
            if (result && result.ResultCode == 0) {
                bag.data = result.PointValues;
            } else {
                if (result) {
                    bag.code = result.ResultCode;
                    bag.msg = result.Msg;
                } else {
                    bag.code = 2;
                    bag.msg = '获取数据失败';
                }
            }
        } else {
            bag.code = 1;
            bag.msg = '';
        }
    }, callback(req, res, bag))
}

let json = function (req, res, data) {
    try {
        let content = JSON.stringify(data);
        res.set('content-type', 'application/json');
        res.send(content);
    } catch (e) {
        console.log(e, '请求错误')
    }
};

router.post('/data/toilet', function (req, res, next) {
    let params = {};
    // let option = getOption('/A9/v1/Device/GetDevices', params);
    console.log("接收到设备列表请求");
    let bag = {
        code: 0,
        msg: '',
        data: [
            {
                id: 1,
                classID: 0,
                serverNO: 0,
                name: '厕所1',
                desc: '厕所1 嘻嘻嘻嘻嘻',
                restData: {
                    site: [
                        {
                            name: '车位1',
                         id:1,
                            p2: {
                                index: 0,
                                value: 2,
                            },
                            p3: {
                                index: 0,
                                value: 3,
                            },
                        },
                        {
                         id:2,

                            name: '车位2',
                            p1: {
                                index: 0,
                                value: 4,
                            },
                            p2: {
                                index: 0,
                                value: 5,
                            },
                        },
                    ]
                }
            },
            {
                id: 2,
                classID: 0,
                serverNO: 0,
                name: '厕所2',
                desc: '厕所2 嘻嘻嘻嘻嘻',
                restData: {
                    site: [
                        {
                         id:3,

                            name: '车位3',
                            p1: {
                                index: 0,
                                value: 1,
                            },
                            p2: {
                                index: 0,
                                value: 2,
                            },
                            p3: {
                                index: 0,
                                value: 3,
                            },
                        },
                        {
                         id:4,

                            name: '车位4',
                            p1: {
                                index: 0,
                                value: 4,
                            },
                            p2: {
                                index: 0,
                                value: 5,
                            },
                            p3: {
                                index: 0,
                                value: 6,
                            },
                        },
                    ]
                }
            }
        ]
    };

    json(req, res, bag);
    // requestData(option,json);
});


router.get('/data/toiletinfo', function (req, res, next) {
    let params = {id:req.query.id};
    // let option = getOption('/A9/v1/Device/GetDevices', params);
    console.log(params);
    let bag = {
        code: 0,
        msg: '',
        data:{
            id:params.id,
            name: '车位1',
                         
            p2: {
                index: 0,
                value: 2,
            },
            p3: {
                index: 0,
                value: 3,
            },
        }
    };

    json(req, res, bag);
    // requestData(option,json);
});
module.exports = router;

