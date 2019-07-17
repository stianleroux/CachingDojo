var express = require("express");
var compression = require('compression');
var app = express();

app.use(compression());

app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
});

const flatCache = require('flat-cache');
let cache = flatCache.load('productsCache');

app.get("/url", (req, res, next) => {
    let key =  '__express__' + req.originalUrl || req.url
    let cacheContent = cache.getKey(key);
    res.set('Cache-Control', 'public, max-age=31557600'); // one year
    if( cacheContent){
        res.send( cacheContent );
    }else{
        let data = ["Tony","Lisa","Michael","Ginger","Food"];
        cache.setKey(key,data);
        cache.save();
        res.json(data);
    }
});

app.listen(3000, () => {
 console.log("Server running on port 3000");
});