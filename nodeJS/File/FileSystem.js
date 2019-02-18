var fs=require("fs");
const path = require('path');
var cstr="\n这是通过写入流，添加写入的";
fs.stat(path.join(__dirname,"../素材/input.txt"),function (err,stats) {
    if(err)
        return console.error(
            err
        );
    console.log(stats);
    console.log("读取文件信息成功！");
    //检测文件类型
    console.log("是否为文件类型："+stats.isFile()+"\n是否为文件夹："+stats.isDirectory()
        +"\n是否为块设备："+stats.isBlockDevice()+"\n是否为字符设备："+stats.isCharacterDevice()
        +"\n是否为软链接："+stats.isSymbolicLink()+"\n是否为先进先出（FIFO）管道："+stats.isFIFO()
        +"\n是否对象描述套接字："+stats.isSocket());
});
fs.writeFile(path.join(__dirname,"../素材/test.txt"),'我是通 过fs.writeFile 写入文件的内容',
    { 'flags': 'a' },function (err) {
    if(err)
        return console.error(err);
})
var writeStream=fs.createWriteStream(path.join(__dirname,"../素材/test.txt"),{'flags':'a'});
writeStream.write(cstr);
fs.open(path.join(__dirname,"../素材/test.txt"),"a+",function (err,fd) {
    if(err)
        return console.log(err);
    fs.writeFile(fd,"\n这是通过fs.open内的fs.writeFile添加的内容",function (err) {
        if(err)
            return console.log(err);
        console.log("数据写入成功！\n读取文件：");
        fs.readFile(path.join(__dirname,"../素材/test.txt"),function (err,data) {
            if(err)
                return console.error(err);
            console.log(data.toString());
        })
    })
});
console.log("程序结束！");