using ResourcesBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public abstract class ImgLoader : IImgLoader
    {
        protected const string SLASH = "/";

        public virtual string LoadImgUri(string itemIndicator)
        {
            var supportedIndicators = GetSuportedIndicators();
            string imgUrl = string.Empty;
            if (supportedIndicators.Contains(itemIndicator.ToLower()))
            {
                imgUrl = GetImgFileUrl();
            }
            return imgUrl;
        }

        protected abstract IEnumerable<string> GetSuportedIndicators();
        protected virtual string GetImgFileUrl()
        {
            var imgDirPath = "Images";
            var imgFileName = GetImgFileName();
            return UtilitiesFactory.CombineStrings(imgDirPath, SLASH, imgFileName);
        }
        protected abstract string GetImgFileName();
    }
}