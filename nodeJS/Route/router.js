function route(handle,pathname) {
    console.log("About to route a request for " + pathname);
    //首先检查给定的路径对应的请求处理程序是否存在，如果存在则直接调用相应的函数。
    if(typeof handle[pathname]==='function'){
        return handle[pathname]();
    }
    else
    {
        console.log("No request handler found for "+pathname);
        return "404 Not Found"
    }
}

exports.route = route;
