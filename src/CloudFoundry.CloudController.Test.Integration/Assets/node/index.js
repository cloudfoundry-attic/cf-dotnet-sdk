var port = process.env.VCAP_APP_PORT;
var host = process.env.VCAP_APP_HOST;
var http = require('http');
http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end('Hello World\n');
}).listen(port, host);