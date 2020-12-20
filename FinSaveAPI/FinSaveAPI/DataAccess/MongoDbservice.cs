using MongoDB.Driver;
using FinSaveAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinSaveAPI.DataAccess
{
    public class MongoDbservice
    {
        private IMongoDatabase mongoDBClient;
		//private IMongoCollection<UserRegistrationModel> _registrationCollection;

		public MongoDbservice()
		{
			try
			{
				var datasource = "FinSave";
				var mongoUrl = "mongodb://localhost:27017";
				MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(mongoUrl));
				MongoClient client = new MongoClient(settings);
				mongoDBClient = client.GetDatabase(datasource);
			}
			catch { }
		}

		public IMongoDatabase GetMongoClient()
		{
			return mongoDBClient;
		}
		private string _UsersCollectionName = "Users";
		private string _CampaignCollectionName = "Campaigns";
		private string _AccountsCollectionName = "Accounts";
		private string _UserCampaignCollectionName = "UserCampaign";
		private IMongoCollection<UserModel> _usersCollection;
		private IMongoCollection<CampaignModel> _CampaignsCollection;
		private IMongoCollection<AccountsModel> _AccountsCollection;
		private IMongoCollection<UserCampaignsModel> _UserCampaignCollection;

		public IMongoCollection<UserModel> GetUsersCollection()
		{
			if (_usersCollection == null)
			{
				_usersCollection = mongoDBClient.GetCollection<UserModel>(_UsersCollectionName);
				//var filter = Builders<UserModel>.Filter.Where(x => true);
				//_usersCollection.DeleteManyAsync(filter);
			}

			return _usersCollection;
		}
		public IMongoCollection<CampaignModel> GetCampaignCollection()
		{
			if (_CampaignsCollection == null)
			{
				_CampaignsCollection = mongoDBClient.GetCollection<CampaignModel>(_CampaignCollectionName);
			}

			return _CampaignsCollection;
		}
		public IMongoCollection<AccountsModel> GetAccountsCollection()
		{
			if (_AccountsCollection == null)
			{
				_AccountsCollection = mongoDBClient.GetCollection<AccountsModel>(_AccountsCollectionName);
               // var filter = Builders<AccountsModel>.Filter.Where(x => true);
                //_AccountsCollection.DeleteManyAsync(filter);
            }

			return _AccountsCollection;
		}
		public IMongoCollection<UserCampaignsModel> GetUserCampaignCollection()
		{
			if (_UserCampaignCollection == null)
			{
				_UserCampaignCollection = mongoDBClient.GetCollection<UserCampaignsModel>(_UserCampaignCollectionName);
			}

			return _UserCampaignCollection;
		}

	}
}
