var date = new Date();
var year = date.getFullYear();
var month = date.getMonth() + 1;
var day = date.getDate();
var hour = date.getHours();
var minute = date.getMinutes();
var second = date.getSeconds();
var x=0;
function printDate()
{
    console.log(year + '年' + month + '月' + day + '日 ' + hour + ':' + minute + ':' + second);
}
//time和timeout需要相同的label
console.time("获取耗时");
console.log(__filename);
console.log(__dirname);
console.trace();
console.log('出生年份：%d，出生月份：%d',1996,6);
console.log("当前进程信息：");
console.log("进程所在路径："+process.execPath+"\n平台："+process.platform+"\nCPU架构："+
    process.arch+"\nNode版本："+process.version);
process.stdout.write("内存使用情况：");
console.log(process.memoryUsage());
//延时执行函数
setTimeout(printDate,1000);
console.timeEnd("获取耗时");
process.on('exit',function (code) {
    x++;
    setInterval(()=>{
        x++;
        console.log("此处会运行吗？")
    })
    console.log("x的值：%d",x);
    console.log("退出码为：",code);
})