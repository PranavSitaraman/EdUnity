var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator)
{
    function adopt(value)
    {
        return value instanceof P ? value : new P(function (resolve){ resolve(value); });
    }
    return new (P || (P = Promise))(function (resolve, reject)
    {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var PinKind;
(function (PinKind) { PinKind[PinKind["Car"] = 0] = "Car"; })(PinKind || (PinKind = {}));
let map, meMarker;
let pinMarkers = {};
let pins = {};
let mousedUp;
let mapNetObject;
let meIcon;
let markerIconsLoc;
let markerIconsPin;
let PinPopup;
const meSize = 50;
const pinIconSize = 40;
function initialize(netObject)
{
    initResources();
    mapNetObject = netObject;
    let latLng = new google.maps.LatLng(40.504362, -74.369188);
    let options = {
        zoom: 18,
        center: latLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        streetViewControl: false,
        scaleControl: false,
        zoomControl: false,
        mapTypeControl: false,
        fullscreenControl: false,
        clickableIcons: false
    };
    map = new google.maps.Map(document.getElementById("map"), options);
    pinMarkers = {};
    pins = {};
    mousedUp = false;
    map.addListener('mousedown', (event) => {
        mousedUp = false;
        setTimeout(() => __awaiter(this, void 0, void 0, function* () {
            if (mousedUp === false)
            {
                let lat = event.latLng.lat();
                let lon = event.latLng.lng();
                yield netObject.invokeMethodAsync("OnLongPress", lat, lon);
            }
        }), 500);
    });
    map.addListener('mouseup', () => mousedUp = true);
    map.addListener('dragstart', () => mousedUp = true);
    let pos = { lat: latLng.lat(), lng: latLng.lng() };
    meMarker = new google.maps.Marker({
        position: pos,
        map: map,
        icon: meIcon
    });
}
function initResources() {
    meIcon = {
        url: "/img/man.svg",
        scaledSize: new google.maps.Size(meSize, meSize),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(meSize / 2, meSize / 2)
    };
    markerIconsPin = {
        [PinKind.Car]: {
            url: '/img/car.png',
            scaledSize: new google.maps.Size(pinIconSize, pinIconSize),
            origin: new google.maps.Point(0, 0),
            anchor: new google.maps.Point(pinIconSize / 2, pinIconSize / 2)
        },
    };
    PinPopup = class extends google.maps.OverlayView
    {
        constructor(marker, content)
        {
            super();
            this.marker = marker;
            this.position = marker.getPosition();
            let closeContainer = document.createElement('div');
            closeContainer.classList.add("popup-bubble");
            const closeIcon = document.createElement("ion-icon");
            closeIcon["name"] = "close";
            closeIcon.onclick = () => { this.setMap(null); };
            closeContainer.appendChild(content);
            closeContainer.appendChild(closeIcon);
            closeContainer.setAttribute('style', 'border: thin solid white;');
            const bubbleAnchor = document.createElement("div");
            bubbleAnchor.classList.add("popup-bubble-anchor");
            bubbleAnchor.appendChild(closeContainer);
            this.containerDiv = document.createElement("div");
            this.containerDiv.classList.add("popup-container");
            this.containerDiv.appendChild(bubbleAnchor);
            PinPopup.preventMapHitsAndGesturesFrom(this.containerDiv);
        }
        onAdd()
        {
            this.getPanes().floatPane.appendChild(this.containerDiv);
        }
        onRemove()
        {
            if (this.containerDiv.parentElement) this.containerDiv.parentElement.removeChild(this.containerDiv);
        }
        draw()
        {
            const divPosition = this.getProjection().fromLatLngToDivPixel(this.position);
            const display = "block";
            if (display === "block")
            {
                this.containerDiv.style.left = divPosition.x + "px";
                this.containerDiv.style.top = divPosition.y + "px";
            }
            if (this.containerDiv.style.display !== display) this.containerDiv.style.display = display;
        }
    };
}
let curInfoWindow;
let curInfoWindowId;
function previewPin(id)
{
    let pin = pins[id];
    let marker = pinMarkers[id];
    let content = document.createElement("div");
    content.className = "google-map-info";
    content.innerHTML = `<h2>${pin.name}<br/>${pin.time}</h2>`;
    content.onclick = () => pinDetails(id);
    curInfoWindowId = id;
    curInfoWindow = new PinPopup(marker, content);
    curInfoWindow.setMap(map);
}
function placePin(pin)
{
    pins[pin.id] = pin;
    let marker = new google.maps.Marker({
        position: { lat: pin.lat, lng: pin.lon },
        map: map,
        icon: markerIconsPin[pin.kind]
    });
    marker.addListener("click", () => previewPin(pin.id));
    pinMarkers[pin.id] = marker;
}
function pinDetails(id)
{
    mapNetObject.invokeMethodAsync('ViewDetails', id);
}
let longPressIndicator;
function placeLongPressIndicator(lat, lon)
{
    let pos = { lat: lat, lng: lon };
    if (longPressIndicator == undefined)
    {
        longPressIndicator = new google.maps.Marker({
            position: pos,
            map: map,
            icon: {
                url: "/img/pin.svg",
                scaledSize: new google.maps.Size(meSize, meSize),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(meSize / 2, meSize),
                fillColor: "red"
            }
        });
    }
    else longPressIndicator.setPosition(pos);
}
function removeLongPressIndicator()
{
    if (longPressIndicator != undefined)
    {
        longPressIndicator.setMap(null);
        longPressIndicator = undefined;
    }
}