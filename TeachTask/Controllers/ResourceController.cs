using Microsoft.AspNetCore.Mvc;
using TeachTask.DataDB;
using TeachTask.Models;

namespace TeachTask.Controllers
{
    public class ResourceController : Controller
    {
        private readonly ILogger<ResourceController> _logger;
        private TeachDBContext _teachDBContext;

        public ResourceController(ILogger<ResourceController> logger, TeachDBContext teachDBContext)
        {
            _logger = logger;
            _teachDBContext = teachDBContext;
        }
        public IActionResult Index()
        {
            ResourceModels resourceModels = new ResourceModels();
            resourceModels.ResourceList = new List<Models.Resource>();
            var data = _teachDBContext.Resources.ToList();
            foreach (var resource in data)
            {
                resourceModels.ResourceList.Add(new Models.Resource
                {
                    ResourcesId = resource.ResourceId,
                    PrimaryId = resource.PrimaryId,
                    SecondaryId = resource.SecondaryId
                });
            }
            return View(resourceModels);
        }
        public IActionResult PrimarySecondary()
        {
            PrimarySecondaryModels primarySecondaryModels = new PrimarySecondaryModels();
            primarySecondaryModels.PrimarySecondaryList = new List<Models.PrimarySecondary>();
            var data = _teachDBContext.PrimarySecondaries.ToList();
            foreach (var primarySecondary in data)
            {
                primarySecondaryModels.PrimarySecondaryList.Add(new Models.PrimarySecondary
                {
                    PrimaryId = primarySecondary.PrimaryId,
                    Address = primarySecondary.Address,
                    SecondaryId = primarySecondary.SecondaryId,
                    NamePhotographer = primarySecondary.NamePhotographer
                });
            }
            return View(primarySecondaryModels);
        }
    }
}
