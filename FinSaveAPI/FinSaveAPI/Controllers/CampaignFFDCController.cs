using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FinSaveAPI.DTO;
using FinSaveAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FinSaveAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class CampaignFFDCController : ControllerBase
    {
        CampaingFFDCService campaignService { get; set; }
        public CampaignFFDCController()
        {
            campaignService = new CampaingFFDCService();
        }
        [Route("FFDC/ffdctoken")]
        public async Task<ActionResult> getFFDCToken()
        {
            string resp = await campaignService.GetFFDCTocken();
            return new OkObjectResult(resp);


        }

        [HttpPost]
        [Route("FFDC/PerformTransaction")]
        public async Task<ActionResult> PerformTransaction(string consumerId, TransactArgs transact)
        {
            return await campaignService.PerformTransaction(consumerId, transact);
        }

        [HttpGet]
        [Route("FFDC/GetUserAccounts/{userId}")]
        public async Task<ActionResult> GetUserAccounts(string userId)
        {
            return await campaignService.GetUserAccounts(userId);
        }

        [HttpGet]
        [Route("FFDC/GetUserTransactions/{userId}")]
        public async Task<ActionResult> GetUserTransactions(string from, string to, string accountId)
        {
            return await campaignService.GetUserTransactions(from, to, accountId);
        }
    }
}
