//引入require模块，将实例化的HTTP赋值给变量http
var http=require("http");
var time=new Date().toLocaleTimeString();
var date=new Date().toLocaleDateString();
var express = require('express');
//创建服务器
//http.createServer方法创建服务器
http.createServer(function (request,response) { //函数通过request,response参数来接收和响应数据
    //发送HTTP头部
    //HTTP状态值：200：OK
    //内容类型：text/html
    response.writeHead(200, {'Content-Type': 'text/html'});
    //发送响应数据“Hello World”
    response.write('<h1>Hello World</h1>');
    response.write("<p>"+time+"</p>");
    response.write("<p>"+express+"</p>")
    response.end(date);
}).listen(8888);//挂载到8888端口
//在终端打印如下信息
console.log('服务在8888端口')