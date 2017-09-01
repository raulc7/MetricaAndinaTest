using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RepositoryLibrary;
using BusinessEntity;

namespace WebAPIXmlResult.Controllers
{
    public class BranchController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<BranchBE> GetBranchListByBank(int id)
        {
            var BranchList = new BranchRepository().GetAllBranch(id);
            return BranchList.ToList();
        }
    }
}