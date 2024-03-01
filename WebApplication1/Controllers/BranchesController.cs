using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repos;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class BranchesController:Controller
    {
        private IBranchRepo BranchRepo { get; }

        public BranchesController(IBranchRepo branchRepo)
        {
            this.BranchRepo = branchRepo;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            return View(this.BranchRepo.GetAll());
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.branches = BranchRepo.getGovernates();
            return View();
        }
        [HttpPost]
        public IActionResult New(BranchViewModel B)
        {
            if (ModelState.IsValid)
            {
                this.BranchRepo.Create(B);
                return RedirectToAction("Index");
            }
            return View(B);
        }
        public IActionResult Details(int id) => View(this.BranchRepo.GetById(id));
        
        public IActionResult Delete(int id)
        {
            this.BranchRepo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) => View(this.BranchRepo.GetById(id));
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Branch branch)
        {
            if (ModelState.IsValid)
            {
                BranchRepo.Update(id, branch);
                return RedirectToAction("Index");
            }
            return View(branch);
        }
    }
}
