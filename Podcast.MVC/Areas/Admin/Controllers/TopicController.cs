using Microsoft.AspNetCore.Mvc;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.TopicViewModels;

namespace Podcast.MVC.Areas.Admin.Controllers
{
    public class TopicController : AdminController
    {
        private readonly ITopicService _topicService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string FOLDER_PATH;

        public TopicController(ITopicService topicService, IWebHostEnvironment webHostEnvironment)
        {
            _topicService = topicService;
            _webHostEnvironment = webHostEnvironment;
            FOLDER_PATH = Path.Combine(_webHostEnvironment.WebRootPath, "images", "topics");
        }

        public async Task<IActionResult> Index()
        {
            var topics=await _topicService.GetListAsync();
            return View(topics);
        }

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicCreateViewModel v)
        {
            var result = await _topicService.CreateAsync(v,ModelState,FOLDER_PATH);
            if(result)
                return RedirectToAction("Index");
            return View(v);
        }
        public async Task<IActionResult> Update(int id)
        {

            var existingTopic = await _topicService.GetTopicForUpdateAsync(id);
            if (existingTopic == null) return NotFound();
            return View(existingTopic);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TopicUpdateViewModel v)
        {
            var result = await _topicService.UpdateAsync(v, ModelState, FOLDER_PATH);
            if (result == false) return View(v);
            if (result == null) return BadRequest();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete (int id)
        {

            var result=await _topicService.RemoveAsync(id);
            return RedirectToAction("Index");


        }
       

    }
}
