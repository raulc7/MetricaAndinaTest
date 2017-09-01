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
    public class PaymentOrderController : Controller
    {
        PaymentOrderRepository paymentOrderRep = new PaymentOrderRepository();
        BranchRepository branchRep = new BranchRepository();
        BankRepository bankRep = new BankRepository();

        // GET: /PaymentOrder/
        [HttpGet]
        public ActionResult Index()
        {
            var paymentOrderList = paymentOrderRep.GetAllPaymentOrder(0);

            return View(paymentOrderList.ToList());
        }

        // GET: /PaymentOrder/GetCurrencyList
        [HttpGet]
        public ActionResult GetCurrencyList()
        {
            var currencyList = paymentOrderRep.GetAllCurrency();

            return View(currencyList.ToList());
        }

        [HttpGet]
        public ActionResult GetPaymentOrderList(int id)
        {
            IEnumerable<PaymentOrderBE> paymentOrderList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:15005/api/");

                var responseTask = client.GetAsync("PaymentOrder/GetPaymentOrderListByCurrency/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PaymentOrderBE>>();
                    readTask.Wait();

                    paymentOrderList = readTask.Result;
                }
                else
                {                    
                    paymentOrderList = Enumerable.Empty<PaymentOrderBE>();

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(paymentOrderList);
        }

        // GET: /PaymentOrder/Create
        [HttpGet]
        public ActionResult Create()
        {
            PaymentOrderBE paymentOrder = new PaymentOrderBE();
            
            ViewBag.Branch = branchRep.GetAllBranch(0).ToList();
            ViewBag.Currency = paymentOrderRep.GetAllCurrency().ToList();
            ViewBag.PaymentState = paymentOrderRep.GetAllPaymentState().ToList();
            return View(paymentOrder);
        }

        // POST: /PaymentOrder/Create
        [HttpPost]
        public ActionResult Create(PaymentOrderBE paymentOrder, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) return View(paymentOrder);
                
                paymentOrder.BranchId = Convert.ToInt32(collection["Branch"].ToString());
                paymentOrder.CurrencyId = Convert.ToInt32(collection["Currency"].ToString());
                paymentOrder.PaymentStateId = Convert.ToInt32(collection["PaymentState"].ToString());
                paymentOrderRep.AddPaymentOrder(paymentOrder);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /PaymentOrder/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PaymentOrderBE paymentOrder = paymentOrderRep.GetAllPaymentOrder(0).Find(x => x.Id == id);

            ViewBag.Branch = branchRep.GetAllBranch(0).ToList();
            ViewBag.Currency = paymentOrderRep.GetAllCurrency().ToList();
            ViewBag.PaymentState = paymentOrderRep.GetAllPaymentState().ToList();
            return View(paymentOrder);
        }

        // POST: /PaymentOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(PaymentOrderBE paymentOrder, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) return View(paymentOrder);

                paymentOrder.BranchId = Convert.ToInt32(collection["Branch"].ToString());
                paymentOrder.CurrencyId = Convert.ToInt32(collection["Currency"].ToString());
                paymentOrder.PaymentStateId = Convert.ToInt32(collection["PaymentState"].ToString());
                paymentOrderRep.UpdatePaymentOrder(paymentOrder);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /PaymentOrder/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            PaymentOrderBE paymentOrder = paymentOrderRep.GetAllPaymentOrder(0).Find(x => x.Id == id);
            return View(paymentOrder);
        }

        // POST: /PaymentOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(PaymentOrderBE paymentOrder)
        {
            try
            {
                if (!ModelState.IsValid) return View(paymentOrder);

                paymentOrderRep.DeletePaymentOrder(paymentOrder.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
