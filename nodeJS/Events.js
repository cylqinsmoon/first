//引入events模块
var events=require("events");
//创建eventEmitter对象
var eventEmitter=new events.EventEmitter();
//创建事件处理程序
var connectHandler=function connected() {
    console.log("连接成功！");
    //触发data_received事件
    //emitter.emit(eventName[, ...args])
    //     eventName <string> | <symbol>
    //
    //     ...args <any>
    //     Returns: <boolean>
    //eventEmitter.emit('data_received');
}
//绑定connection事件处理程序
//emitter.on(eventName, listener)
//     eventName <string> | <symbol> The name of the event.
//     listener <Function> The callback function
//     Returns: <EventEmitter>
eventEmitter.on('connection',connectHandler)

//使用匿名函数绑定data_received事件
eventEmitter.on('data_received',function () {
    console.log("数据接受成功！");
})
//触发connection事件
eventEmitter.emit('connection');
//触发data_received事件
eventEmitter.emit('data_received');
//自己再写一个函数并输出内容
var myEventEmitter=new events.EventEmitter();
myEventEmitter.on('mydata',function myf() {
    console.log("这是自定义函数的内容！");
});
function AnotherFun(){
    console.log(Math.pow(5,2));
}
function ThirdFun(x){
    return Math.pow(x,2);
}
myEventEmitter.on('mydata',AnotherFun);
myEventEmitter.on('mydata',function () {
    console.log(ThirdFun(5));
});
console.log("循环执行自定义函数");
myEventEmitter.emit('mydata');//可以绑定在setInterval等循环执行函数上
console.log("程序执行完毕！");
//检测事件on的数量
console.log(myEventEmitter.listenerCount("mydata"));