using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public class MKVImgLoader : ImgLoader
    {
        private const string FILENAME = "mkv.png";
        private static readonly string[] _extensions = { ".mkv" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class MP4ImgLoader : ImgLoader
    {
        private const string FILENAME = "mp4.png";
        private static readonly string[] _extensions = { ".mp4" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class RMVBImgLoader : ImgLoader
    {
        private const string FILENAME = "rmvb.png";
        private static readonly string[] _extensions = { ".rmvb" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class WMVImgLoader : ImgLoader
    {
        private const string FILENAME = "wmv.png";
        private static readonly string[] _extensions = { ".wmv" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class AVIImgLoader : ImgLoader
    {
        private const string FILENAME = "avi.png";
        private static readonly string[] _extensions = { ".avi" };

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