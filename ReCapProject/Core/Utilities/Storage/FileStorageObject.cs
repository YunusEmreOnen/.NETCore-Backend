using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Storage
{
    public class FileStorageObject

    {
        public string FilePath { get; set; }
        public DateTime FileLoadTime { get; set; }
    }
}
