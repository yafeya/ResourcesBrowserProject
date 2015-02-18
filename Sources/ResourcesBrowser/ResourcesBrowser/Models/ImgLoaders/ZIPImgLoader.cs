using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public class ZIPImgLoader : ImgLoader
    {
        private const string FILENAME = "zip.png";
        private static readonly string[] _extensions = { ".zip", ".rar", ".7z", ".tar" };

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