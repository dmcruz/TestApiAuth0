using System.Linq;
using System.Collections.Generic;
using TestApiAuth0.Data;

namespace TestApiAuth0.Repository
{
    public interface IAccountsRepository 
    {
        IList<AccountModel> GetAllAccounts();
        int AddAccount(AccountModel account);
        AccountModel GetAccountById(int id);
        void UpdateAccount(int id, AccountModel account);
        void DeleteAccount(int id);
    }

    public class AccountsRepository : IAccountsRepository
    {
        AccountsDbContext _context;

        public AccountsRepository(AccountsDbContext context) {
            _context = context;
        }
        public IList<AccountModel> GetAllAccounts() {
            return _context.Accounts.ToList();
        }

        public int AddAccount(AccountModel account) 
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account.Id;
        }

        public AccountModel GetAccountById(int id)
        {
            return _context.Accounts.Where(a => a.Id == id).FirstOrDefault();
        }

        public void UpdateAccount(int id, AccountModel account)
        {
            var existingAccount = GetAccountById(id);
            existingAccount.AccountType = account.AccountType;
            existingAccount.AccountNumber = account.AccountNumber;
            existingAccount.Name = account.Name;

            _context.Accounts.Update(existingAccount);
            _context.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            var account = GetAccountById(id);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}
