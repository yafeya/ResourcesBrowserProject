using ResourcesBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public class FolderImgLoader : IImgLoader
    {
        private const string FILENAME = "folder.png";
        private const string SLASH = "/";

        public string LoadImgUri(string itemIndicator)
        {
            var imgUrl = string.Empty;
            if (string.IsNullOrEmpty(itemIndicator))
            {
                var imgDirPath = "Images";
                imgUrl = UtilitiesFactory.CombineStrings(imgDirPath, SLASH, FILENAME);
            }
            return imgUrl;
        }
    }
}