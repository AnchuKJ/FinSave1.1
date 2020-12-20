using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinSaveAPI.DataAccess;
using FinSaveAPI.Model;
using FinSaveAPI.Services;
using FinSaveAPI.DTO;

namespace FinSaveAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        CampaignService campaignService { get; set; }
        public CampaignController(MongoDbservice dbService)
        {
            campaignService = new CampaignService(dbService);
        }

        [HttpPost]
        [Route("bank/LoginUser")]
        public async Task<ActionResult> LoginUser(UserModel user)
        {
            return await campaignService.LoginUser(user);
        }

        [HttpPost]
        [Route("bank/CreateUser")]
        public async void CreateUser(UserModel userData)
        {
            await campaignService.CreateUser(userData);
        }

        [HttpPost]
        [Route("bank/CreateAccount")]
        public async void CreateAccount(AccountsModel accData)
        {
            await campaignService.CreateAccount(accData);
        }

        [HttpPost]
        [Route("bank/CreateCampaign")]
        public async void CreateCampaign(CampaignRequest campaign)
        {
            await campaignService.CreateCampaign(campaign);
        }

        [HttpPost]
        [Route("bank/JoinCampaign")]
        public async void JoinCampaign(UserCampaignsModel campaign)
        {
            await campaignService.JoinCampaign(campaign);
        }

        [HttpGet]
        [Route("bank/GetActiveGoals/{userId}")]
        public async Task<ActionResult> GetActiveGoals(int userId)
        {
            return await campaignService.GetActiveGoals(userId);
        }
        [HttpGet]
        [Route("bank/GetAllCampaigns/{userId}")]
        public async Task<ActionResult> GetAllCampaigns(int userId)
        {
            return await campaignService.GetAllCampaigns(userId);
        }

        [HttpGet]
        [Route("bank/GetDashboardContent")]
        public async Task<ActionResult> GetDashboardContent()
        {
            return await campaignService.GetDashboardContent();
        }
        [HttpPost]
        [Route("bank/PerformTransaction")]
        public async Task<ActionResult> PerformTransaction(TransactionModel transact)
        {
            return await campaignService.PerformTransaction(transact);
        }

        [HttpGet]
        [Route("bank/GetUserAccounts/{userId}")]
        public async Task<ActionResult> GetUserAccounts(int userId)
        {
            return await campaignService.GetUserAccounts(userId);
        }

        [HttpGet]
        [Route("bank/AdminDashboard")]
        public async Task<ActionResult> AdminDashboard()
        {
            return await campaignService.AdminDashboard();
        }

    }
}
