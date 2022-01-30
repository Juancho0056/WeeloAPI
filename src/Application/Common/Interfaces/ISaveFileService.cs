using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Interfaces
{
    public interface ISaveFileService
    {
        string SaveImage(IFormFile File, string FilePath);
        string SaveImage(FileStream File, string FilePath);
    }
}
