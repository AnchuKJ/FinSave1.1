using Microsoft.AspNetCore.Mvc;
using FinSaveAPI.DataAccess;
using FinSaveAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using FinSaveAPI.DTO;

namespace FinSaveAPI.Services
{
    public class CampaignService
    {
        private MongoDbservice _dbService;
        public CampaignService(MongoDbservice dbAccess)
        {
            _dbService = dbAccess;
        }

        public async Task<ActionResult> LoginUser(UserModel user)
        {
            var slotList = await _dbService.GetUsersCollection().FindAsync(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password));
            UserDetails dtls = new UserDetails();
            var usid = slotList.FirstOrDefault();
            //    var refDocument = new BsonDocument {
            //    {"$ref", "Accounts"},
            //    {"$id", usid._id}
            //};
            //    var query = Query.EQ("usr", refDocument);
            //    var result = await _dbService.GetAccountsCollection().FindOne(query);


            var accList = await _dbService.GetAccountsCollection().FindAsync(x => x.UserId.Equals(usid.UId));
            dtls.Accounts = accList.ToList();
            //dtls.userId = usid._id;
            dtls.userId = usid.UId;
            dtls.username = usid.UserName;
            return new OkObjectResult(dtls);
        }

        public async Task<ActionResult> CreateUser(UserModel userData)
        {
            if (userData != null)
            {
                var filter = Builders<UserModel>.Filter.Where(x => x.UserName.Equals(userData.UserName));
                var slotList = (await _dbService.GetUsersCollection().FindAsync(filter)).FirstOrDefault();
                if (slotList == null)
                {
                    int cnt = (int)(await _dbService.GetUsersCollection().CountDocumentsAsync(x => true));
                    userData.UId = cnt + 1;
                    await _dbService.GetUsersCollection().InsertOneAsync(userData);
                    return new OkResult();
                }

            }
            return null;
        }

        public async Task<ActionResult> CreateAccount(AccountsModel accData)
        {
            if (accData != null)
            {

                //var slotList1 = await _dbService.GetUsersCollection().FindAsync(x=>x.UserName.Equals("Manu"));
                //var usid = slotList1.FirstOrDefault();
                //MongoDBRef usrRef = new MongoDBRef("Users", usid._id);
                //accData.UserId = usrRef;
                var filter = Builders<AccountsModel>.Filter.Where(x => x.AccName.Equals(accData.AccName));
                var slotList = (await _dbService.GetAccountsCollection().FindAsync(filter)).FirstOrDefault();
                if (slotList == null)
                {
                    int cnt = (int)(await _dbService.GetAccountsCollection().CountDocumentsAsync(x => true));
                    accData.AccId = cnt + 1;
                    await _dbService.GetAccountsCollection().InsertOneAsync(accData);
                    return new OkResult();
                }

            }
            return null;
        }

        public async Task<ActionResult> GetDashboardContent()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> CreateCampaign(CampaignRequest campaignData)
        {
            if (campaignData != null)
            {
                var filter = Builders<CampaignModel>.Filter.Where(x => x.CapaignName.Equals(campaignData.CampaignName));
                var slotList = (await _dbService.GetCampaignCollection().FindAsync(filter)).FirstOrDefault();
                if (slotList == null)
                {
                    int cnt = (int)(await _dbService.GetCampaignCollection().CountDocumentsAsync(x => true));
                    var newCampaign = new CampaignModel
                    {
                        CampId = cnt + 1,
                        CapaignName = campaignData.CampaignName,
                        CampaignDesc = campaignData.CampaignDesc,
                        TargetAmount = campaignData.TargetAmount,
                        CreatedDt = DateTime.Now,
                        ExpiryDt = Convert.ToDateTime(campaignData.ExpiryDt),
                        StartDt = Convert.ToDateTime(campaignData.StartDt),
                        MemCount = 0
                    };
                    await _dbService.GetCampaignCollection().InsertOneAsync(newCampaign);
                    return new OkResult();
                }

            }
            return null;
        }

        public async Task<ActionResult> GetAllCampaigns(int UserId)
        {

            var usrcampaigns = _dbService.GetUserCampaignCollection().AsQueryable().Select(st => st.CampaignID).Distinct().ToList();
            var campaigns = _dbService.GetCampaignCollection().AsQueryable();
            var leftOuter = campaigns.Where(stA => !usrcampaigns.Contains(stA.CampId)).OrderByDescending(x=>x.CampId);
            return new OkObjectResult(leftOuter.ToList());
        }
        public async Task<ActionResult> JoinCampaign(UserCampaignsModel usrcampaign)
        {
            if (usrcampaign != null)
            {
                var filter = Builders<UserCampaignsModel>.Filter.Where(x => x.UserID.Equals(usrcampaign.UserID) && x.CampaignID.Equals(usrcampaign.CampaignID));
                var slotList = (await _dbService.GetUserCampaignCollection().FindAsync(filter)).FirstOrDefault();
                if (slotList == null)
                {
                    int cnt = (int)(await _dbService.GetUserCampaignCollection().CountDocumentsAsync(x => true));
                    usrcampaign.UCID = cnt + 1;
                    usrcampaign.UserContribution = 0;
                    await _dbService.GetUserCampaignCollection().InsertOneAsync(usrcampaign);

                    var filter1 = Builders<CampaignModel>.Filter.Where(x => x.CampId.Equals(usrcampaign.CampaignID));
                    var slotList1 = (await _dbService.GetCampaignCollection().FindAsync(filter1)).FirstOrDefault();
                    int mbrCount = slotList1.MemCount + 1;
                    var updacc = Builders<CampaignModel>.Update.Set("MemCount", mbrCount);
                    await _dbService.GetCampaignCollection().UpdateOneAsync(filter1, updacc);
                    return new OkResult();
                }
            }
            return null;
        }

