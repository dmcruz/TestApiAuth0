using System;
using System.Collections.Generic;

namespace TestApiAuth0.Data
{
    public static class AccountsDbContextUtils
    {
        public static void LoadInitialData(this AccountsDbContext context) 
        {
            context.Accounts.RemoveRange(context.Accounts);
            context.SaveChanges();

            var listAccounts = new List<AccountModel> {
                new AccountModel {
                    Id = 1,
                    AccountNumber = "10001-10001-0000",
                    AccountType = AccountTypes.SAVINGS,
                    Name = "Donna's Savings Account"
                },
                new AccountModel {
                    Id = 2,
                    AccountNumber = "10001-10001-0011",
                    AccountType = AccountTypes.SAVINGS,
                    Name = "Company ABC Savings Account"
                },
                new AccountModel {
                    Id = 3,
                    AccountNumber = "10112-10001-0111",
                    AccountType = AccountTypes.CHECK,
                    Name = "Michael's Check Account"
                },
                new AccountModel {
                    Id = 4,
                    AccountNumber = "10111-12334-0022",
                    AccountType = AccountTypes.CASH,
                    Name = "Kat's Cash Account"
                }
            };

            context.Accounts.AddRange(listAccounts);
            context.SaveChanges();

        }
    }
}
