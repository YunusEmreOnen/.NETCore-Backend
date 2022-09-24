using Core.Entities;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileService
{
    public class StorageService
    {

    
        public static IResult Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return  new SuccessResult();
            }
            return new ErrorResult();
        }

        public static IDataResult<FileDTO> Update(IFormFile file,string path)
        {
           if(!File.Exists(path))
            {
                File.Delete(path);
                var result = Upload(file, Path.GetPathRoot(path));
                return result;
            }
            return new ErrorDataResult<FileDTO>();
        }

        public static IDataResult<FileDTO> Upload(IFormFile file,string root)
        {
            if (file.Length>0)
            {
                
                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string _filePath= root+guid+extension;
               
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                
                using (Stream stream = File.Create(_filePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
 

                DateTime _fileLoadTime = File.GetCreationTime(_filePath);
                FileDTO fileDTO = new FileDTO() {FilePath=_filePath,FileLoadTime=_fileLoadTime};
                
                return new SuccessDataResult<FileDTO>(fileDTO);
            }

            return new ErrorDataResult<FileDTO>();

        }

    }
}
