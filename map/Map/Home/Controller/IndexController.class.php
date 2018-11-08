<?php
namespace Home\Controller;
use Think\Controller;
class IndexController extends Controller {

	/*
	* 检测IP
	*/
	private function getIp(){
		
	    //判断服务器是否允许$_SERVER
	    if(isset($_SERVER)){    
	        if(isset($_SERVER["HTTP_X_FORWARDED_FOR"])){
	            $realip = $_SERVER["HTTP_X_FORWARDED_FOR"];
	        }elseif(isset($_SERVER["HTTP_CLIENT_IP"])) {
	            $realip = $_SERVER["HTTP_CLIENT_IP"];
	        }else{
	            $realip = $_SERVER["REMOTE_ADDR"];
	        }
	    }else{
	        //不允许就使用getenv获取  
	        if(getenv("HTTP_X_FORWARDED_FOR")){
	              $realip = getenv( "HTTP_X_FORWARDED_FOR");
	        }elseif(getenv("HTTP_CLIENT_IP")) {
	              $realip = getenv("HTTP_CLIENT_IP");
	        }else{
	              $realip = getenv("REMOTE_ADDR");
	        }
	    }
		return $realip;
	}
	/*
	*获取位置
	*/
 	private function where(){
 		$ip=$this->getIp();
    	$city=null;
    	try {
    		$content = file_get_contents("http://api.map.baidu.com/location/ip?ak=W59G6va2oYeubmAnKKmLn0ztqGRP9QQ3&ip={$ip}&coor=bd09ll");
    		$jsonData = json_decode($content,true);
    		$city=$jsonData['content']['address']?$jsonData['content']['address']:"未知地点";  
    	} catch (Exception $e){
    		$city="未知地点";
    	}
    	if ($city==null) {
    		$city="未知地点";
    	}
    	return $city;    	
    }


    public function index(){
       
        $userCity=$this->where();
        $this->assign("city",$userCity);

        $userIp=$this->getIp();
        $this->assign("ip",$userIp);


     	$this->display();
    }

    public function get(){

    	// $allData=array();

    	// for($i=100000;$i<200000;$i++){
    	// 	$url="https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid=".$i."%20and%20u=%27c%27&format=json";
    	// 	$content=file_get_contents($url);
    	// 	$data=json_decode($content,true);
    		
    	// 	if ($data['query']['results']['channel']['location']['country']=="China") {
    	// 		$allData[]=$data['query']['results']['channel']['location']['city'];
    	// 	}
    	// }
    	// dump($allData);
		
    	

    	
    }
}