using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ResourcesBrowser.Models
{
    public class ResourcesManager
    {
        private static ResourcesManager _manager = new ResourcesManager();
        private string _resPath = string.Empty;
        private string _rootDirName = string.Empty;

        private ResourcesManager()
        { }

        public static ResourcesManager Manager
        {
            get { return _manager; }
        }
        public string ResourcesPath
        {
            get { return _resPath; }
        }
        public string RootDirName
        {
            get { return _rootDirName; }
        }

        public void SetRootDirName(string rootDirName)
        {
            _rootDirName = rootDirName;
        }
        public void SetResourcesPath(string resourcesPath)
        {
            _resPath = resourcesPath;
        }
    }
}