const path = require('path');
var http=require("http");
function zs()
{
    console.log("现在开始执行阻塞的代码");
    var fs = require("fs");//文件系统
    var data = fs.readFileSync(path.join(__dirname,"素材/input.txt"));
    //fs.readFileSync(path[, options])
    //path <string> | <Buffer> | <URL> | <integer> filename or file descriptor
    // options <Object> | <string>
    //Returns: <string> | <Buffer>
    //readFile()的同步版本
    console.log(data.toString());
    console.log("程序执行结束!");
}
zs();
function fzs()
{
    console.log("现在开始执行非阻塞的代码");
    var fs = require("fs");
    fs.readFile(path.join(__dirname,"素材/input.txt"), function (err, data) {
        //fs.readFile(path[, options], callback)
        //path <string> | <Buffer> | <URL> | <integer> filename or file descriptor
        //options <Object> | <string>
        //callback <Function>
        // 异步读取整个文件的内容。
        if (err) return console.error(err);
        console.log(data.toString());
        http.createServer(function (request,response) {
            response.writeHead(200,{'Content-Type':'text/html;charset=utf-8'});
            response.end("<h1>"+data+"</h1>",'utf8');
        }).listen(4616);
    });
    console.log("程序执行结束!");
}
fzs();