 Node.js 应用是由哪几部分组成


    1.引入 required 模块：我们可以使用 require 指令来载入 Node.js 模块。

    2.创建服务器：服务器可以监听客户端的请求，类似于 Apache 、Nginx 等 HTTP 服务器。

    3.接收请求与响应请求 服务器很容易创建，客户端可以使用浏览器或终端发送 HTTP 请求，服务器接收请求后返回响应数据。
NPM 使用
    允许用户从NPM服务器下载别人编写的第三方包到本地使用。
    允许用户从NPM服务器下载并安装别人编写的命令行程序到本地使用。
    允许用户将自己编写的包或命令行程序上传到NPM服务器供别人使用。
NPM 常用命令


    NPM提供了很多命令，例如install和publish，使用npm help可查看所有命令。

    使用npm help <command>可查看某条命令的详细帮助，例如npm help install。

    在package.json所在目录下使用npm install . -g可先在本地安装当前命令行程序，可用于发布前的本地测试。

    使用npm update <package>可以把当前目录下node_modules子目录里边的对应模块更新至最新版本。

    使用npm update <package> -g可以把全局安装的对应命令行程序更新至最新版。

    使用npm cache clear可以清空NPM本地缓存，用于对付使用相同版本号发布新版本代码的人。

    使用npm unpublish <package>@<version>可以撤销发布自己发布过的某个版本代码。
Node 自带的交互式解释器
REPL 命令

    ctrl + c - 退出当前终端。

    ctrl + c 按下两次 - 退出 Node REPL。

    ctrl + d - 退出 Node REPL.

    向上/向下 键 - 查看输入的历史命令

    tab 键 - 列出当前命令

    .help - 列出使用命令

    .break - 退出多行表达式

    .clear - 退出多行表达式

    .save filename - 保存当前的 Node REPL 会话到指定文件

    .load filename - 载入当前 Node REPL 会话的文件内容。
Node.js 回调函数
异步编程依托于回调来实现，但不能说使用了回调后程序就异步化了。
例如，我们可以一边读取文件，一边执行其他命令，在文件读取完成后，我们将文件内容作为回调函数的参数返回。这样在执行代码时就没有阻塞或等待文件 I/O 操作。这就大大提高了 Node.js 的性能，可以处理大量的并发请求。
回调函数一般作为函数的最后一个参数出现：

function foo1(name, age, callback) { }
function foo2(value, callback1, callback2) { }

File System
The fs module provides an API for interacting with the file system in a manner closely.
const fs = require('fs');
所有文件系统操作具有同步和异步形式。
eg.
异步操作：
const fs = require('fs');

fs.unlink('/tmp/hello', (err) => {  
//fs.unlink(path, callback)
//path <string> | <Buffer> | <URL>
//异步删除文件或符号链接。
callback <Function>
  if (err) throw err;
  console.log('successfully deleted /tmp/hello');
});
使用try/catch同步操作：
const fs = require('fs');

try {
  fs.unlinkSync('/tmp/hello');
    //fs.unlinkSync(path)
    //path <string> | <Buffer> | <URL>
  console.log('successfully deleted /tmp/hello');
} catch (err) {
  // handle the error
}

Node.js 事件循环
Node.js 使用事件驱动模型，当web server接收到请求，就把它关闭然后进行处理，然后去服务下一个web请求。 
当这个请求完成，它被放回处理队列，当到达队列开头，这个结果被返回给用户。
这个模型非常高效可扩展性非常强，因为webserver一直接受请求而不等待任何读写操作。（这也被称之为非阻塞式IO或者事件驱动IO）
在事件驱动模型中，会生成一个主循环来监听事件，当检测到事件时触发回调函数。

events
node. js 的大部分核心 api 都是围绕一个idiomatic asynchronous event-driven 的体系结构构建的, 在该体系结构中, 某些类型的对象 (称为 "emitters") 发出命名事件, 这些事件导致Function对象 ("emitters") 被调用。
发出事件的所有对象都是EventEmitter类的实例。这些对象公开一个eventEmitter.on()函数, 该函数允许将一个或多个函数附加到对象发出的命名事件。通常, 事件名称是以骆驼为中心的字符串, 但可以使用任何有效的 javascript 属性键。
events 模块只提供了一个对象： events.EventEmitter。EventEmitter 的核心就是事件触发与事件监听器功能的封装。

当EventEmitter对象发出事件时, 附加到该特定事件的所有函数都将同步调用。被调用的侦听器返回的任何值都将被忽略, 并将被丢弃

 大多数时候我们不会直接使用 EventEmitter，而是在对象中继承它。包括 fs、net、 http 在内的，只要是支持事件响应的核心模块都是 EventEmitter 的子类。
原因有两点：
首先，具有某个实体功能的对象实现事件符合语义， 事件的监听和发生应该是一个对象的方法。
其次 JavaScript 的对象机制是基于原型的，支持 部分多重继承，继承 EventEmitter 不会打乱对象原有的继承关系。
Buffer
JavaScript 语言自身只有字符串数据类型，没有二进制数据类型。
在处理像TCP流或文件流时，必须使用到二进制数据。
在引入 TypedArray 之前，JavaScript 没有读取或操作二进制数据流的机制。 Buffer 类用于在 TCP 流或文件系统操作等场景中处理字节流。

Node.js 目前支持的字符编码包括：

    ascii - 仅支持 7 位 ASCII 数据。如果设置去掉高位的话，这种编码是非常快的。

    utf8 - 多字节编码的 Unicode 字符。许多网页和其他文档格式都使用 UTF-8 。

    utf16le - 2 或 4 个字节，小字节序编码的 Unicode 字符。支持代理对（U+10000 至 U+10FFFF）。

    ucs2 - utf16le 的别名。

    base64 - Base64 编码。

    latin1 - 一种把 Buffer 编码成一字节编码的字符串的方式。

    binary - latin1 的别名。

    hex - 将每个字节编码为两个十六进制字符。
