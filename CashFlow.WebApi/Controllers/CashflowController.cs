using CashFlow.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CashFlow.WebApi.Controllers
{
    [Authorize]
    public class CashflowController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var service = CreateCashflowService();
            var netWorth = service.GetNetWorth(id);
            return Ok(netWorth);
 
        }

        private CashFlowServices CreateCashflowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new CashFlowServices(userId);
        }
        
    }
}
