var events=require('events');
var eventEmit=new events.EventEmitter();
//Buffer.from(string[, encoding])
//string <string> 要编码的字符串。
//encoding <string> string 的字符编码。默认为 'utf8'。
const buf=Buffer.from('DX','ascii');
//Buffer.alloc(size[, fill[, encoding]])
// 返回一个指定大小的 Buffer 实例，如果没有设置 fill，则默认填满 0
// 创建一个长度为 10、且用 0x1 填充的 Buffer。
const buf2 = Buffer.alloc(10, 1);
// 创建一个长度为 10、且未初始化的 Buffer。
// 这个方法比调用 Buffer.alloc() 更快，
// 但返回的 Buffer 实例可能包含旧数据，
// 因此需要使用 fill() 或 write() 重写。
const buf3 = Buffer.allocUnsafe(10);
// 创建一个包含 [0x1, 0x2, 0x3] 的 Buffer。
const buf4 = Buffer.from([1, 2, 3]);
const len=buf3.write('abcdefghijk');
//buf.write(string[, offset[, length]][, encoding])
//string - 写入缓冲区的字符串。offset - 缓冲区开始写入的索引值，默认为 0 。
// length - 写入的字节数，默认为 buffer.length
//encoding - 使用的编码。默认为 'utf8' 。
const buf5=Buffer.alloc(40);
for (var i = 0 ; i < 26 ; i++) {
    buf5[i] = i + 97;
}
const buf6=Buffer.alloc(50).fill("-");
const json=JSON.stringify(buf2)//用于将 JavaScript 值转换为 JSON 字符串。
// 当字符串化一个 Buffer 实例时，JSON.stringify() 会隐式地调用该 toJSON()。
//编写一个JSON
var json2 = '{"name":"Google","url":"www.google.com"}';
//用于将一个 JSON 字符串转换为 JavaScript 对象。
const copy = JSON.parse(json, (key, value) => {
    return value && value.type === 'Buffer' ?
        Buffer.from(value.data,'utf8') :
        value;
});
const copy2=JSON.parse(json);
const copy3=JSON.parse(json2, (key, value) => {
    return value && value.name === 'Google' ?
        Buffer.from(value.url,'ascii') :
        value;
});
//Buffer.concat(list[, totalLength])
//     list <Buffer[]> | <Uint8Array[]> 要合并的 Buffer 数组或 Uint8Array 数组。
//     totalLength <integer> 合并后 Buffer 的总长度。
//     返回: <Buffer>
const CCT=Buffer.concat([copy,copy3]);
//为数组排序
const arr=[buf5,buf4];
//拷贝缓冲区
//将要拷贝的内容
const json2_js=JSON.parse(json2);
const buf7=Buffer.from(json2_js.url);
buf7.copy(buf6,22,4,10);
const buf6_slice=buf6.slice(22,28);
eventEmit.on('output',function () {
    //buf.toString([encoding[, start[, end]]])
    //     encoding <string> 使用的字符编码。默认为 'utf8'。
    //     start <integer> 开始解码的字节偏移量。默认为 0。
    //     end <integer> 结束解码的字节偏移量（不包含）。默认为 buf.length。
    console.log("buf："+buf);
    console.log("buf的hex编码："+buf.toString('hex'));
    console.log("buf的base64编码:"+buf.toString('base64'));
    console.log("buf4的hex编码:"+buf4.toString('hex'));
    console.log("buf3的实际占有数量："+len);
    console.log("buf5的ascii编码和分配给 buf 的字节数："+buf5.toString('ascii')+","+buf5.length);
    console.log("输出一个由buffer转换来的JSON文件："+json);
    console.log("输出JSON2文件："+json2);
    console.log("json写入到buffer:");
    console.log(copy);
    console.log("json转换为javascript值：");
    console.log(copy2);
    console.log("json2写入到buffer中:");
    console.log(copy3);
    console.log("合并后的buf：");
    console.log(CCT);
    console.log("排序数组：");
    console.log(arr.sort(Buffer.compare));
    console.log("指定位置进行copy：\n"+buf6.toString('ascii'));
    console.log("指定位置裁减buf6：\n"+buf6_slice.toString());
})
eventEmit.emit('output');
buf6_slice.write("amazon");
var eventEmit2=new events.EventEmitter();
eventEmit2.on('output',function () {
    console.log("对裁减区域重写后的buf6：\n"+buf6);
    console.log("buf6_slice变为：\n"+buf6_slice);
})
eventEmit2.emit('output');