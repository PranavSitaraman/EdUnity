var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
function getLocation(netObject) {
    function returnPosition(position) {
        return __awaiter(this, void 0, void 0, function* () {
            yield netObject.invokeMethodAsync('SetLocation', position.coords.latitude, position.coords.longitude);
        });
    }
    function positionError(error) { }
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(returnPosition, positionError);
        return true;
    }
    else {
        return false;
    }
}
function initMap(netObject, elementId, lat, lon, zoom) {
    mapNetObject = netObject;
    let latLng = new google.maps.LatLng(lat, lon);
    let options = {
        zoom: zoom,
        center: latLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        streetViewControl: false,
        scaleControl: false,
        zoomControl: false,
        mapTypeControl: false,
        fullscreenControl: false,
        clickableIcons: false
    };
    let mapElement = document.getElementById(elementId);
    map = new google.maps.Map(mapElement, options);
    mousedUp = false;
    map.addListener('mousedown', (event) => {
        mousedUp = false;
        setTimeout(() => __awaiter(this, void 0, void 0, function* () {
            if (mousedUp === false) {
                let lat = event.latLng.lat();
                let lon = event.latLng.lng();
            }
        }), 500);
    });
    map.addListener('mouseup', () => mousedUp = true);
    map.addListener('dragstart', () => mousedUp = true);
}