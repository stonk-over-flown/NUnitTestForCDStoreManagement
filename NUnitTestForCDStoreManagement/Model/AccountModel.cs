using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NUnitTestForCDStoreManagement.Model
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string RoleId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class AccountService
    {
        private static List<AccountModel> accounts = new List<AccountModel>()
        {
            new AccountModel()
            {
                AccountId = 1,
                UserName = "admin",
                PassWord = "abc12345",
                RoleId = "MG",
                FullName = "Administrator",
                Email = "cdstore@gmail.com",
                Address = "FPT University",
                PhoneNumber = "0886647866",
            },
            new AccountModel()
            {
                AccountId = 2,
                UserName = "trungtin9620@gmail.com",
                PassWord = "962000",
                RoleId = "EM",
                FullName = "Nguyen Trung Tin",
                Email = "trungtin9620@gmail.com",
                Address = "Thu Duc City",
                PhoneNumber = "0913898913",
            },
            new AccountModel()
            {
                AccountId = 3,
                UserName = "khangmk",
                PassWord = "khang12345",
                RoleId = "EM",
                FullName = "Nguyen Minh Khang",
                Email = "khangnm11@gmail.com",
                Address = "Vung Tau",
                PhoneNumber = "0908256762",
            },

        };

        public static List<AccountModel> GetAccount()
        {
            return accounts.ToList();
        }
        public static string checkUserRole(AccountModel account)
        {
            if (account.RoleId == "MG")
            {
                return "Welcome Admin";
            }
            else
            {
                return "Welcome " + account.FullName;
            }
        }
        public static string Login(AccountModel account)
        {
            if (string.IsNullOrEmpty(account.UserName) && string.IsNullOrEmpty(account.PassWord))
            {
                return "Please enter username and password";
            }
            else
            {
                var user = accounts.Where(p => p.UserName == account.UserName && p.PassWord == account.PassWord).FirstOrDefault();
                if (user == null)
                {
                    return "Login Failed! Try Again " + "(" + account.UserName + ")";


                }
                return "Login Successfully!" + "(" + account.UserName + ")";

            }
        }
        public static bool isValid(string emailaddress)
        {
            Regex pattern = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            return pattern.IsMatch(emailaddress);
        }
        public static string checkPhoneRegex(string phoneNumber)
        {
            string pattern = @"^(?:\+?84|0)(?:\d){9,10}$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(phoneNumber))
            {
                return phoneNumber + " is valid phone number";
            }
            else
            {
                return phoneNumber + " is not valid phone number";
            }
        }

    }
}
