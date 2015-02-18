using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public class DefaultImgLoader : ImgLoader
    {
        private const string EXTENSIONS = "*.*";
        private const string FILENAME = "default.png";

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return new string[] { EXTENSIONS };
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }
}