using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Podcast.BLL.UI.Services.Contracts;
using System.IO;
using System.Net.Sockets;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Podcast.BLL.UI.Services
{
    public class FileManager : IFileService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileManager(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public (byte[] fileContent, string fileContentType, string fileName) Download(string filePath, string fileName)
        {
            filePath = Path.Combine(filePath, fileName);
            var fileContent = File.ReadAllBytes(filePath);
            var contentType = GetFileContentType(fileName);

            return (fileContent, contentType, fileName);
        }

        public FileContentResult DownloadWithFileContent()
        {
            var fileName = "2.jpg";
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", "topics", fileName);
            var fileContent = System.IO.File.ReadAllBytes(filePath);
            var contentType = "image/jpg";
         
            var fileContentResult = new FileContentResult(fileContent, contentType)
            {
                FileDownloadName = fileName,
            };


            return fileContentResult;
        }

        public string GetFileContentType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(fileName, out string? contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}
