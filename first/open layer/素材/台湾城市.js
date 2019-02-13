var data=[
    {
        "name":"台北市",
        "lon":121.4868,
        "lat":25.035838,
        "Tg":"25℃"
    },
    {
        "name":"台中市",
        "lon":120.640869,
        "lat":24.186847,
        "Tg":"27℃"
    },
    {
        "name":"台南市",
        "lon":120.168457,
        "lat":22.99885,
        "Tg":"30℃"
    },
    {
        "name":"高雄市",
        "lon":120.31127,
        "lat":22.6342926,
        "Tg":"32℃"
    },
    {
        "name":"新北市",
        "lon":121.66367,
        "lat":25.1853,
        "Tg":"24℃"
    },
    {
        "name":"新竹市",
        "lon":121.2136,
        "lat":24.982757,
        "Tg":"23℃"
    },
    {
        "name":"花莲县",
        "lon":121.62966,
        "lat":23.99058,
        "Tg":"27℃"
    },

]
var apiServer = 'https://query.yahooapis.com/v1/public/yql';//使用公共的天气接口
var citiesId = [
    //WOEID 数据，来自于http://woeid.rosselliot.co.nz/lookup
    '2306179',//台北
    '2306181',
    '2306182',
    '2306180',
    '2306188',
    '2306185',
    '2296315',
    '2347336',
    '2347335',
    '28760735',
    '20070572',
    '2347340',
];
var citiesName = [
    '台北',
    '台中',
    '台南',
    '高雄',
    '基隆',
    '新竹',
    '嘉义',
    '宜兰',
    '花莲',
    '金门',
    '彰化',
    '屏东',
];
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