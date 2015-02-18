using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcesBrowser.Models
{
    public class ResourceItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
        public string ImgUri { get; set; }
        /// <summary>
        /// 1: file, 2: dir
        /// </summary>
        public int Type { get; set; }
    }
}