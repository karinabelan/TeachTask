using Microsoft.AspNetCore.Mvc;
using TeachTask.DataDB;
using TeachTask.Models;

namespace TeachTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private TeachDBContext _teachDBContext;

        public ProductController(ILogger<ProductController> logger, TeachDBContext teachDBContext)
        {
            _logger = logger;
            _teachDBContext = teachDBContext;
        }
        public IActionResult Index()
        {
            GraphicProductModels graphicProductModels = new GraphicProductModels();
            graphicProductModels.GraphicProductsList = new List<Models.GraphicProduct>();
            var data1 = _teachDBContext.GraphicProducts.ToList();
            foreach (var graphicProduct in data1)
            {
                graphicProductModels.GraphicProductsList.Add(new Models.GraphicProduct
                {
                    GraphicProductId = graphicProduct.GraphicProductId,
                    Name = graphicProduct.Name,
                    Email = graphicProduct.Email

                });
            }
            return View(graphicProductModels);
        }

        [HttpGet]
        public IActionResult Save()
        {
            Models.GraphicProduct graphicProduct = new Models.GraphicProduct();
            return View(graphicProduct);
            //return View();
        }
        [HttpPost]
        public IActionResult Save(Models.GraphicProduct graphicProduct)
        {
            try
            {
                var graphicProductData = new DataDB.GraphicProduct()
                {
                    Name = graphicProduct.Name,
                    Email = graphicProduct.Email
                };
                _teachDBContext.GraphicProducts.Add(graphicProductData);
                _teachDBContext.SaveChanges();
                TempData["SaveStatus"] = 1;
            }
            catch (Exception ex)
            {
                TempData["SaveStatus"] = 0;
            }
            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public IActionResult Delete(int Id = 0)
        {
            try
            {
                var data = _teachDBContext.GraphicProducts.Where(m => m.GraphicProductId == Id).FirstOrDefault();
                if (data != null)
                {
                    _teachDBContext.GraphicProducts.Remove(data);
                    _teachDBContext.SaveChanges();
                }
                TempData["DeleteStatus"] = 1;
            }
            catch
            {
                TempData["DeleteStatus"] = 0;
            }
            return RedirectToAction("Index", "Product");
        }

    }
}
