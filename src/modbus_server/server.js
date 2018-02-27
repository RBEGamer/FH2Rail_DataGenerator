//ENTRY
//TODO mqtt client, modbus client setup, congiffile with registers
var  config = require('./config.json');
const chalk = require('chalk');
var ModbusRTU = require("modbus-serial");
var express = require('express');
var app = express();
var mqtt = require('mqtt')
var mqtt_client  = mqtt.connect(config.mqtt_conf.server_uri)



var modbus_client = new ModbusRTU();
modbus_client.connectTCP(config.modbus_conf.server,{ port: config.modbus_conf.port });
modbus_client.setID(config.modbus_conf.device_id);






mqtt_client.on('connect', function () {
  mqtt_client.subscribe(config.mqtt_conf.sim2mod_topic)
})
 
mqtt_client.on('message', function (topic, message) {
  console.log(message.toString())

var obj = JSON.parse(message.toString());

if(obj == undefined || obj.sensor_id == undefined || obj.sensor_id == "" || obj.value == undefined){
  console.log(chalk.red('-- parse error -- not all field set:' + obj.sensor_id + ' ' + obj.value + ' ' + obj));
  return;
}
 
var addr = -1;
var val = obj.value;
var type = "register";


//FIND IN CONF
for (let index = 0; index < config.modbus_conf.matrix.length; index++) {
  const element = config.modbus_conf.matrix[index];
  if(element.sensor_id == obj.sensor_id){
    addr = element.address;
    type = element.type;
    console.log("found");
    break;
  }
}


if(addr < 0){
  console.log("-- addr <0 ");
  return;
}

if(type == "register"){
modbus_client.writeRegister(addr, val, function(err, data) {
  if (err) {
        console.log(err);
  } else {
      //  console.log(data);
  }
})
}


})



app.set('view engine', 'ejs');
app.use('/public', express.static(__dirname + '/public'));


app.get('/', function(req, res) {
    res.render('views/index.ejs');
});



var server = app.listen(config.http_conf.bind_port, function () {
   var host = server.address().address
   var port = server.address().port
   console.log("WebUI:  http://%s:%s", host, port)
})

