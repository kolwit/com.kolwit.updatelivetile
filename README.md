# Update Windows Phone 8 LiveTile plugin for Cordova 3.x and PhoneGap

This plugin is based on the plugins [com.risingj.cordova.livetiles](https://github.com/purplecabbage/livetiles).

With this plugin you are able to update the existing tile. The default tile data you can configure in your WMAppManifest.xml
Please check on Microsoft MSDN the page [Tiles for Windows Phone 8](http://msdn.microsoft.com/en-us/library/windows/apps/hh202948%28v=vs.105%29.aspx) for instructions how to configure the default tile.

## Example usage in general

The function will return a message on error, you can catch it with a function.

```js
var successFunc = function () {};

var errorFunc = function (c,m) {
		console.log('Tile update failed: ' + c + ' - ' + m);
		};

window.plugins.UpdateLiveTile.updateTile(successFunc,errorFunc,tileOptions);
```

## Flip Tile template for Windows Phone 8

In case you configured a flip tile, please configure the options like below:

```js
var tileOptions = {
		'tileType':					'flip',
		'Title':					'your Title',
		'BackTitle':				'your BackTitle',
		'BackContent':				'your BackContent',
		'WideBackContent':			'your WideBackContent',
		'Count':					'Count', // numeric value from 0 to 99
		'SmallBackgroundImage':		'path/to/SmallBackgroundImage.png',
		'BackgroundImage':			'path/to/BackgroundImage.png',
		'BackBackgroundImage':		'path/to/BackBackgroundImage.png',
		'WideBackgroundImage':		'path/to/WideBackgroundImage.png',
		'WideBackBackgroundImage':	'path/to/WideBackBackgroundImage.png'
	};
	
window.plugins.UpdateLiveTile.updateTile(successFunc,errorFunc,tileOptions);
```

Instructions for the fields can be found at Microsoft: [Flip Tile template for Windows Phone 8](http://msdn.microsoft.com/en-us/library/windows/apps/jj206971%28v=vs.105%29.aspx)
![FlipTile](/images/fliptile.png?raw=true "Flip Tile template for Windows Phone 8 - image from Microsoft MSDN")

## Iconic Tile template for Windows Phone 8

In case you configured a flip tile, please configure the options like below:

```js
var tileOptions = {
		'tileType':					'iconic',
		'Title':					'your Title',
		'WideContent1':				'your WideContent1',
		'WideContent2':				'your WideContent2',
		'WideContent3':				'your WideContent3',
		'Count':					'Count', // numeric value from 0 to 99
		'SmallIconImage':			'path/to/SmallIconImage.png',
		'IconImage':				'path/to/IconImage.png',
		'BackgroundColor':			'#11BB75' // color hex like in CSS
	};
	
window.plugins.UpdateLiveTile.updateTile(successFunc,errorFunc,tileOptions);
```

Instructions for the fields can be found at Microsoft: [Iconic Tile template for Windows Phone 8](http://msdn.microsoft.com/en-us/library/windows/apps/jj207009%28v=vs.105%29.aspx)
![IconicTile](/images/iconictile.png?raw=true "Iconic Tile template for Windows Phone 8 - image from Microsoft MSDN")

## Windows Phone OS 7.1 Tile template

In case you configured a standard tile, please configure the options like below:

```js
var tileOptions = {
		'tileType':					'standard',
		'Title':					'your Title',
		'BackTitle':				'your BackTitle',
		'BackContent':				'your BackContent',
		'Count':					'Count', // numeric value from 0 to 99
		'BackgroundImage':			'path/to/BackgroundImage.png',
		'BackBackgroundImage':		'path/to/BackBackgroundImage.png'
	};
	
window.plugins.UpdateLiveTile.updateTile(successFunc,errorFunc,tileOptions);
```

Instructions for the fields can be found at Microsoft: [Windows Phone OS 7.1 Tile template](http://msdn.microsoft.com/en-us/library/windows/apps/jj553779%28v=vs.105%29.aspx)
![StandardTile](/images/wp7tile.png?raw=true "Windows Phone OS 7.1 Tile template - image from Microsoft MSDN")

## Installation Instructions Cordova

The UpdateLiveTile plugin provides support for Cordova's command-line tooling.
Simply navigate to your project's root directory and execute the following command:

```
cordova plugin add com.kolwit.updatelivetile
```
or
```
cordova plugin add https://github.com/kolwit/com.kolwit.updatelivetile.git
```

## Installation Instructions PhoneGap

The UpdateLiveTile plugin provides support for PhoneGap 3.0 CLI.
Simply navigate to your project's root directory and execute the following command:


```
phonegap plugin add com.kolwit.updatelivetile
```
or
```
phonegap local plugin add https://github.com/kolwit/com.kolwit.updatelivetile.git
```
