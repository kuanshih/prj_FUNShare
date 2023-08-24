// Initialize and add the map
let map;

async function initMap() {
  // The location of Uluru
  const position = { lat: -25.344, lng: 131.031 };
  // Request needed libraries.
  //@ts-ignore
  const { Map } = await google.maps.importLibrary("maps");
  const { AdvancedMarkerView } = await google.maps.importLibrary("marker");
    let testposition="";
   
  function geocode(){
    var location= '高雄市前金區光復二街';
    axios.get('https://maps.googleapis.com/maps/api/geocode/json',{
        params:{
            address:location,
            key:'AIzaSyDdEXjwGZSJgCYTBhl7Pmp4KWaJhGJAmwU'
        }
    })
    .then(function(response){
        console.log(response)

        var getlat = response.data.results[0].geometry.location.lat;
        var getlng = response.data.results[0].geometry.location.lng;
        var output = `{lat:${getlat},lng:${getlng}}`;
        position.lat=getlat;
        position.lng = getlng;

  // The map, centered at Uluru
  map = new Map(document.getElementById("map"), {
  zoom: 13,
  center: position,
  mapId: "DEMO_MAP_ID",
});

// The marker, positioned at Uluru
const marker = new AdvancedMarkerView({
  map: map,
  position: position,
  title: "Uluru",
});

    })
    .catch(function(error){
        console.log(error)
    })
}
geocode()
}

initMap();