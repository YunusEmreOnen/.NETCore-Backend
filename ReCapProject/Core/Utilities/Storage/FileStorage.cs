using Core.Entities;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Storage
{
    public class FileStorage
    {


        public static IResult Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public static IDataResult<FileStorageObject> Update(IFormFile file, string path)
        {
            if (File.Exists(path))
            {
                string newFilePath;
               
                using (Stream stream =File.Open(path,FileMode.Open))
                {              
                    file.CopyTo(stream);                  
                    stream.Flush();
                }
                
                
                FileStorageObject fileStorageObject = new FileStorageObject()
                {
                    FileLoadTime = File.GetLastWriteTime(path)
                };
                return new SuccessDataResult<FileStorageObject>(fileStorageObject);
                
                
            }
            return new ErrorDataResult<FileStorageObject>();
        }

        public static IDataResult<FileStorageObject> Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {

                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string _filePath = root + guid + extension;

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
                FileStorageObject fileStorageObject = new FileStorageObject()
                {
                    FilePath = _filePath,
                    FileLoadTime = _fileLoadTime
                };

                return new SuccessDataResult<FileStorageObject>(fileStorageObject);
            }

            return new ErrorDataResult<FileStorageObject>();

        }

    }
}
