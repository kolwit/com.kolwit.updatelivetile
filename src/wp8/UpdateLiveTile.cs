using System.Runtime.Serialization;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Controls;
using System.Windows;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using WPCordovaClassLib.Cordova;
using Color = System.Windows.Media.Color;

namespace Cordova.Extension.Commands
{
    /// <summary>
    /// Implements access to application live tiles
    /// </summary>
    public class UpdateLiveTile : BaseCommand
    {

        #region Live tiles options
        
        /// <summary>
        /// Represents LiveTile options
        /// </summary>
        [DataContract]
        public class LiveTilesOptions
        {
            /// <summary>
            /// Tile type
            /// </summary>
            [DataMember(IsRequired = false, Name = "tileType")]
            public string tileType { get; set; }

            /// <summary>
            /// Tile title
            /// </summary>
            [DataMember(IsRequired = false, Name = "Title")]
            public string Title { get; set; }

            /// <summary>
            /// Tile title
            /// </summary>
            [DataMember(IsRequired = false, Name = "BackTitle")]
            public string BackTitle { get; set; }

            /// <summary>
            /// Back tile content
            /// </summary>
            [DataMember(IsRequired = false, Name = "BackContent")]
            public string BackContent { get; set; }

            /// <summary>
            /// WideBack tile content
            /// </summary>
            [DataMember(IsRequired = false, Name = "WideBackContent")]
            public string WideBackContent { get; set; }

            /// <summary>
            /// WideContent1 tile content
            /// </summary>
            [DataMember(IsRequired = false, Name = "WideContent1")]
            public string WideContent1 { get; set; }

            /// <summary>
            /// WideContent2 tile content
            /// </summary>
            [DataMember(IsRequired = false, Name = "WideContent2")]
            public string WideContent2 { get; set; }

            /// <summary>
            /// WideContent3 tile content
            /// </summary>
            [DataMember(IsRequired = false, Name = "WideContent3")]
            public string WideContent3 { get; set; }

            /// <summary>
            /// Tile count
            /// </summary>
            [DataMember(IsRequired = false, Name = "Count")]
            public int Count { get; set; }

            /// <summary>
            /// Tile SmallBackgroundImage
            /// </summary>
            [DataMember(IsRequired = false, Name = "SmallBackgroundImage")]
            public string SmallBackgroundImage { get; set; }

            /// <summary>
            /// Tile BackgroundImage
            /// </summary>
            [DataMember(IsRequired = false, Name = "BackgroundImage")]
            public string BackgroundImage { get; set; }

            /// <summary>
            /// Tile BackBackgroundImage
            /// </summary>
            [DataMember(IsRequired = false, Name = "BackBackgroundImage")]
            public string BackBackgroundImage { get; set; }

            /// <summary>
            /// Tile WideBackgroundImage
            /// </summary>
            [DataMember(IsRequired = false, Name = "WideBackgroundImage")]
            public string WideBackgroundImage { get; set; }

            /// <summary>
            /// Tile WideBackBackgroundImage
            /// </summary>
            [DataMember(IsRequired = false, Name = "WideBackBackgroundImage")]
            public string WideBackBackgroundImage { get; set; }

            /// <summary>
            /// Tile SmallIconImage
            /// </summary>
            [DataMember(IsRequired = false, Name = "SmallIconImage")]
            public string SmallIconImage { get; set; }

            /// <summary>
            /// Tile WideBackBackgroundImage
            /// </summary>
            [DataMember(IsRequired = false, Name = "IconImage")]
            public string IconImage { get; set; }

            /// <summary>
            /// Tile BackgroundColor (ex. #524742)
            /// </summary>
            [DataMember(IsRequired = false, Name = "BackgroundColor")]
            public string BackgroundColor { get; set; }
        }
        #endregion

