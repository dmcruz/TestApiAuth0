using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TestApiAuth0.Data;
using TestApiAuth0.Repository;

namespace TestApiAuth0.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
         IAccountsRepository _repository;

        public AccountsController(IAccountsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [Authorize]
        [HttpGet]
        public IEnumerable<AccountModel> Get()
        {
            return _repository.GetAllAccounts();
        }

        [Authorize]
        [HttpGet("{id}")]
        public AccountModel Get(int id)
        {
            return _repository.GetAllAccounts().FirstOrDefault();
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody]AccountModel account)
        {
            _repository.AddAccount(account);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AccountModel account)
        {
            _repository.UpdateAccount(id, account);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteAccount(id);
        }
    }
}
