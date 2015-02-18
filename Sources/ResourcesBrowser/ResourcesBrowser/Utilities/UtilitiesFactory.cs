using ResourcesBrowser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ResourcesBrowser.Utilities
{
    public static class UtilitiesFactory
    {
        public static string CombineStrings(params string[] parts)
        {
            var builder = new StringBuilder();
            if (parts != null)
            {
                foreach (var part in parts)
                {
                    builder.Append(part);
                }
            }
            return builder.ToString();
        }

        public static string GetDescription(this FileInfo fileInfo)
        {
            var builder = new StringBuilder();
            builder.Append("Name: ").Append(fileInfo.Name)
                .Append(", Creation Time: ")
                .Append(fileInfo.CreationTime)
                .Append(", Size: ").Append(ConvertSize(fileInfo.Length));
            return builder.ToString();
        }

        public static string GetDescription(this DirectoryInfo dirInfo)
        {
            var builder = new StringBuilder();
            builder.Append("Name: ").Append(dirInfo.Name)
                .Append(", Creation Time: ")
                .Append(dirInfo.CreationTime);
            var dirs = dirInfo.GetDirectories().Length;
            var files = dirInfo.GetFiles().Length;
            builder.Append(", ").Append(dirs).Append(" directories inside")
                .Append(", ").Append(files).Append("files inside");
            return builder.ToString();
        }

        public static string GetSafeName(this string name)
        {
            if (name.Length > 10)
            {
                name = name.Substring(0, 7);
                name = CombineStrings(name, "...");
            }
            return name;
        }

        private static string ConvertSize(long length)
        {
            var builder = new StringBuilder();
            var kSize = (double)length / 1024;
            var mSize = kSize / 1024;
            builder.Append(mSize.ToString("F2")).Append("MB");
            return builder.ToString();
        }
    }
}