        /// <summary>
        /// Updates application live tile
        /// </summary>
        public void updateTile(string options)
        {
            string[] args = JsonHelper.Deserialize<string[]>(options);
            string callbackId = args[1];

            LiveTilesOptions liveTileOptions;
            try
            {
                liveTileOptions = JsonHelper.Deserialize<LiveTilesOptions>(args[0]);
            }
            catch (Exception)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.JSON_EXCEPTION), callbackId);
                return;
            }

            try
            {
                ShellTile appTile = ShellTile.ActiveTiles.First();

                if (appTile != null)
                {

                    if (liveTileOptions.tileType == "iconic")
                    {
                        IconicTileData TileData = CreateIconicTileData(liveTileOptions);
                        appTile.Update(TileData);
                        DispatchCommandResult(new PluginResult(PluginResult.Status.OK), callbackId);
                    }
                    else if (liveTileOptions.tileType == "standard")
                    {
                        StandardTileData TileData = CreateStandardTileData(liveTileOptions);
                        appTile.Update(TileData);
                        DispatchCommandResult(new PluginResult(PluginResult.Status.OK), callbackId);
                    }
                    else if (liveTileOptions.tileType == "flip")
                    {
                        FlipTileData TileData = CreateFlipTileData(liveTileOptions);
                        appTile.Update(TileData);
                        DispatchCommandResult(new PluginResult(PluginResult.Status.OK), callbackId);
                    }
                    else
                    {
                        //StandardTileData TileData = CreateStandardTileData(liveTileOptions);
                        //appTile.Update(TileData);
                        //DispatchCommandResult(new PluginResult(PluginResult.Status.OK), callbackId);
                        DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, "tileType not defined"), callbackId);
                    }                    
                }
                else
                {
                    DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, "Can't get application tile"), callbackId);
                }
            }
            catch(Exception)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, "Error updating application tile"), callbackId);
            }
        }

        /// <summary>
        /// Creates standard tile data
        /// </summary>
        private StandardTileData CreateStandardTileData(LiveTilesOptions liveTileOptions)
        {
            StandardTileData TileData = new StandardTileData();

            // Title
            if (!string.IsNullOrEmpty(liveTileOptions.Title))
            {
                TileData.Title = liveTileOptions.Title;
            }

            // BackTitle
            if (!string.IsNullOrEmpty(liveTileOptions.BackTitle))
            {
                TileData.BackTitle = liveTileOptions.BackTitle;
            }

            // BackContent
            if (!string.IsNullOrEmpty(liveTileOptions.BackContent))
            {
                TileData.BackContent = liveTileOptions.BackContent;
            }

            // Count
            if (liveTileOptions.Count > 0)
            {
                TileData.Count = liveTileOptions.Count;
            }

            // BackgroundImage
            if (!string.IsNullOrEmpty(liveTileOptions.BackgroundImage))
            {
                TileData.BackgroundImage = new Uri(liveTileOptions.BackgroundImage, UriKind.RelativeOrAbsolute);
            }

            // BackBackgroundImage
            if (!string.IsNullOrEmpty(liveTileOptions.BackBackgroundImage))
            {
                TileData.BackBackgroundImage = new Uri(liveTileOptions.BackBackgroundImage, UriKind.RelativeOrAbsolute);
            }

            return TileData;
        }


        /// <summary>
        /// Creates flip tile data
        /// </summary>
        private FlipTileData CreateFlipTileData(LiveTilesOptions liveTileOptions)
        {
            FlipTileData TileData = new FlipTileData();

            // Title
            if (!string.IsNullOrEmpty(liveTileOptions.Title))
            {
                TileData.Title = liveTileOptions.Title;
            }

            // BackTitle
            if (!string.IsNullOrEmpty(liveTileOptions.BackTitle))
            {
                TileData.BackTitle = liveTileOptions.BackTitle;
            }

            // BackContent
            if (!string.IsNullOrEmpty(liveTileOptions.BackContent))
            {
                TileData.BackContent = liveTileOptions.BackContent; 
            }

            // WideBackContent
            if (!string.IsNullOrEmpty(liveTileOptions.WideBackContent))
            {
                TileData.WideBackContent = liveTileOptions.WideBackContent;
            }

            // Count
            if (liveTileOptions.Count > 0)
            {
                TileData.Count = liveTileOptions.Count;
            }

            // SmallBackgroundImage
            if (!string.IsNullOrEmpty(liveTileOptions.SmallBackgroundImage))
            {
                TileData.SmallBackgroundImage = new Uri(liveTileOptions.SmallBackgroundImage, UriKind.RelativeOrAbsolute);
            }

            // BackgroundImage
            if (!string.IsNullOrEmpty(liveTileOptions.BackgroundImage))
            {
                TileData.BackgroundImage = new Uri(liveTileOptions.BackgroundImage, UriKind.RelativeOrAbsolute);
            }

            // BackBackgroundImage
            if (!string.IsNullOrEmpty(liveTileOptions.BackBackgroundImage))
            {
                TileData.BackBackgroundImage = new Uri(liveTileOptions.BackBackgroundImage, UriKind.RelativeOrAbsolute);
            }

            // WideBackgroundImage
            if (!string.IsNullOrEmpty(liveTileOptions.WideBackgroundImage))
            {
                TileData.WideBackgroundImage = new Uri(liveTileOptions.WideBackgroundImage, UriKind.RelativeOrAbsolute);
            }

            // WideBackBackgroundImage
            if (!string.IsNullOrEmpty(liveTileOptions.WideBackBackgroundImage))
            {
                TileData.WideBackBackgroundImage = new Uri(liveTileOptions.WideBackBackgroundImage, UriKind.RelativeOrAbsolute);
            }

            return TileData;
        }

        /// <summary>
        /// Creates flip tile data
        /// </summary>
        private IconicTileData CreateIconicTileData(LiveTilesOptions liveTileOptions)
        {
            IconicTileData TileData = new IconicTileData();

            // Title
            if (!string.IsNullOrEmpty(liveTileOptions.Title))
            {
                TileData.Title = liveTileOptions.Title;
            }

            // Count
            if (liveTileOptions.Count > 0)
            {
                TileData.Count = liveTileOptions.Count;
            }

            // WideContent1
            if (!string.IsNullOrEmpty(liveTileOptions.WideContent1))
            {
                TileData.WideContent1 = liveTileOptions.WideContent1;
            }

            // WideContent1
            if (!string.IsNullOrEmpty(liveTileOptions.WideContent2))
            {
                TileData.WideContent2 = liveTileOptions.WideContent2;
            }

            // WideContent3
            if (!string.IsNullOrEmpty(liveTileOptions.WideContent3))
            {
                TileData.WideContent3 = liveTileOptions.WideContent3;
            }

            // SmallIconImage
            if (!string.IsNullOrEmpty(liveTileOptions.SmallIconImage))
            {
                TileData.SmallIconImage = new Uri(liveTileOptions.SmallIconImage, UriKind.RelativeOrAbsolute);
            }

            // IconImage 
            if (!string.IsNullOrEmpty(liveTileOptions.IconImage))
            {
                TileData.IconImage = new Uri(liveTileOptions.IconImage, UriKind.RelativeOrAbsolute);
            }

            // BackgroundColor 
            if (!string.IsNullOrEmpty(liveTileOptions.BackgroundColor))
            {
                Color realBackgroundColor = ConvertStringToColor(liveTileOptions.BackgroundColor);
                TileData.BackgroundColor = realBackgroundColor;
            }

            return TileData;
        }


		/// <summary>
        /// Converts string to color
		/// source: http://stackoverflow.com/a/11739523/3861558
        /// </summary>
        public Color ConvertStringToColor(String hex)
        {
            hex = hex.Replace("#", "");
            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }



    }


}