using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeachTask.DataDB;
using TeachTask.Models;

namespace TeachTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TeachDBContext _teachDBContext;

        public HomeController(ILogger<HomeController> logger, TeachDBContext teachDBContext)
        {
            _logger = logger;
            _teachDBContext = teachDBContext;
        }

        public IActionResult Index()
        {
            DigitalImageModels digitalImageModels = new DigitalImageModels();
            digitalImageModels.DigitalImageList = new List<Models.DigitalImage>();
            var data = _teachDBContext.DigitalImages.ToList();
            foreach (var digitalImage in data)
            {
                digitalImageModels.DigitalImageList.Add(new Models.DigitalImage
                {
                    DigitalImagesId = digitalImage.DigitalImageId,
                    GraphicProductId = digitalImage.GraphicProductId,
                    ResourcesId=digitalImage.ResourceId
                });
            }
            return View(digitalImageModels);
        }


        [HttpGet]
        public IActionResult Save()
        {
            Models.DigitalImage digitalImage = new Models.DigitalImage();
            return View(digitalImage);
            //return View();
        }
        [HttpPost]
        public IActionResult Save(Models.DigitalImage digitalImage)
        {
            try
            {
                var digitalImageData = new DataDB.DigitalImage()
                {
                    ResourceId = digitalImage.ResourcesId,
                    GraphicProductId = digitalImage.GraphicProductId

                };
                _teachDBContext.DigitalImages.Add(digitalImageData);
                _teachDBContext.SaveChanges();
                TempData["SaveStatus"] = 1;
            }
            catch (Exception ex)
            {
                TempData["SaveStatus"] = 0;
            }
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}