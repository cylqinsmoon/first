function f() {
    console.log("Request handler 'f' was called.");
    return "这是localhost:"
}
function start() {
    console.log("Request handler 'start' was called.");
    function sleep(millSeconds) {
        var startTime=new Date().getTime();
        while (new Date().getTime()<startTime+millSeconds) ;
    }
    sleep(1000)
    return "这是localhost:/start"
}
function upload() {
    console.log("Request handler 'upload' was called.");
    return "这是localhost:/upload"
}
exports.f=f;
exports.start=start;
exports.upload=upload;