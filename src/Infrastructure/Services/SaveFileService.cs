using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Interfaces;

namespace WeeloApi.Infrastructure.Services
{
    public class SaveFileService: ISaveFileService
    {
   
        public string SaveImage(IFormFile File, string FilePath)
        {
            try
            {
                if (string.IsNullOrEmpty(FilePath))
                    return "";
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string uniqueFileName = null;
                if (File != null)
                {
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString("yyyyMMdd")+".png";
                    string filePath = Path.Combine(FilePath, uniqueFileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    File.CopyTo(fileStream);
                }
                return uniqueFileName;
            }
            catch (Exception)
            {
                return "";
            }
            
        }

        public string SaveImage(FileStream File, string FilePath)
        {
            try
            {
                if (string.IsNullOrEmpty(FilePath))
                    return "";
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string uniqueFileName = null;
                if (File != null)
                {
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".png";
                    string filePath = Path.Combine(FilePath, uniqueFileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    File.CopyTo(fileStream);
                }
                return uniqueFileName;
            }
            catch (Exception)
            {
                return "";
            }

        }

    }
}
