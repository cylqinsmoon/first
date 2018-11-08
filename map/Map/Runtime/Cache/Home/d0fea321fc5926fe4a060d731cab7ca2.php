<?php if (!defined('THINK_PATH')) exit();?><!DOCTYPE html>
<html>
<head>
	<title>天气查询</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, user-scalable=yes" />
	<!-- bootstrap -->
	<link href="http://www.forbetterquality.cn/bootstrap/css/bootstrap.min.css" rel="stylesheet">
	<!-- font awesome -->
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
	<style type="text/css">
		/*base style*/
		html,body{margin: 0px;width: 100%;padding: 0px;border: none; touch-action: pan-y;}
		.ui-loader-default{ display:none;}
		.ui-mobile-viewport{ border:none;}
		.ui-page {padding: 0; margin: 0; outline: 0;}

		/*media style*/
		@media(max-width: 576px){
			.weather-info-md{
				display: none;
			}
		}
		@media(min-width: 577px){
			
			.weather-info-sm{
				display: none;
			}

		}


		/*jumbotron部分*/
		div#QRcode table{
			margin: auto;
		}

		/*天气展示card*/
		div.each-weather-info{
			background: -moz-linear-gradient(top,white,#b9c9ff); 
			background: -webkit-linear-gradient(top,white,#b9c9ff); 
			background: -o-linear-gradient(top,white,#b9c9ff); 
			background: -ms-linear-gradient(top,white,#b9c9ff); 
			background: linear-gradient(to bottom,white,#b9c9ff); 
		}

		div#weather-info-table{
			height: 450px;
		}

		div.weather-info-time{
			padding-bottom: 10px;
		}

		div.weather-info-img img{
			height: 80px;
		}

		/*网站信息展示*/
		.fa-php{
			color: #5a69a4;
		}
		.fa-bold,.fa-yahoo{
			color: #563d7c;
		}
		.fa-react{
			color: #6fdefc;
		}
		.fa-php,.fa-bold,.fa-yahoo,.fa-react{
			font-size: 3em;
			margin: 1rem;
		}


	</style>
</head>
<body>
	<div class="row no-gutters justify-content-around">
		<!-- jumbotron 部分 -->
		<div class="col-md-12 col-lg-10 ">
			<div class="jumbotron row justify-content-around no-gutters" style="padding:32px;">
				<div class="col-md-10 col-lg-8">
					<h3>台湾省天气信息实时查询</h3>
					<hr class="my-4">
					<p>您的IP地址：<span class="badge badge-success"><?php echo ($ip); ?></span> 来自 <span class="badge badge-primary"><?php echo ($city); ?></span> </p>
				</div>
				<div class="col-md-10 col-lg-2" id="QRcode"></div>
			</div>
		</div>
		<!-- map 部分 -->
		<div class="col-md-12 col-lg-10">
		
		</div>

		<!-- 天气信息展示部分 -->
		<div class="col-10 text-center">
			<h4>天气信息</h4>
		</div>

		<!-- echarts 天气变化趋势 -->
		<div class="col-md-10 col-lg-8" id="weather-info-table"></div>
		
		<!-- 轮播天气信息 -->

		<!-- lg下可见 -->
		<div id="weather-info-lg" class="d-none d-lg-block col-lg-9 carousel slide" data-ride="carousel">
			<ol class="carousel-indicators">
				<li data-target="#weather-info-lg" data-slide-to="0" class="active"></li>
				<li data-target="#weather-info-lg" data-slide-to="1"></li>
			</ol>

			<div class="carousel-inner">

				<div class="carousel-item active">
					<div class="row no-gutters justify-content-around">
						<div class="col-4 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="1">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
						<div class="col-4 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="2">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
						<div class="col-4 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="3">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
					</div>
				</div>

				<div class="carousel-item">
					<div class="row no-gutters justify-content-around">
						<div class="col-4 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="4">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
						<div class="col-4 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="5">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
						<div class="col-4 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="6">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
					</div>
				</div>

			</div>
			<a class="carousel-control-prev" href="#weather-info-lg" role="button" data-slide="prev">
				<span class="carousel-control-prev-icon" aria-hidden="true"></span>
				<span class="sr-only">Previous</span>
			</a>
			<a class="carousel-control-next" href="#weather-info-lg" role="button" data-slide="next">
				<span class="carousel-control-next-icon" aria-hidden="true"></span>
				<span class="sr-only">Next</span>
			</a>
		</div>

		<!-- md下可见 -->
		<div id="weather-info-md" class="d-lg-none d-xl-none col-md-11 carousel slide" data-ride="carousel">
			<ol class="carousel-indicators">
				<li data-target="#weather-info-md" data-slide-to="0" class="active"></li>
				<li data-target="#weather-info-md" data-slide-to="1"></li>
				<li data-target="#weather-info-md" data-slide-to="2"></li>
				<li data-target="#weather-info-md" data-slide-to="3"></li>
				<li data-target="#weather-info-md" data-slide-to="4"></li>
				<li data-target="#weather-info-md" data-slide-to="5"></li>
			</ol>

			<div class="carousel-inner">

				<div class="carousel-item active">
					<div class="row no-gutters justify-content-around">
						<div class="col-11 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="1">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
					</div>
				</div>

				<div class="carousel-item">
					<div class="row no-gutters justify-content-around">
						<div class="col-11 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="2">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
					</div>
				</div>

				<div class="carousel-item">
					<div class="row no-gutters justify-content-around">
						<div class="col-11 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="3">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
					</div>
				</div>

				<div class="carousel-item">
					<div class="row no-gutters justify-content-around">
						<div class="col-11 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="4">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
					</div>
				</div>

				<div class="carousel-item">
					<div class="row no-gutters justify-content-around">
						<div class="col-11 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="5">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
					</div>
				</div>

				<div class="carousel-item">
					<div class="row no-gutters justify-content-around">
						<div class="col-11 card">
							<div class="card-body each-weather-info row no-gutters justify-content-center" day-index="6">
								<div class="col-10 weather-info-time"></div>
								<div class="col-5 weather-info-img"></div>
								<div class="col-5 weather-info-text row no-gutters"></div>
							</div>
						</div>
					</div>
				</div>

			</div>
			<a class="carousel-control-prev" href="#weather-info-md" role="button" data-slide="prev">
				<span class="carousel-control-prev-icon" aria-hidden="true"></span>
				<span class="sr-only">Previous</span>
			</a>
			<a class="carousel-control-next" href="#weather-info-md" role="button" data-slide="next">
				<span class="carousel-control-next-icon" aria-hidden="true"></span>
				<span class="sr-only">Next</span>
			</a>
		</div>
		<div class="col-lg-9 col-md-11 text-right"><i><small id="infoSetTime"></small></i></div>


		<!-- 网站信息展示 -->
		<div class="col-10 text-center">
			<h4>我们使用的技术</h4>
		</div>
		<hr class="my-4 col-md-12 col-lg-10">
		<div class="col-md-12 col-lg-10 text-center row justify-content-around no-gutters">
			<div class="col-md-12 col-lg-6 col-xl-3">
				<i class="fab fa-php"></i>
				<h3>PHP</h3>
				<p>ThinkPHP MVC框架</p>
			</div>

			<div class="col-md-12 col-lg-6 col-xl-3">
				<i class="fas fa-bold"></i>
				<h3>Bootstrap</h3>
				<p>响应式设计</p>
			</div>

			<div class="col-md-12 col-lg-6 col-xl-3">
				<i class="fab fa-react"></i>
				<h3>React</h3>
				<p>React前端框架</p>
			</div>

			<div class="col-md-12 col-lg-6 col-xl-3">
				<i class="fab fa-yahoo"></i>
				<h3>YQL</h3>
				<p>Yahoo 查询语言</p>
			</div>
		</div>
		<div class="col-md-12 col-lg-10 text-center">
			<div class="jumbotron" style="padding:32px;margin-bottom: 0px;">
				由 <span class="badge badge-primary">崔云磊</span> <span class="badge badge-primary">邓斯瀚</span> 编写
			</div>
		</div>
	</div>
</body>
</html>
<!-- jQuery -->
<script src="http://www.forbetterquality.cn/jquery.js"></script>
<!-- Bootstrap -->
<script src="http://www.forbetterquality.cn/bootstrap/js/bootstrap.min.js"></script>
<!-- jQuery QR code -->
<script src="https://cdn.bootcss.com/jquery.qrcode/1.0/jquery.qrcode.min.js"></script>
<script type="text/javascript">
	// 生成二维码
	$('#QRcode').qrcode({
	    render: "table",
	    width: 125,
	    height: 125,
	    text: window.location.href
	});
</script>

<!-- jQuery Mobile -->
<script src="https://cdn.bootcss.com/jquery-mobile/1.4.5/jquery.mobile.js"></script>
<script type="text/javascript">
	$(document).bind('mobileinit',function(){
        $.mobile.loadingMessage = false;
    });
    // 为bootstrap添加手指操作事件
	$(document).ready(function() {
		$(".carousel").swiperight(function() {
			$(this).carousel('prev');
		});
		$(".carousel").swipeleft(function() {
			$(this).carousel('next');
		});
	});
</script>

<!-- echarts -->
<script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/echarts.min.js"></script>
<script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts-gl/echarts-gl.min.js"></script>
<script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts-stat/ecStat.min.js"></script>
<script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/extension/dataTool.min.js"></script>
<script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/map/js/china.js"></script>
<script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/map/js/world.js"></script>
<script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/extension/bmap.min.js"></script>
<script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/simplex.js"></script>

<script type="text/javascript">
	// 生成台北天气信息
	var woeId=2306179;
	setWeatherInfo(woeId);


	function setWeatherInfo(woeId){
		var queryString = 'select * from weather.forecast where woeid='+ woeId +' and u="c"';
		$.ajax({
			url:'https://query.yahooapis.com/v1/public/yql',
			data:{
				format:'json',
				q:queryString
			},
			success:function(data){
				console.log(data);
				// 生成echarts表
				setWeatherTable(data);
				// 生成时间
				$("small#infoSetTime").html("————更新时间 "+data.query.created);
				for(var i=1;i<data.query.results.channel.item.forecast.length;i++){			
					$("div.each-weather-info").each(function(){
						if ($(this).attr("day-index")==i) {
							$(this).find("div.weather-info-time").html(data.query.results.channel.item.forecast[i].date+" <strong class='badge badge-info'>"+data.query.results.channel.item.forecast[i].day+" </strong>");
							$(this).find("div.weather-info-img").html("<center><img src='"+getWeatherImgUrl(data.query.results.channel.item.forecast[i].code)+"'></center>");
							$(this).find("div.weather-info-text").html(getWeatherText(data.query.results.channel.item.forecast[i]));
						}
					});
				}
			}
		});
	}
	function getWeatherImgUrl(code){
		// 获取天气图片
		var weatherImgURL='http://forbetterquality.cn/img/weather/';
		switch(code){
			case '0':
				weatherImgURL=weatherImgURL+'Weather NA.png';break;
			case '1':
				weatherImgURL=weatherImgURL+'Thunderstorms.png';break;
			case '2':
				weatherImgURL=weatherImgURL+'Windy.png';break;
			case '3':
				weatherImgURL=weatherImgURL+'Thunders.png';break;
			case '4':
				weatherImgURL=weatherImgURL+'Thunderstorms.png';break;
			case '5':
				weatherImgURL=weatherImgURL+'Icy Snow.png';break;
			case '6':
				weatherImgURL=weatherImgURL+'Icy Snow.png';break;
			case '7':
				weatherImgURL=weatherImgURL+'Icy Snow.png';break;
			case '8':
				weatherImgURL=weatherImgURL+'Light Rain.png';break;
			case '9':
				weatherImgURL=weatherImgURL+'Light Rain.png';break;
			case '10':
				weatherImgURL=weatherImgURL+'Icy.png';break;
			case '11':
				weatherImgURL=weatherImgURL+'Rain.png';break;
			case '12':
				weatherImgURL=weatherImgURL+'Heavy Rain.png';break;
			case '13':
				weatherImgURL=weatherImgURL+'Few Flurries.png';break;
			case '14':
				weatherImgURL=weatherImgURL+'Wet Flurries.png';break;
			case '15':
				weatherImgURL=weatherImgURL+'Windy Snow.png';break;
			case '16':
				weatherImgURL=weatherImgURL+'Snow.png';break;
			case '17':
				weatherImgURL=weatherImgURL+'Weather NA.png';break;
			case '18':
				weatherImgURL=weatherImgURL+'Icy Snow.png';break;
			case '19':
				weatherImgURL=weatherImgURL+'Dust.png';break;
			case '20':
				weatherImgURL=weatherImgURL+'Fog.png';break;
			case '21':
				weatherImgURL=weatherImgURL+'Haze.png';break;
			case '22':
				weatherImgURL=weatherImgURL+'Smoke.png';break;
			case '23':
				weatherImgURL=weatherImgURL+'Thunderstorms.png';break;
			case '24':
				weatherImgURL=weatherImgURL+'Windy.png';break;
			case '25':
				weatherImgURL=weatherImgURL+'Frigid.png';break;
			case '26':
				weatherImgURL=weatherImgURL+'Cloudy.png';break;
			case '27':
				weatherImgURL=weatherImgURL+'Cloudy Night.png';break;
			case '28':
				weatherImgURL=weatherImgURL+'Cloudy.png';break;
			case '29':
				weatherImgURL=weatherImgURL+'Night Few Clouds.png';break;
			case '30':
				weatherImgURL=weatherImgURL+'Mostly Sunny.png';break;
			case '31':
				weatherImgURL=weatherImgURL+'Moon.png';break;
			case '32':
				weatherImgURL=weatherImgURL+'Sunny.png';break;
			case '33':
				weatherImgURL=weatherImgURL+'Night Few Clouds.png';break;
			case '34':
				weatherImgURL=weatherImgURL+'Sun.png';break;
			case '35':
				weatherImgURL=weatherImgURL+'Icy Snow.png';break;
			case '36':
				weatherImgURL=weatherImgURL+'Hot.png';break;
			case '37':
				weatherImgURL=weatherImgURL+'Thunders.png';break;
			case '38':
				weatherImgURL=weatherImgURL+'Thunderstorms.png';break;
			case '39':
				weatherImgURL=weatherImgURL+'Thunderstorms.png';break;
			case '40':
				weatherImgURL=weatherImgURL+'Rain.png';break;
			case' 41':
				weatherImgURL=weatherImgURL+'Snow.png';break;
			case '42':
				weatherImgURL=weatherImgURL+'Few Flurries.png';break;
			case '43':
				weatherImgURL=weatherImgURL+'Snow.png';break;
			case '44':
				weatherImgURL=weatherImgURL+'Cloudy.png';break;
			case '45':
				weatherImgURL=weatherImgURL+'Thunderstorms.png';break;
			case '46':
				weatherImgURL=weatherImgURL+'Rain.png';break;
			case '47':
				weatherImgURL=weatherImgURL+'Thunderstorms.png';break;
			case '48':
				weatherImgURL=weatherImgURL+'Weather NA.png';break;
		}
		return weatherImgURL;
	}
	function getWeatherText(eachDayForecast){
		var weatherCode=[
			'龙卷风',//0 tornado
			'热带风暴',//1 tropical storm
			'飓风',//2 hurricane
			'次剧烈雷雨',//3 severe thunderstorms
			'雷雨',//4 thunderstorms
			'雨夹雪',//5 mixed rain and snow
			'雨夹雪',//6 mixed rain and sleet
			'雨夹雪',//7 mixed snow and sleet
			'毛毛雨',//8 freezing drizzle
			'小雨',//9 drizzle
			'冻雨',//10 freezing rain
			'小阵雨',//11 showers
			'大阵雨',//12 showers
			'小雪花',//13 snow flurries
			'小雪阵雨',//14 light snow showers
			'风雪天',//15 blowing snow
			'雪',//16 snow
			'冰雹',//17 hail
			'雨夹雪',//18 sleet
			'灰尘',//19 dust
			'雾',//20 foggy
			'霾',//21 haze
			'烟',//22 smoky
			'风暴',//23 blustery
			'多风',//24 windy
			'冷',//25 cold
			'多云',//26 cloudy
			'多云',//27 mostly cloudy (night)
			'多云',//28 mostly cloudy (day)
			'多云转晴',//29 partly cloudy (night)
			'多云转晴',//30 partly cloudy (day)
			'晴',//31 clear (night)
			'晴',//32 sunny
			'少云',//33 fair (night)
			'少云',//34 fair (day)
			'混合雨和冰雹',//35 mixed rain and hail
			'炎热',//36 hot
			'零星雷暴',//37 isolated thunderstorms
			'零星雷阵雨',//38 scattered thunderstorms
			'零星雷阵雨',//39 scattered thunderstorms
			'零星阵雨',//40 scattered showers
			'大雪',//41 heavy snow
			'分散的阵雪',//42 scattered snow showers
			'大雪',//43 heavy snow
			'部分多云',//44 partly cloudy
			'雷阵雨',//45 thundershowers
			'阵雪',//46 snow showers
			'零星雷阵雨',//47 isolated thundershowers
			'无法获取',//48 3200 not available
		];
		if (eachDayForecast.code==3200) {
			eachDayForecast.code=48;
		}
		var title=weatherCode[eachDayForecast.code];
		var highTemp=eachDayForecast.high+" ℃";
		var lowTemp=eachDayForecast.low+" ℃";
		var code=
			"<div class='col-12'>"+title+"</div>"+
			"<div class='col-12'>"+lowTemp+" ~ "+highTemp+"</div>";
		return code;
	}
	function setWeatherTable(allInfo){
		$("div#weather-info-table").empty();
		var dom = document.getElementById("weather-info-table");
		var myChart = echarts.init(dom);
		var app = {};
		option = null;
		option = {
		    title: {
		        text: '最近七天天气状况',
		        subtext: allInfo.query.results.channel.location.city,
		    },
		    tooltip: {
		        trigger: 'axis'
		    },
		    legend: {
		        data:['最高气温','最低气温']
		    },
		    toolbox: {
		        show: false,
		        feature: {
		            dataZoom: {
		                yAxisIndex: 'none'
		            },
		            dataView: {readOnly: false},
		            magicType: {type: ['line', 'bar']},
		            restore: {},
		            saveAsImage: {}
		        }
		    },
		    xAxis:  {
		        type: 'category',
		        boundaryGap: false,
		        data: [
		        	allInfo.query.results.channel.item.forecast[0].date,
		        	allInfo.query.results.channel.item.forecast[1].date,
		        	allInfo.query.results.channel.item.forecast[2].date,
		        	allInfo.query.results.channel.item.forecast[3].date,
		        	allInfo.query.results.channel.item.forecast[4].date,
		        	allInfo.query.results.channel.item.forecast[5].date,
		        	allInfo.query.results.channel.item.forecast[6].date
	        	]
		    },
		    yAxis: {
		        type: 'value',
		        axisLabel: {
		            formatter: '{value} °C'
		        }
		    },
		    series: [
		        {
		            name:'最高气温',
		            type:'line',
		            data:[
		            	allInfo.query.results.channel.item.forecast[0].high,
			        	allInfo.query.results.channel.item.forecast[1].high,
			        	allInfo.query.results.channel.item.forecast[2].high,
			        	allInfo.query.results.channel.item.forecast[3].high,
			        	allInfo.query.results.channel.item.forecast[4].high,
			        	allInfo.query.results.channel.item.forecast[5].high,
			        	allInfo.query.results.channel.item.forecast[6].high
		            ],
		            markPoint: {
		                data: [
		                    {type: 'max', name: '最大值'},
		                    {type: 'min', name: '最小值'}
		                ]
		            },
		            markLine: {
		                data: [
		                    {type: 'average', name: '平均值'}
		                ]
		            }
		        },
		        {
		            name:'最低气温',
		            type:'line',
		            data:[
		            	allInfo.query.results.channel.item.forecast[0].low,
			        	allInfo.query.results.channel.item.forecast[1].low,
			        	allInfo.query.results.channel.item.forecast[2].low,
			        	allInfo.query.results.channel.item.forecast[3].low,
			        	allInfo.query.results.channel.item.forecast[4].low,
			        	allInfo.query.results.channel.item.forecast[5].low,
			        	allInfo.query.results.channel.item.forecast[6].low
		            ],
		            markPoint: {
		                data: [
		                    {name: '周最低', value: -2, xAxis: 1, yAxis: -1.5}
		                ]
		            },
		            markLine: {
		                data: [
		                    {type: 'average', name: '平均值'},
		                    [{
		                        symbol: 'none',
		                        x: '90%',
		                        yAxis: 'max'
		                    }, {
		                        symbol: 'circle',
		                        label: {
		                            normal: {
		                                position: 'start',
		                                formatter: '最大值'
		                            }
		                        },
		                        type: 'max',
		                        name: '最高点'
		                    }]
		                ]
		            }
		        }
		    ]
		};
		;
		if (option && typeof option === "object") {
		    myChart.setOption(option, true);
		}
	}

</script>