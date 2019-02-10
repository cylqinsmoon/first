function NDVI() {
    var Red;
    var NIR;
    this.setRed=function (thyRed) {
        Red=thyRed;
    };
    this.setNIR=function (thyNIR) {
        NIR=thyNIR;
    };
    this.setNDIVI=function () {
        const NDVI=(NIR-Red)/(NIR+Red);
        return NDVI;
    }
};
//module.exports
//module.exports 对象是由模块系统创建的。 有时这是难以接受的；许多人希望他们的模块成为某个类的实例。
// 为了实现这个，需要将期望导出的对象赋值给 module.exports。
// 注意，将期望的对象赋值给 exports 会简单地重新绑定本地 exports 变量，这可能不是期望的。
module.exports=NDVI;