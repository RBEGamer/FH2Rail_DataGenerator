//ENTRY
//TODO mqtt client, modbus client setup, congiffile with registers
var config = require('./config.json');



var mqtt = require('mqtt')
var client  = mqtt.connect(config.mqtt_conf.server_uri)
 
client.on('connect', function () {
  client.subscribe('fh2trail')
  client.publish('fh2trail', 'Hello mqtt')
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


var server = app.listen(config.http_conf.bind_port, function () {
   var host = server.address().address
   var port = server.address().port
   console.log("Example app listening at http://%s:%s", host, port)
})