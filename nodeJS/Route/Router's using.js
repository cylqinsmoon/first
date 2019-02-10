var server=require('./server');
var router=require('./router');
var requestHanler=require('./requestHandlers');
var event=require('events');
var eventEmit=new event.EventEmitter();
//将不同的URL映射到相同的请求处理程序上是容易的：
// 只要在对象中添加一个键为“/”的属性，对应 requestHandlers.start即可
var handle={};//JSON数据格式
handle["/"]=requestHanler.f;//localhost:4616
handle["/start"]=requestHanler.start;//localhost:4616/start
handle["/upload"]=requestHanler.upload;//localhost:4616/upload
eventEmit.on('connection',function () {
    server.start(router.route,handle);
});
eventEmit.emit('connection');