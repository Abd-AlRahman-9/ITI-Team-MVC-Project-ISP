using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repos;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepo CustomerRepo { get; }

        public CustomersController(ICustomerRepo customerRepo)
        {
            this.CustomerRepo = customerRepo;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult New()
        {
            return View(CustomerRepo.getCustomers());
        }
        [HttpPost]
        public IActionResult New(CustomerViewModel C)
        {
            if (ModelState.IsValid)
            {
                this.CustomerRepo.Create(C);
                return RedirectToAction("Index");
            }
            return View(C);
        }
        public IActionResult Details(int id) => View(this.CustomerRepo.GetById(id));

        public IActionResult Delete(int id)
        {
            this.CustomerRepo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult All() => View(this.CustomerRepo.GetAll());

        [HttpGet]
        public IActionResult Edit(int id) => View(this.CustomerRepo.GetById(id));
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepo.Update(id, customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}
