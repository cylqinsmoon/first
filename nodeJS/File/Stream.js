var fs=require('fs');
const path=require('path');
var events=require('events');
var http=require('http');
var zlib=require('zlib');
var eventEmitter=new events.EventEmitter();
var add="As an asynchronous event driven JavaScript runtime, \n" +
    "Node is designed to build scalable network applications. \n"
//用来来读取input
var data='';
//用来读取output
var data2='';
//创建一个可写入的流
//fs.createWriteStream(path[, options])
//path <string> | <Buffer> | <URL>
// options <string> | <Object>
//返回: <fs.WriteStream> 详见可写流。
var writeStream=fs.createWriteStream(path.join(__dirname,"../素材/output.txt"));
//设置flags,'a' - 打开文件用于追加。如果文件不存在则创建文件。
var writeStream_2=fs.createWriteStream(path.join(__dirname,"../素材/output.txt"),{ 'flags': 'a' });
//绑定写入函数
eventEmitter.on('write',function () {
    //writable._write(chunk, encoding, callback)
//chunk <Buffer> | <string> | <any> 要写入的数据块。 会一直是 buffer，除非 decodeStrings 选项设为 false 或者流处于对象模式。
//    encoding <string> 如果 chunk 是字符串，则指定字符编码。 如果 chunk 是 Buffer 或者流处于对象模式，则无视该选项。
//    callback <Function> 当数据块被处理完成后的回调函数。
//所有可写流的实现必须提供 writable._write() 方法将数据发送到底层资源。
    writeStream.write("这是覆盖:\n"+add,'UTF8');//注：内容将被重写，即原来的内容被覆盖
    writeStream_2.write("这是添加：\n"+add,'UTF8');//设置flags侯用于添加
//标记文件末尾
    writeStream.end();
// 处理流事件 --> data, end, and error
    writeStream.on('finish', function() {
        console.log("写入完成。");
    });

    writeStream.on('error', function(err){
        console.log(err.stack);
    });
});
eventEmitter.emit('write');
//path <string> | <Buffer> | <URL>
// options <string> | <Object>
//返回: <fs.ReadStream>
//可读流的 highWaterMark 一般默认为 16 kb，但本方法返回的可读流默认为 64 kb。r
var readStream=fs.createReadStream(path.join(__dirname,"../素材/input.txt"));
//完成output的添加而不是覆盖
var readStream2=fs.createReadStream(path.join(__dirname,"../素材/output.txt"));
//设置utf-8编码
readStream2.setEncoding("utf8");
//通过管道流完成文件复制
var writeStream2=fs.createWriteStream(path.join(__dirname,"../素材/output2.txt"));
var writeStream2_2=fs.createWriteStream(path.join(__dirname,"../素材/output2.txt"),{'flags':'a'});
var connecHandlder=function connected(){
    //设置编码
//readable.setEncoding(encoding)
//encoding <string> 字符编码。
    //   返回: <this>
//为从可读流读取的数据设置字符编码。
//默认情况下没有设置字符编码，流数据返回的是 Buffer 对象。 如果设置了字符编码，则流数据返回指定编码的字符串。
    readStream.setEncoding("utf8");
// 处理流事件 --> data, end, and error
    readStream.on('data',function (chunk) {
        data+=chunk;
    });
    readStream.on('end',function () {
        console.log(data);
        http.createServer(function (request,response) {
            response.writeHead(200,{'Content-Type':'text/plain;charset=utf-8'});
            response.end(data);
        }).listen(4616);
    });
    readStream.on('error',function (err) {
        console.log(err.stack);
    });
    //处理流事件
    readStream2.on('data', chunk => data2 += chunk);
    readStream2.on('end', () => writeS(data2));
    readStream2.on("error", err => console.log(err.strck));
    //在output.txt原有内容基础上添加内容
    let writeS = dataS =>{
        var writeStream3 = fs.createWriteStream(path.join(__dirname,"../素材/output.txt"));
        //使用utf-8写入流
        writeStream3.write(dataS+"这是笨方法添加：\n"+add, "UTF8");
        //标记文件末尾
        writeStream3.end();
        //处理事件流
        writeStream3.on("finish", () => console.log("写入完成"));
        writeStream3.on("error", err => console.log(err.stack));
    }
    //管道流方式完成文件复制
    //readable.pipe(destination[, options])
    //destination <stream.Writable> 数据写入的目标。
    // options <Object> 选项。
    // 返回: <stream.Writable> 目标可写流，如果是 Duplex 流或 Transform 流则可以形成管道链。
    // 绑定可写流到可读流，将可读流自动切换到流动模式，并将可读流的所有数据推送到绑定的可写流。
    // 数据流会被自动管理，所以即使可读流更快，目标可写流也不会超负荷。
    readStream.pipe(writeStream2);
    readStream.pipe(writeStream2_2);
    //压缩input.txt文件
    //zlib.createGzip([options])
    //创建并返回一个带有给定 options 的新的 [Gzip][] 对象。
    readStream.pipe(zlib.createGzip()).pipe(fs.createWriteStream(path.join(__dirname,"../素材/input.txt.gz")));
    console.log("程序执行完毕！");
}
eventEmitter.on('connect',connecHandlder);
eventEmitter.emit('connect');