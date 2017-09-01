using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;
using RepositoryLibrary;
using BusinessEntity;

namespace MvcApplication.Controllers
{
    public class BankController : Controller
    {
        BankRepository bankRep = new BankRepository();

        // GET: /Bank/
        [HttpGet]
        public ActionResult Index()
        {
            var bankList = bankRep.GetAllBank();

            return View(bankList.ToList());
        }

        // GET: /Bank/GetBranchList
        [HttpGet]
        public ActionResult GetBranchList(int id)
        {
            IEnumerable<BranchBE> branchList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:16246/api/");
                
                var responseTask = client.GetAsync("Branch/GetBranchListByBank/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BranchBE>>();
                    readTask.Wait();

                    branchList = readTask.Result;
                }
                else
                {
                    branchList = Enumerable.Empty<BranchBE>();

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(branchList);
        }

        // GET: /Bank/Create
        [HttpGet]
        public ActionResult Create()
        {
            BankBE bank = new BankBE();
            return View(bank);
        }

        // POST: /Bank/Create
        [HttpPost]
        public ActionResult Create(BankBE bank)
        {
            try
            {
                if (!ModelState.IsValid) return View(bank);

                bankRep.AddBank(bank);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Bank/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BankBE bank = bankRep.GetAllBank().Find(x => x.Id == id);
            return View(bank);
        }

        // POST: /Bank/Edit/5
        [HttpPost]
        public ActionResult Edit(BankBE bank)
        {
            try
            {
                if (!ModelState.IsValid) return View(bank);

                bankRep.UpdateBank(bank);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Bank/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BankBE bank = bankRep.GetAllBank().Find(x => x.Id == id);
            return View(bank);
        }

        // POST: /Bank/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(BankBE bank)
        {
            try
            {
                if (!ModelState.IsValid) return View(bank);

                bankRep.DeleteBank(bank.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                bank = bankRep.GetAllBank().Find(x => x.Id == bank.Id);
                return View(bank);
            }
        }

    }
}