创建 Buffer 类

Buffer 提供了以下 API 来创建 Buffer 类：
    Buffer.alloc(size[, fill[, encoding]])： 返回一个指定大小的 Buffer 实例，如果没有设置 fill，则默认填满 0
    Buffer.allocUnsafe(size)： 返回一个指定大小的 Buffer 实例，但是它不会被初始化，所以它可能包含敏感的数据
    Buffer.allocUnsafeSlow(size)
    Buffer.from(array)： 返回一个被 array 的值初始化的新的 Buffer 实例（传入的 array 的元素只能是数字，不然就会自动被 0 覆盖）
    Buffer.from(arrayBuffer[, byteOffset[, length]])： 返回一个新建的与给定的 ArrayBuffer 共享同一内存的 Buffer。
    Buffer.from(buffer)： 复制传入的 Buffer 实例的数据，并返回一个新的 Buffer 实例
    Buffer.from(string[, encoding])： 返回一个被 string 的值初始化的新的 Buffer 实例

写入缓冲区
写入 Node 缓冲区的语法如下所示：
buf.write(string[, offset[, length]][, encoding])
参数描述如下：

    string - 写入缓冲区的字符串。

    offset - 缓冲区开始写入的索引值，默认为 0 。

    length - 写入的字节数，默认为 buffer.length

    encoding - 使用的编码。默认为 'utf8' 。

根据 encoding 的字符编码写入 string 到 buf 中的 offset 位置。 length 参数是写入的字节数。 如果 buf 没有足够的空间保存整个字符串，则只会写入 string 的一部分。 只部分解码的字符不会被写入。
返回值
返回实际写入的大小。如果 buffer 空间不足， 则只会写入部分字符串。

Buffer.compare(buf1, buf2)

    buf1 <Buffer> | <Uint8Array>
    buf2 <Buffer> | <Uint8Array>
    返回: <integer>

比较 buf1 与 buf2，主要用于 Buffer 数组的排序。 相当于调用 buf1.compare(buf2)。

buf.compare(target[, targetStart[, targetEnd[, sourceStart[, sourceEnd]]]])
arget <Buffer> | <Uint8Array> 要与 buf 对比的 Buffer 或 Uint8Array。
targetStart <integer> target 中开始对比的偏移量。默认为 0。
targetEnd <integer> target 中结束对比的偏移量（不包含）。默认为 target.length。
sourceStart <integer> buf 中开始对比的偏移量。默认为 0。
sourceEnd <integer> buf 中结束对比的偏移量（不包含）。默认为 buf.length。
返回: <integer>
对比 buf 与 target，并返回一个数值，表明 buf 在排序上是否排在 target 前面、或后面、或相同。 对比是基于各自 Buffer 实际的字节序列。

    如果 target 与 buf 相同，则返回 0。
    如果 target 排在 buf 前面，则返回 1。
    如果 target 排在 buf 后面，则返回 -1。

buf.copy(target[, targetStart[, sourceStart[, sourceEnd]]])

    target <Buffer> | <Uint8Array> 要拷贝进的 Buffer 或 Uint8Array。
    targetStart <integer> target 中开始写入的偏移量。默认为 0。
    sourceStart <integer> buf 中开始拷贝的偏移量。默认为 0。
    sourceEnd <integer> buf 中结束拷贝的偏移量（不包含）。默认为 buf.length。
    返回: <integer> 拷贝的字节数。

拷贝 buf 中某个区域的数据到 target 中的某个区域，即使 target 的内存区域与 buf 的重叠。

buf.slice([start[, end]])

    start <integer> 开始切片的偏移量。默认为 0。
    end <integer> 结束切片的偏移量（不包含）。默认为 buf.length。
    返回: <Buffer>

创建一个指向与原始 Buffer 同一内存的新 Buffer，但使用 start 和 end 进行了裁剪。

修改新建的 Buffer 切片，也会同时修改原始的 Buffer，因为两个对象所分配的内存是重叠的。(裁剪功能返回的实际是原始缓存区 buffer 或者一部分，操作的是与原始 buffer 同一块内存区域。)

Node.js Stream(流)
Stream 有四种流类型：
    Readable - 可读操作。

    Writable - 可写操作。

    Duplex - 可读可写操作.

    Transform - 操作被写入数据，然后读出结果。
所有的 Stream 对象都是 EventEmitter 的实例。常用的事件有：

    data - 当有数据可读时触发。

    end - 没有更多的数据可读时触发。

    error - 在接收和写入过程中发生错误时触发。

    finish - 所有数据已被写入到底层系统时触发。
'data' 事件

    chunk <Buffer> | <string> | <any> 数据块。 对于非对象模式的流， chunk 可以是字符串或 Buffer。 对于对象模式的流，chunk 可以是任何 JavaScript 值，除了 null。

当流将数据块传送给消费者后触发。 当调用 readable.pipe()，readable.resume() 或绑定监听器到 'data' 事件时，流会转换到流动模式。 当调用 readable.read() 且有数据块返回时，也会触发 'data' 事件。
如果使用 readable.setEncoding() 为流指定了默认的字符编码，则监听器回调传入的数据为字符串，否则传入的数据为 Buffer。

'end'事件
当流中没有数据可供消费时触发。
'end' 事件只有在数据被完全消费掉后才会触发。 要想触发该事件，可以将流转换到流动模式，或反复调用 stream.read() 直到数据被消费完。

'error' 事件
当流因底层内部出错而不能产生数据、或推送无效的数据块时触发。




