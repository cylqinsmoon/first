var util=require('util');
//Base 有三个在构造函数内定义的属性
function Base() {
    this.red='红光波段';
    this.nir='近红外波段';
    this.ndvi=function () {
        console.log("归一化植被指数=（"+this.red+"+"+this.nir+"）/（"+this.red+"－"+this.nir+"）");
    }
}
//一个原型中定义的函数
Base.prototype.showResult=function () {
    console.log(this.red+"\n"+this.nir);
};
function Sub() {
    this.red="红光波段（620～760纳米）";
    this.nir="近红外波段（780～2526纳米）";
};
util.inherits(Sub,Base);
var objBase=new Base();
objBase.showResult();
objBase.ndvi();
console.log(util.inspect(objBase,true));
var objSub=new Sub();
objSub.showResult();
//Sub 仅仅继承了Base 在原型中定义的函数，而构造函数内部创造的属性和函数都没有被Sub 继承。
//objSub.ndvi();
console.log(util.inspect(objSub,true));