using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;
using WebApplication1.Models;
using WebApplication1.Repos;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: CustomersController

        private IEmployeeRebo EmpRebo;
        private IBranchRepo BranchRepo;

        public EmployeesController(IEmployeeRebo _EmpRebo,IBranchRepo branchRepo)
        {
            this.EmpRebo = _EmpRebo;    
            this.BranchRepo = branchRepo;
        }
       
        public ActionResult Index()
        {
            var All= EmpRebo.GetAll();

            return View(All);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {

            var _EmpRebos = EmpRebo.GetById(id);


            return View(_EmpRebos);
        }

        // GET: CustomersController/Create


        [HttpGet]
        public ActionResult Create()
        {
            //open form only
            ViewBag.branchlist = BranchRepo.GetAll();
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(E Emp)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        Employee Emp = new Employee();
        //        Emp.Name = EmpViewModel.UserName;
                
        //        return RedirectToAction("Index");
        //    }



        //    return View(EmpViewModel);
        //}






        public ActionResult Create(Employee Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                   EmpRebo.Create(Emp);

                    EmpRebo.Save();

                    return RedirectToAction("Index");
                }
                //  return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "checkerror");

            }
            return View(Emp);
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
           var EmpED = EmpRebo.GetById(id);
            ViewBag.branchlist = BranchRepo.GetAll();

            return View(EmpED);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee _Employee)
        {
            if (ModelState.IsValid)
            {
                var Emp = EmpRebo.Update(id,_Employee);
                EmpRebo.Save();
                return RedirectToAction("Index");
            }

            return View(_Employee);
           
        }

        // GET: CustomersController/Delete/5
     
        public IActionResult Delete(int id)
        {
            EmpRebo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
