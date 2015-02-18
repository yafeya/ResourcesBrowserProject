using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ResourcesBrowser.Models
{
    public class ImgManager
    {
        private const string DEFAULT_INDICATOR = "*.*";
        private static ImgManager _manager = new ImgManager();
        private List<IImgLoader> _loaderList;
        private object _loaderListLocker = new object();

        private ImgManager()
        {
            Monitor.Enter(_loaderListLocker);
            _loaderList = new List<IImgLoader>();
            Monitor.Exit(_loaderListLocker);
            Initialize();
        }

        public static ImgManager Manager
        {
            get { return _manager; }
        }

        public string GetImgUrl(string itemIndicator)
        {
            string imgUrl = string.Empty;
            if (!TryGetImgUrl(itemIndicator, out imgUrl))
            {
                itemIndicator = DEFAULT_INDICATOR;
                TryGetImgUrl(itemIndicator, out imgUrl);
            }
            return imgUrl;
        }
        private void Initialize()
        {
            var type = typeof(ImgManager);
            var types = type.Assembly.GetTypes();
            var loaderTypes = types.Where(t => typeof(IImgLoader).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var loaderType in loaderTypes)
            {
                var creator = loaderType.GetConstructor(new Type[] { });
                var loader = creator.Invoke(new object[] { }) as IImgLoader;
                if (loader != null)
                {
                    Monitor.Enter(_loaderListLocker);
                    _loaderList.Add(loader);
                    Monitor.Exit(_loaderListLocker);
                }
            }
        }
        private bool TryGetImgUrl(string itemIndicator, out string imgUrl)
        {
            imgUrl = string.Empty;
            bool found = false;
            Monitor.Enter(_loaderListLocker);
            foreach (var loader in _loaderList)
            {
                imgUrl = loader.LoadImgUri(itemIndicator);
                if (!string.IsNullOrEmpty(imgUrl))
                {
                    found = true;
                    break;
                }
            }
            Monitor.Exit(_loaderListLocker);
            return found;
        }
    }
}