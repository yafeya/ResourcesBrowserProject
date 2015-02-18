using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public class PictureImgLoader : ImgLoader
    {
        private const string FILENAME = "pic.png";
        private static readonly string[] _extensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }
}