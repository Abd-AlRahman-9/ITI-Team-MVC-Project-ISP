using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repos;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ServiceProvidersController : Controller
    {
        private IServiceProviderRepo serviceProviderRepo;

        public ServiceProvidersController(IServiceProviderRepo _serviceProviderRepo)
        {
            this.serviceProviderRepo = _serviceProviderRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            List<InternetServiceProvider> providers = serviceProviderRepo.GetAll();
            return View(providers);
        }
        public IActionResult Details(int id)
        {
            InternetServiceProvider serviceProvider = serviceProviderRepo.GetById(id);
            return View(serviceProvider);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(ServiceProviderViewModel providerViewModel)
        {
            if (ModelState.IsValid)
            {
                InternetServiceProvider serviceProvider = new();
                serviceProvider.Name = providerViewModel.Name;
                serviceProviderRepo.Create(serviceProvider);
                return RedirectToAction("Index");
            }
            return View(providerViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            InternetServiceProvider serviceProvider = serviceProviderRepo.GetById(id);
            return View(serviceProvider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, InternetServiceProvider provider)
        {
            if (ModelState.IsValid)
            {
                serviceProviderRepo.Update(id, provider);
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        public IActionResult Delete(int id)
        {
            serviceProviderRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}