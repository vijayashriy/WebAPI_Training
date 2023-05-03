using Microsoft.AspNetCore.Mvc.Formatters;

namespace BankingAPI.Models
{
    public class Accounts
    {
        #region Properties

        public int accNo { get; set; }

        public string accName { get; set; }

        public string accType { get; set;}

        public int accBalance { get; set;}

        public bool accIsActive { get; set;}

        #endregion

        #region Data Store
        private static List<Accounts> accList = new List<Accounts>()
        {
            new Accounts() { accNo = 1, accName = "Adam", accType = "Savings", accBalance = 49875, accIsActive = true },
            new Accounts() { accNo = 2, accName = "John", accType = "Current", accBalance = 5678, accIsActive = true },
            new Accounts() { accNo = 3, accName = "Alex", accType = "Savings", accBalance = 3456, accIsActive = false },
            new Accounts() { accNo = 4, accName = "Jack", accType = "PF", accBalance = 23, accIsActive = true },
            new Accounts() { accNo = 5, accName = "Nick", accType = "Current", accBalance = 8789, accIsActive = true },
            new Accounts() { accNo = 6, accName = "Chris", accType = "Savings", accBalance = 256, accIsActive = false },
            new Accounts() { accNo = 7, accName = "Johnson", accType = "PF", accBalance = 88765, accIsActive = true },
        };
        #endregion

        #region GET methods

        public List<Accounts> GetAllAccounts()
        {
            return accList;
        }

        public List<Accounts> GetAccountsByType(string Type)
        {
            var acc = (from p in accList
                       where p.accType == Type
                       select p).ToList();
            return acc;
        }

        public Accounts GetAccountByNo(int accNumber)
        {
            var checkAcc = accList.Count(p =>p.accNo == accNumber);

            if(checkAcc == 1)
            {
                var acc = (from p in accList
                           where p.accNo == accNumber
                           select p).Single();
                return acc;
            }

            throw new Exception("Sorry account not found");
        }

        public List<Accounts> GetAccountsByStatus(bool status)
        {
            var acc = (from p in accList
                       where p.accIsActive == status
                       select p).ToList();
            return acc;
        }
        #endregion

        #region POST method

        public string AddNewAccount(Accounts newAcc)
        {
            if(newAcc.accName.Length < 2)
            {
                throw new Exception("Please enter Account holder name consisting more than 2 charaters");
            }
            else if(newAcc.accType != "Savings" && newAcc.accType != "Current" && newAcc.accType != "PF")
            {
               throw new Exception("Please enter valid account type ( Savings or Current or PF)");
            }
            accList.Add(newAcc);
            return "Account Added Successfully!";
        }
        #endregion

        #region PUT method
        
        public string EditAccount(Accounts editAcc)
        {
            var count = accList.Count(p => p.accNo == editAcc.accNo);

            if(count > 0)
            {
                var acc = (from p in accList
                           where p.accNo == editAcc.accNo
                           select p).Single();

                acc.accName = editAcc.accName;
                acc.accType = editAcc.accType;
                acc.accBalance = editAcc.accBalance;
                acc.accIsActive = editAcc.accIsActive;

                return "Account edited successfully!";
            }

            throw new Exception("Account not found.");
        }
        #endregion

        #region DELETE method

        public string DeleteAccount(int accNum)
        {
            var count = accList.Count(p => p.accNo == accNum);

            if(count > 0)
            {
                var acc = (from p in accList
                           where p.accNo == accNum
                           select p).Single();

                accList.Remove(acc);
                return "Account deleted successfully!";
            }

            throw new Exception("Account not found.");
        }
        #endregion

    }
}
