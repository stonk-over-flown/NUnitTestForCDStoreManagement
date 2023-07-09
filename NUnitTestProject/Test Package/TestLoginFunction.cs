using NUnitTestForCDStoreManagement.Model;

namespace NUnitTestingProject.Test_Package
{
    [TestFixture]
    public class TestLoginFunction
    {
        private static IEnumerable<TestCaseData> AccountLoginTestCases()
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
            yield return new TestCaseData(acc1,"Login Successfully!" + "(" + acc1.UserName + ")");
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

        [Test]
        [TestCaseSource(nameof(AccountLoginTestCases))]
        public void CheckLogin_ReturnsExpectedResult(AccountModel account, string expectedResult)
        {
            var result = AccountService.Login(account);

            Assert.AreEqual(expectedResult, result);
        }
    }
}