//ENTRY
//TODO mqtt client, modbus client setup, congiffile with registers


var net = require('net');

var client = new net.Socket();
client.connect(1337, '127.0.0.1', function() {
	console.log('Connected');
	client.write('Hello, server! Love, Client.');
});

client.on('data', function(data) {
	console.log('Received: ' + data);
	client.destroy(); // kill client after server's response
});

client.on('close', function() {
	console.log('Connection closed');
});



var modbus = require("modbus-tcp");
var client = new modbus.Client();
var server = new modbus.Server();

// link client and server streams together
client.writer().pipe(server.reader());
server.writer().pipe(client.reader());
// if you have a socket (stream) you can just
// call client.pipe(socket) or server.pipe(socket)

server.on("read-coils", function (from, to, reply) {
    return reply(null, [ 1, 0, 1, 1 ]);
});

// read coils from unit id = 0, from address 10 to 13
client.readCoils(0, 10, 13, function (err, coils) {
    // coils = [ 1, 0, 1, 1 ]
});


var mqtt = require('mqtt')
var client  = mqtt.connect('mqtt://test.mosquitto.org')
 
client.on('connect', function () {
  client.subscribe('presence')
  client.publish('presence', 'Hello mqtt')
})
 
client.on('message', function (topic, message) {
  // message is Buffer
  console.log(message.toString())
  client.end()
})



var express = require('express');
var app = express();

app.get('/', function (req, res) {
   res.send('Hello World');
})


app.post('/', function (req, res) {
    console.log("Got a POST request for the homepage");
    res.send('Hello POST');
 })


var server = app.listen(8081, function () {
   var host = server.address().address
   var port = server.address().port
   
   console.log("Example app listening at http://%s:%s", host, port)
})