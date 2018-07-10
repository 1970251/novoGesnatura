(function (window, google, mapster, position) {

    //map options
    mapster.MAP_OPTIONS = {
        center: position,
        zoom: 5
        

    },
        element = document.getElementById('map-canvas'),
        //map
        map = new google.maps.Map(element, options);

}(window, google, window.Mapster || (window.Mapster = {})))
