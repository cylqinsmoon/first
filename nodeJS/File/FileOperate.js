var fs = require("fs");
var zlib = require('zlib');
const path=require('path');
var data="";
var data2="\nNode is similar in design to, and influenced by, " +
    "\nsystems like Ruby's Event Machine or Python's Twisted.";
//1.读取流
//创建可读流
let readStream = fs.createReadStream(path.join(__dirname,"../素材/test.txt"));
var readStream2=fs.createReadStream(path.join(__dirname,"../素材/input.txt"));
var writeStream2=fs.createWriteStream(path.join(__dirname,"../素材/test2"),{ 'flags': 'a' });//该参数让复制和写入不会覆盖原来内容
writeStream2.write(data2);
readStream2.pipe(writeStream2);

//设置utf-8编码
readStream.setEncoding("utf8");
//处理流事件
readStream.on('data', chunk => data += chunk);
readStream.on('end', () => writeS(data));
readStream.on("error", err => console.log(err.strck));
console.log("程序1执行完毕");
//在test.txt原有内容基础上添加内容
let writeS = dataS =>{
    let writeStream = fs.createWriteStream(path.join(__dirname,"../素材/test.txt"));
    //使用utf-8写入流
    writeStream.write(dataS+data2, "UTF8");
    //标记文件末尾
    writeStream.end();
    //处理事件流
    writeStream.on("finish", () => console.log("写入完成"));
    writeStream.on("error", err => console.log(err.stack));
    console.log("程序2执行完毕");
}
console.log("程序执行完毕！");