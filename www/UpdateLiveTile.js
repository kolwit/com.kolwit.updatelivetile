/**
 * @constructor
 */
var UpdateLiveTile = function(){};

UpdateLiveTile.prototype.updateTile = function(success, failure, options){
    cordova.exec(success, failure, "UpdateLiveTile", "updateTile", [options]);
};

cordova.addConstructor(function() {

    if (!window.Cordova) {
        window.Cordova = cordova;
    };


    if(!window.plugins) window.plugins = {};
    window.plugins.UpdateLiveTile = new UpdateLiveTile();
});