        public async Task<ActionResult> GetActiveGoals(int UserId)
        {
            var campaigns = (from p in _dbService.GetUserCampaignCollection().AsQueryable().Where(x => x.UserID.Equals(UserId))
                             join q in _dbService.GetCampaignCollection().AsQueryable() on p.CampaignID equals q.CampId
                             select new ActiveGoalModel
                             {
                                 Goalname = q.CapaignName,
                                 desc = q.CampaignDesc,
                                 amount = q.TargetAmount,
                                 collectedamount = q.AchievedAmount,
                                 expires = q.ExpiryDt,
                                 memberscount = q.MemCount,
                                 createdon = q.CreatedDt,
                                 contributionamount = p.UserContribution,
                                 contributionpercent = (p.UserContribution / p.MaxContribution) * 100
                             }).ToList();
            return new OkObjectResult(campaigns.ToList().OrderByDescending(x=>x.createdon));
        }
        public async Task<ActionResult> PerformTransaction(TransactionModel transact)
        {
            if (transact != null)
            {
                var filter = Builders<AccountsModel>.Filter.Where(x => x.AccNum.Equals(transact.AccNum));
                var slotList = (await _dbService.GetAccountsCollection().FindAsync(filter)).FirstOrDefault();
                var campfilter = Builders<UserCampaignsModel>.Filter.Where(x => x.UserID.Equals(slotList.UserId));
                var campaignList = (await _dbService.GetUserCampaignCollection().FindAsync(campfilter)).FirstOrDefault();
                if (slotList != null)
                {
                    double newBal = slotList.Balance - transact.Amount;
                    double roundAmt = newBal % campaignList.RoundTo;
                    double SaveAmt = newBal - roundAmt;
                    double CampAmt = campaignList.UserContribution + roundAmt;
                    var updfilter = Builders<UserCampaignsModel>.Filter.Where(x => x.UCID.Equals(campaignList.UCID));
                    var updDef = Builders<UserCampaignsModel>.Update.Set("UserContribution", CampAmt);
                    await _dbService.GetUserCampaignCollection().UpdateOneAsync(updfilter, updDef);
                    var updacc = Builders<AccountsModel>.Update.Set("Balance", SaveAmt);
                    await _dbService.GetAccountsCollection().UpdateOneAsync(filter, updacc);

                    var campfilt = Builders<CampaignModel>.Filter.Where(x => x.CampId.Equals(campaignList.CampaignID));
                    var campaign = (await _dbService.GetCampaignCollection().FindAsync(campfilt)).FirstOrDefault();
                    double AchvAmt = campaign.AchievedAmount + roundAmt;
                    var updDef1 = Builders<CampaignModel>.Update.Set("AchievedAmount", AchvAmt);
                    await _dbService.GetCampaignCollection().UpdateOneAsync(campfilt, updDef1);
                    return new OkResult();
                }
            }
            return null;
        }
        public async Task<ActionResult> GetUserAccounts(int UserId)
        {
            var filter = Builders<AccountsModel>.Filter.Where(x => x.UserId.Equals(UserId));
            var slotList = (await _dbService.GetAccountsCollection().FindAsync(filter)).ToList();
            return new OkObjectResult(slotList);
        }

        public async Task<ActionResult> AdminDashboard()
        {
            var campaign = _dbService.GetCampaignCollection().AsQueryable();
            int activecampaigns = (from p in campaign.Where(x => x.Status.Equals(1)) select p.CampId).Count();
            int completedcampaigns = (from p in campaign.Where(x => x.ExpiryDt > DateTime.Now) select p.CampId).Count();
            var recentcampaigns = campaign.ToList();

            List<RecentCampaigns> recent = new List<RecentCampaigns>();
            foreach (CampaignModel model in recentcampaigns)
            {
                RecentCampaigns camp = new RecentCampaigns();
                camp.name = model.CapaignName;
                camp.series = new List<SeriesData>();
                camp.series.Add(new SeriesData() { name = "Raised fund", value = model.AchievedAmount });
                camp.series.Add(new SeriesData() { name = "Goal Amount", value = model.TargetAmount });
                recent.Add(camp);
            }
            var pieTbl = (from p in campaign.Where(x => true) select p).ToList();
            List<SeriesData> ser = new List<SeriesData>();
            double trg = pieTbl.Sum(x => x.TargetAmount);
            double ach = pieTbl.Sum(x => x.AchievedAmount);
            ser.Add(new SeriesData() { name = "Target Amount", value = trg });
            ser.Add(new SeriesData() { name = "Raised Fund", value = ach });
            ser.Add(new SeriesData() { name = "Fund to raise", value = trg - ach });
            AdminDashboardResponse adm = new AdminDashboardResponse()
            {
                activecampaigns = activecampaigns,
                completedcampaigns = completedcampaigns,
                recentcampaigns = recent,
                piedata = ser
            };

            return new OkObjectResult(adm);
        }
    }
}
