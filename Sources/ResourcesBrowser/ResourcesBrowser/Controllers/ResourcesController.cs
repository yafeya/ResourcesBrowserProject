using ResourcesBrowser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using ResourcesBrowser.Utilities;
using System.Net;
using System.Text;

namespace ResourcesBrowser.Controllers
{
    public class ResourcesController : ApiController
    {
        private const string SLASH = "/";
        private const string REVERT_SLASH = @"\";

        [Route("api/Resources/GetResourceItemsInRoot")]
        public IHttpActionResult GetResourceItemsInRoot()
        {
            var dirPath = ResourcesManager.Manager.ResourcesPath;
            var items = GetResourceItems(dirPath);
            var status = items != null ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return new RetrieveResult(status, Request, items);
        }
        [Route("api/Resources/GetResourceItemsByPath")]
        public IHttpActionResult GetResourceItemsByPath(string folderUri)
        {
            var dirPath = ConvertToDirPath(folderUri);

            var items = GetResourceItems(dirPath);
            var status = items != null ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return new RetrieveResult(status, Request, items);
        }
        [Route("api/Resources/GetBackUri")]
        public IHttpActionResult GetBackUri(string currentUri)
        {
            var currentDirPath = ConvertToDirPath(currentUri);
            var currentDirInfo = new DirectoryInfo(currentDirPath);
            var parentDirInfo = currentDirInfo.Parent;
            var parentUri = ConvertToUri(parentDirInfo);
            var status = !string.IsNullOrEmpty(parentUri) ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return new RetrieveResult(status, Request, parentUri);
        }

        internal static IEnumerable<ResourceItem> GetResourceItems(string dirPath)
        {
            var itemList = new List<ResourceItem>();
            if (Directory.Exists(dirPath))
            {
                var dirItems = GetDirItems(dirPath);
                var fileItems = GetFileItems(dirPath);

                itemList.AddRange(dirItems);
                itemList.AddRange(fileItems);
            }
            return itemList;
        }
        internal static string ConvertToDirPath(string uri)
        {
            var builder = new StringBuilder();
            builder.Append(SLASH).Append(ResourcesManager.Manager.RootDirName);
            var rootMark = builder.ToString();
            var restParts = uri.Replace(rootMark, string.Empty);
            restParts = restParts.Replace(SLASH, REVERT_SLASH);
            var dirPath = UtilitiesFactory.CombineStrings(ResourcesManager.Manager.ResourcesPath, restParts);
            return dirPath;
        }
        internal static string ConvertToUri(DirectoryInfo dirInfo)
        {
            var builder = new StringBuilder();
            if (dirInfo.Name != ResourcesManager.Manager.RootDirName)
            {
                var parentUri = ConvertToUri(dirInfo.Parent);
                builder.Append(parentUri).Append(SLASH).Append(dirInfo.Name);
            }
            else
            {
                builder.Append(SLASH).Append(ResourcesManager.Manager.RootDirName);
            }
            return builder.ToString();
        }

        private static IEnumerable<ResourceItem> GetFileItems(string dirPath)
        {
            var fileItemList = new List<ResourceItem>();
            var files = Directory.GetFiles(dirPath);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var fileItem = new ResourceItem
                {
                    Name = fileInfo.Name.GetSafeName(),
                    Description = fileInfo.GetDescription(),
                    Uri = ConvertToUri(fileInfo),
                    ImgUri = ImgManager.Manager.GetImgUrl(Path.GetExtension(file)),
                    Type = 1
                };
                fileItemList.Add(fileItem);
            }
            return fileItemList;
        }
        private static IEnumerable<ResourceItem> GetDirItems(string dirPath)
        {
            var dirItemList = new List<ResourceItem>();
            var subDirs = Directory.GetDirectories(dirPath);
            foreach (var subDir in subDirs)
            {
                var dirInfo = new DirectoryInfo(subDir);
                var dirItem = new ResourceItem
                {
                    Name = dirInfo.Name.GetSafeName(),
                    Description = dirInfo.GetDescription(),
                    Uri = ConvertToUri(dirInfo),
                    ImgUri = ImgManager.Manager.GetImgUrl(string.Empty),
                    Type = 2
                };
                dirItemList.Add(dirItem);
            }
            return dirItemList;
        }
        private static string ConvertToUri(FileInfo fileInfo)
        {
            var dirInfo = fileInfo.Directory;
            var dirUri = ConvertToUri(dirInfo);
            return UtilitiesFactory.CombineStrings(dirUri, SLASH, fileInfo.Name);
        }
    }
}