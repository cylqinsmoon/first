var http=require("http");
var url=require("url")
function start(route,handle) {
function onRequest(request,response) {
    //url.parse(urlString[, parseQueryString[, slashesDenoteHost]])
    //urlString <string> 要解析的 URL 字符串。
    //parseQueryString <boolean> 如果设为 true，则返回的 URL 对象的 query 属性会是一个使用 querystring 模块的
    // parse() 生成的对象。 如果设为 false，则 query 会是一个未解析未解码的字符串。 默认为 false。
    //slashesDenoteHost <boolean> 如果设为 true，则 // 之后至下一个 / 之前的字符串会解析作为 host。
    // 例如，//foo/bar 会解析为 {host: 'foo', pathname: '/bar'} 而不是 {pathname: '//foo/bar'}。 默认为 false。
    var pathname=url.parse(request.url).pathname;//浏览器请求的 URL 路径
    route(handle,pathname);
    console.log("Request for " + pathname + " received.");
    response.writeHead(200,{"Content-Type":"text/plain;charset=utf-8"});
    var content=route(handle,pathname);
    response.write(content);
    response.end();
}
    http.createServer(onRequest).listen(4616);
    console.log("Server has started.");
}
exports.start=start;
