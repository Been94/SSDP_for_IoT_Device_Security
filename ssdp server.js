var SSDP = require('node-ssdp').Server
, server = new SSDP({
location: 'http://' + require('ip').address() + ':33333',
ssdpPort: 33333
})
console.log(require('ip').address())
server.addUSN('upnp:rootdevice')
server.addUSN('urn:schemas-upnp-org:device:MediaServer:1')
server.addUSN('urn:schemas-upnp-org:service:ContentDirectory:1')
server.addUSN('urn:schemas-upnp-org:service:ConnectionManager:1')

server.on('advertise-alive', function (heads) {
  console.log('advertise-alive', heads)
  // Expire old devices from your cache.
  // Register advertising device somewhere (as designated in http headers heads)
})

server.on('advertise-bye', function (heads) {
  console.log('advertise-bye', heads)
  // Remove specified device from cache.
})

// start server on all interfaces
console.log('starting ssdp server')
server.start()
