using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Repos;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class PackagesController : Controller
    {
        readonly IPackageRepo packageRepo;
        readonly IServiceProviderRepo serviceProviderRepo;

        public PackagesController(IPackageRepo _packageRepo, IServiceProviderRepo _serviceProviderRepo)
        {
            this.packageRepo = _packageRepo; this.serviceProviderRepo = _serviceProviderRepo;
        }

        // GET: CustomersController
        public ActionResult Index()
        {

            List<Package> packages = packageRepo.GetAll();
            List<PackagesViewModel> list = new List<PackagesViewModel>();
            list = packages.Select(p => new PackagesViewModel { Name = p.Name, Limited = p.Limited, Price = p.Price, Id = p.Id, ProviderId = p.ProviderId }).ToList();

            return View(list);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            Package package = packageRepo.GetById(id);
            PackagesViewModel packagesView = new PackagesViewModel
            {
                Id = package.Id,
                Name = package.Name,
                Limited = package.Limited,
                Price = package.Price,
                //  ProviderName = package.ServiceProvider.Name
            };
            return View(packagesView);
        }
        [HttpGet]
        public ActionResult Create()
        {
            PackagesViewModel packagesViewModel = new PackagesViewModel();
            packagesViewModel.ProviderName = serviceProviderRepo.GetAll();
            return View(packagesViewModel);
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PackagesViewModel packagesView)
        {
            if (ModelState.IsValid)
            {
                Package package = new Package
                {
                    Name = packagesView.Name,
                    Limited = packagesView.Limited,
                    Price = packagesView.Price,
                    ProviderId = packagesView.ProviderId,
                };
                try
                {
                    packageRepo.Create(package);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(packagesView);
        }


        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            Package package = packageRepo.GetById(id);
            PackagesViewModel packagesView = new PackagesViewModel
            {
                Name = package.Name,
                Price = package.Price,
                Limited = package.Limited,
                ProviderId = package.ProviderId,
                ProviderName = serviceProviderRepo.GetAll()
            };
            return View(packagesView);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PackagesViewModel packagesView)
        {
            if (ModelState.IsValid)
            {
                Package package = new Package
                {
                    Name = packagesView.Name,
                    Price = packagesView.Price,
                    Limited = packagesView.Limited,
                    ProviderId = packagesView.ProviderId


                };
                try
                {
                    packageRepo.Update(id, package);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(packagesView);
                }

            }
            return View(packagesView);

        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            packageRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

