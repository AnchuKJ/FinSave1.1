using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinSaveAPI.DataAccess;
using FinSaveAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinSaveAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountService accountService { get; set; }
        public AccountController(MongoDbservice dbService)
        {
            accountService = new AccountService(dbService);
        }
    }
}
