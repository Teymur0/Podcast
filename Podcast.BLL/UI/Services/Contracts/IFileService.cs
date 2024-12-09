using System.Web.Mvc;

namespace Podcast.BLL.UI.Services.Contracts
{
    public interface IFileService
    {
        (byte[] fileContent,string fileContentType, string fileName) Download(string filePath, string fileName);
        FileContentResult DownloadWithFileContent();//bad way
        string GetFileContentType(string fileName);
    }
}
