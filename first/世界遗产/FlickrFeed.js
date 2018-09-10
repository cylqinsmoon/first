var map;
require([
"esri/map",
"esri/layers/FeatureLayer",
"esri/dijit/PopupTemplate",
"esri/dijit/HomeButton",
"esri/dijit/OverviewMap",
"esri/request",
"esri/geometry/Point",
"esri/graphic",
"esri/toolbars/navigation",
"dojo/on", "dojo/dom", "dojo/query",
"dojo/_base/array",
"dojo/domReady!"
], function (Map, FeatureLayer, PopupTemplate, HomeButton,
    OverviewMap, esriRequest, Point, Graphic,
   Navigation, on, dom, query, array) {
    var featureLayer;
    map = new Map("map", {
        basemap: "streets",
        logo: false,
        center: [109, 37],
        zoom: 4
    });
    //导航栏
    var navToolbar = new Navigation(map);
    //给按钮添加绑定事件
    query("button").on("click", function (event) {
        //获得按钮的文本信息
        var value = this.innerHTML;
        switch (value) {
            case "拉框缩小":
                navToolbar.activate(Navigation.ZOOM_OUT);
                break;
            case "拉框放大":
                navToolbar.activate(Navigation.ZOOM_IN);
                break;
            case "全图":
                navToolbar.zoomToFullExtent();
                break;
            case "漫游":
                //默认是漫游操作
                navToolbar.deactivate();
                break;
        }
    })
    //1、创建鹰眼图对象
    var overviewMapDijit = new OverviewMap({
        map: map,
        visible: true,
    }, dom.byId("view"));//指定将小部件绑定在哪个DOM元素上面
    //2、启用小部件
    overviewMapDijit.startup();
    //隐藏弹出窗口
    map.on("mouse-drag", function (evt) {
        if (map.infoWindow.isShowing) {
            var loc = map.infoWindow.getSelectedFeature().geometry;
            if (!map.extent.contains(loc)) {
                map.infoWindow.hide();
            }
        }
    });
    //为 flickr 照片创建功能集合
    var featureCollection = {
        "layerDefinition": null,
        "featureSet": {
            "features": [],
            "geometryType": "esriGeometryPoint"
        }
    };
    featureCollection.layerDefinition = {
        "geometryType": "esriGeometryPoint",
        "objectIdField": "ObjectID",
        "drawingInfo": {
            "renderer": {
                "type": "simple",
                "symbol": {
                    "type": "esriPMS",
                    "url": "images/图例.png",
                    "contentType": "image/png",
                    "width": 18,
                    "height": 18
                }
            }
        },
        "fields": [{
            "name": "ObjectID",
            "alias": "ObjectID",
            "type": "esriFieldTypeOID"
        }, {
            "name": "description",
            "alias": "Description",
            "type": "esriFieldTypeString"
        }, {
            "name": "title",
            "alias": "Title",
            "type": "esriFieldTypeString"
        }]
    };
    //定义弹出式模板
    var popupTemplate = new PopupTemplate({
        title: "{title}",
        description: "{description}"
    });
    //基于feature collection创建featurelayer
    featureLayer = new FeatureLayer(featureCollection, {
        id: 'flickrLayer',
        infoTemplate: popupTemplate
    });
    //在单击时将功能与弹出菜单关联
    featureLayer.on("click", function (evt) {
        map.infoWindow.setFeatures([evt.graphic]);
    });
    map.on("layers-add-result", function (results) {
        requestPhotos();
    });
    //将包含 flickr 照片的功能层添加到地图中
    map.addLayers([featureLayer]);
    function requestPhotos() {
        //从 flickr 获取地理标记照片
        //tags=flower&tagmode=all
        var requestHandle = esriRequest({
            url: "./jsonFlickrFeed.json",
            callbackParamName: "jsoncallback"
        });
        requestHandle.then(requestSucceeded, requestFailed);
    }
    function requestSucceeded(response, io) {
        //循环遍历项目并添加到功能层
        var features = [];
        array.forEach(response.items, function (item) {
            var attr = {};
            attr["description"] = item.description;
            attr["title"] = item.title ? item.title : "Flickr Photo";
            var geometry = new Point(item);
            var graphic = new Graphic(geometry);
            graphic.setAttributes(attr);
            features.push(graphic);
        });
        featureLayer.applyEdits(features, null, null);
    }
    function requestFailed(error) {
        console.log('failed');
    }
    //HOME按钮
    var home = new HomeButton({
        map: window.map
    }, "HomeButton");
    home.startup();
})