using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileService
{
    public class FileDTO: IDto
    {
        public string FilePath { get; set; }
        public DateTime FileLoadTime { get; set; }
    }
}
