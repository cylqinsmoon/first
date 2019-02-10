var NDVI=require('./myModule');
const event=require("events");
const eventEmit=new event.EventEmitter();
const readline=require('readline');
const rl=readline.createInterface({
    input:process.stdin,
    output:process.stdout
});
var ndvi=new NDVI();
eventEmit.on('calculate',function () {
    rl.question('请分别输入红光、近红外波段值（空格隔开）：',function(ans){
        var taken=ans.split(' ');
        ndvi.setRed(parseFloat(taken[0]));
        ndvi.setNIR(parseFloat(taken[1]));
        console.log(ndvi.setNDIVI());
    });
    rl.on('close',function(){
        process.exit()
    })
});
eventEmit.emit('calculate');