using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RepositoryLibrary;
using BusinessEntity;

namespace WebAPIJsonResult.Controllers
{
    public class PaymentOrderController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<PaymentOrderBE> GetPaymentOrderListByCurrency(int id)
        {
            var paymentOrderList = new PaymentOrderRepository().GetAllPaymentOrder(id);
            return paymentOrderList.ToList();
        }
    }
}