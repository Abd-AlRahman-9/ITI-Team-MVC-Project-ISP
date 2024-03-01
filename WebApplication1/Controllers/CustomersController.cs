using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repos;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepo CustomerRepo { get; }
        private IPackageRepo PackageRepo { get; }
        private IBranchRepo BranchRepo { get; }
        private IOffersRepo offersRepo { get; }
        private IServiceProviderRepo ServiceProviderRepo { get; }

        public CustomersController(ICustomerRepo customerRepo, IBranchRepo branchRepo , IPackageRepo packageRepo , IOffersRepo offersRepo , IServiceProviderRepo serviceProviderRepo)
        {
            this.CustomerRepo = customerRepo;
            //this.BranchRepo = branchRepo;
            this.PackageRepo = packageRepo;
            this.offersRepo = offersRepo;
            this.ServiceProviderRepo = serviceProviderRepo; 

        }
        // GET: CustomersController
        public ActionResult Index()
        {
           
            var customers = CustomerRepo.GetAll();
            return View(customers);
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.packagelist = PackageRepo.GetAll();
            ViewBag.servicelist = ServiceProviderRepo.GetAll();



            return View();
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
        public  IActionResult Edit(int id)
        {
            var customer = CustomerRepo.GetById(id);
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                Name = customer.Name,
                Adress = customer.Address,
                Phone = customer.Phone,
                //Package = customer.Package.Name,

        };
            //ViewBag.branchlist = BranchRepo.GetAll();
            ViewBag.packagelist = PackageRepo.GetAll();
            ViewBag.offerlist = offersRepo.GetAll();
            ViewBag.servicelist = ServiceProviderRepo.GetAll();

            return View(customerViewModel);

        }
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
