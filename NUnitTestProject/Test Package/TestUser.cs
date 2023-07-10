using NUnitTestForCDStoreManagement.Model;
using System.Security.Principal;

namespace NUnitTestingProject.Test_Package
{
    [TestFixture]
    public class TestUser
    {
        private static IEnumerable<TestCaseData> AccountLoginSuccessTestCases()
        {
            AccountModel acc1 = new AccountModel()
            {
                AccountId = 1,
                UserName = "admin",
                PassWord = "abc12345",
                RoleId = "MG",
                FullName = "Administrator",
                Email = "cdstore@gmail.com",
                Address = "FPT University",
                PhoneNumber = "0886647866",
            };
            yield return new TestCaseData(acc1, "Login Successfully!" + "(" + acc1.UserName + ")");
            AccountModel acc2 = new AccountModel()
            {
                AccountId = 2,
                UserName = "trungtin9620@gmail.com",
                PassWord = "962000",
                RoleId = "EM",
                FullName = "Nguyen Trung Tin",
                Email = "trungtin9620@gmail.com",
                Address = "Thu Duc City",
                PhoneNumber = "0913898913",
            };

            yield return new TestCaseData(acc2, "Login Successfully!" + "(" + acc2.UserName + ")");
            AccountModel acc3 = new AccountModel()
            {
                AccountId = 3,
                UserName = "khangmk",
                PassWord = "khang12345",
                RoleId = "EM",
                FullName = "Nguyen Minh Khang",
                Email = "khangnm11@gmail.com",
                Address = "Vung Tau",
                PhoneNumber = "0908256762",
            };
            yield return new TestCaseData(acc3, "Login Successfully!" + "(" + acc3.UserName + ")");
            AccountModel acc4 = new AccountModel()
            {

            };
            yield return new TestCaseData(acc4, "Please enter username and password" + "(" + acc4.UserName + ")");
        }
        private static IEnumerable<TestCaseData> AccountLoginFailTestCases()
        {
            AccountModel acc1 = new AccountModel()
            {
                AccountId = 1,
                UserName = "admin",
                PassWord = "abc123",
                RoleId = "MG",
                FullName = "Administrator",
                Email = "cdstore@gmail.com",
                Address = "FPT University",
                PhoneNumber = "0886647866",
            };
            yield return new TestCaseData(acc1, "Login Failed! Try Again " + "(" + acc1.UserName + ")");
            AccountModel acc2 = new AccountModel()
            {
                AccountId = 2,
                UserName = "trungtin962k@gmail.com",
                PassWord = "962000",
                RoleId = "EM",
                FullName = "Nguyen Trung Tin",
                Email = "trungtin9620@gmail.com",
                Address = "Thu Duc City",
                PhoneNumber = "0913898913",
            };

            yield return new TestCaseData(acc2, "Login Failed! Try Again " + "(" + acc2.UserName + ")");
            AccountModel acc3 = new AccountModel()
            {
                AccountId = 3,
                UserName = "khangmk",
                PassWord = "khang1215",
                RoleId = "EM",
                FullName = "Nguyen Minh Khang",
                Email = "khangnm11@gmail.com",
                Address = "Vung Tau",
                PhoneNumber = "0908256762",
            };
            yield return new TestCaseData(acc3, "Login Failed! Try Again " + "(" + acc3.UserName + ")");
            AccountModel acc4 = new AccountModel()
            {

            };
            yield return new TestCaseData(acc4, "Please enter username and password" + "(" + acc4.UserName + ")");
        }

        private static IEnumerable<TestCaseData> PhoneNumberTestCases()
        {
            string phoneNo1 = "+84123456789";
            yield return new TestCaseData(phoneNo1, phoneNo1 + " is valid phone number");
            string phoneNo2 = "084123456789";
            yield return new TestCaseData(phoneNo2, phoneNo2 + " is not valid phone number");
            string phoneNo3 = "012345678";
            yield return new TestCaseData(phoneNo3, phoneNo3 + " is not valid phone number");
            string phoneNo4 = "0-123456789";
            yield return new TestCaseData(phoneNo4, phoneNo4 + " is not valid phone number");
            string phoneNo5 = "0 123 456 789";
            yield return new TestCaseData(phoneNo5, phoneNo5 + " is not valid phone number");
        }
        private static IEnumerable<TestCaseData> UserRoleTestCases()
        {
            AccountModel acc1 = new AccountModel()
            {
                AccountId = 1,
                UserName = "admin",
                PassWord = "abc12345",
                RoleId = "MG",
                FullName = "Administrator",
                Email = "cdstore@gmail.com",
                Address = "FPT University",
                PhoneNumber = "0886647866",
            };
            yield return new TestCaseData(acc1,"Welcome Admin");
            AccountModel acc2 = new AccountModel()
            {
                AccountId = 2,
                UserName = "trungtin9620@gmail.com",
                PassWord = "962000",
                RoleId = "EM",
                FullName = "Nguyen Trung Tin",
                Email = "trungtin9620@gmail.com",
                Address = "Thu Duc City",
                PhoneNumber = "0913898913",
            };
            yield return new TestCaseData(acc2, "Welcome " + acc2.FullName);
            AccountModel acc3 = new AccountModel()
            {
                AccountId = 3,
                UserName = "khangmk",
                PassWord = "khang12345",
                RoleId = "EM",
                FullName = "Nguyen Minh Khang",
                Email = "khangnm11@gmail.com",
                Address = "Vung Tau",
                PhoneNumber = "0908256762",
            };
            yield return new TestCaseData(acc3, "Welcome " + acc3.FullName);
        }
        [Test]
        [TestCaseSource(nameof(AccountLoginSuccessTestCases))]
        public void CheckLogin_ReturnsExpectedResult(AccountModel account, string expectedResult)
        {
            var result = AccountService.Login(account);

            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        [TestCaseSource(nameof(AccountLoginFailTestCases))]
        public void CheckFailedLogin_ReturnsExpectedResult(AccountModel account, string expectedResult)
        {
            var result = AccountService.Login(account);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCaseSource(nameof(UserRoleTestCases))]
        public void CheckUserRole_ReturnsExpectedResult(AccountModel account, string expectedResult)
        {
            // Act
            var result = AccountService.checkUserRole(account);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        
        private static readonly object[] EmailTestCases =
        {
            new object[] { "example@fpt.edu.vn", true },
            new object[] { "example.first.middle.lastname@email.com", true },
            new object[] { "example@subdomain.email.com", true },
            new object[] { "0987654321@example.com", true },
            new object[] { "_______@email.com", true },
            new object[] { "example.firstname-lastname@email.com", true },
            new object[] { "abcde", false },
            new object[] { "@#@@##@%^%#$@#$@#.com", false }
        };
        [Test, TestCaseSource(nameof(EmailTestCases))]
        public void CheckEmailRegex(string email, bool expectedResult)
        {
            var result = AccountService.isValid(email);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCaseSource(nameof(PhoneNumberTestCases))]
        public void CheckUserRole_ReturnsExpectedResult(string phoneNumber, string expectedResult)
        {
            var result = AccountService.checkPhoneRegex(phoneNumber);
            Assert.AreEqual(expectedResult, result);
        }

    }
}