using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public class WordImgLoader : ImgLoader
    {
        private const string FILENAME="word.png";
        private static readonly string[] _extensions = { ".doc", ".docx", ".docm", ".dot", ".dotx", ".dotm" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class ExcelImgLoader : ImgLoader
    {
        private const string FILENAME = "excel.png";
        private static readonly string[] _extensions = { ".xls", ".xlsx", ".xlsm", ".xlsb", ".xlt", ".xltx", ".xltm" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class PPTImgLoader : ImgLoader
    {
        private const string FILENAME = "ppt.png";
        private static readonly string[] _extensions = { ".ppt", ".pptx", ".pptm", ".pot", ".potx", ".potm", ".pps", ".ppsx", ".ppsm", ".ppa", ".ppas", ".ppam" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class VisioImgLoader : ImgLoader
    {
        private const string FILENAME = "visio.png";
        private static readonly string[] _extensions = { ".vsd", ".vst", ".vss", ".vdw", ".vsx", ".vdx", ".vtx" };

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