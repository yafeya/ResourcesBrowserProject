using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesBrowser.Models
{
    interface IImgLoader
    {
        string LoadImgUri(string itemIndicator);
    }
}
