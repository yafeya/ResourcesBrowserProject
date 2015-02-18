using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public class TXTImgLoader : ImgLoader
    {
        private const string FILENAME = "txt.png";
        private static readonly string[] _extensions = { ".txt" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class PDFImgLoader : ImgLoader
    {
        private const string FILENAME = "pdf.png";
        private static readonly string[] _extensions = { ".pdf" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class XPSImgLoader : ImgLoader
    {
        private const string FILENAME = "xps.png";
        private static readonly string[] _extensions = { ".xps" };

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