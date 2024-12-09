using Microsoft.AspNetCore.Mvc;
using Podcast.BLL.UI.Services.Contracts;

namespace Podcast.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IHomeService homeService, IWebHostEnvironment webHostEnvironment)
        {
            _homeService = homeService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _homeService.GetHomeViewModel();

            return  View(viewModel);
        }

        public async Task<IActionResult> Download(int? id)
        {
            if (id == null) return NotFound();

            var fileResult = await _homeService.Download(id.Value);

            return File(fileResult.fileContent, fileResult.fileContentType, fileResult.fileName);

            //var fileResult = _homeService.DownloadWithFileContent();

            //return File(fileResult.FileContents, fileResult.ContentType, fileResult.FileDownloadName);
        }
    }
}
