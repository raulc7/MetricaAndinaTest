using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RepositoryLibrary;
using BusinessEntity;

namespace MvcApplication.Controllers
{
    public class BranchController : Controller
    {
        BranchRepository branchRep = new BranchRepository();
        BankRepository bankRep = new BankRepository();

        // GET: /Branch/
        [HttpGet]
        public ActionResult Index()
        {
            var branchList = branchRep.GetAllBranch(0);

            return View(branchList.ToList());
        }

        // GET: /Branch/Create
        [HttpGet]
        public ActionResult Create()
        {
            BranchBE branch = new BranchBE();
            //
            ViewBag.Bank = bankRep.GetAllBank().ToList();
            return View(branch);
        }

        // POST: /Branch/Create
        [HttpPost]
        public ActionResult Create(BranchBE branch, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) return View(branch);
                
                branch.BankId = Convert.ToInt32(collection["Bank"].ToString());
                branchRep.AddBranch(branch);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Branch/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BranchBE branch = branchRep.GetAllBranch(0).Find(x => x.Id == id);
            ViewBag.Bank = bankRep.GetAllBank().ToList();
            return View(branch);
        }

        // POST: /Branch/Edit/5
        [HttpPost]
        public ActionResult Edit(BranchBE branch, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) return View(branch);

                branchRep.UpdateBranch(branch);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Branch/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BranchBE branch = branchRep.GetAllBranch(0).Find(x => x.Id == id);
            return View(branch);
        }

        // POST: /Branch/Delete/5
        [HttpPost]
        public ActionResult Delete(BranchBE branch)
        {
            try
            {
                if (!ModelState.IsValid) return View(branch);

                branchRep.DeleteBranch(branch.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                branch = branchRep.GetAllBranch(0).Find(x => x.Id == branch.Id);
                return View(branch);
            }
        }
    }
}
