using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repos;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class OffersController : Controller
    {
        public IOffersRepo OffersRepo { get; }
        public IPackageRepo PackageRepo { get; }

        public OffersController(IOffersRepo _offersRepo, IPackageRepo _packageRepo)
        {
            OffersRepo = _offersRepo;
            PackageRepo = _packageRepo;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            List<Offer> offers = OffersRepo.GetAll();
            return View(offers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            Offer offer = OffersRepo.GetById(id);
            return View(offer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            OffersViewModel offersView = new OffersViewModel();
            return View(offersView);
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OffersViewModel offersView)
        {
            if (ModelState.IsValid)
            {
                decimal price = PackageRepo.GetById(offersView.PackageId).Price;
                try
                {
                    if (offersView.Percentage)
                    {
                        offersView.Discount = (offersView.Discount * price) / 100;
                    }
                    else
                    {
                        offersView.Discount = (price - offersView.Discount);
                    }
                    OffersRepo.Create(offersView);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(offersView);
                }
            }
            return View(offersView);
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {

            Offer offer = OffersRepo.GetById(id);

            offer.Package = PackageRepo.GetById(id);
            OffersViewModel offersViewModel = new OffersViewModel()
            {
                OfferName = offer.Name,
                Discount = offer.Discount,
                PackageId = (int)offer.PackageId,
                Duration = offer.Duration,
                Cancel = offer.Cancel
            };
            return View(offersViewModel);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OffersViewModel offersView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OffersRepo.Update(id, offersView);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(offersView);
                }
            }
            return View(offersView);
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            OffersRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
