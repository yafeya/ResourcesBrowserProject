using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models.ImgLoaders
{
    public class MP3ImgLoader : ImgLoader
    {
        private const string FILENAME = "mp3.png";
        private static readonly string[] _extensions = { ".mp3" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class APEImgLoader : ImgLoader
    {
        private const string FILENAME = "ape.png";
        private static readonly string[] _extensions = { ".ape" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class FLACImgLoader : ImgLoader
    {
        private const string FILENAME = "flac.png";
        private static readonly string[] _extensions = { ".flac" };

        protected override IEnumerable<string> GetSuportedIndicators()
        {
            return _extensions;
        }

        protected override string GetImgFileName()
        {
            return FILENAME;
        }
    }

    public class WAVImgLoader : ImgLoader
    {
        private const string FILENAME = "wav.png";
        private static readonly string[] _extensions = { ".wav" };

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