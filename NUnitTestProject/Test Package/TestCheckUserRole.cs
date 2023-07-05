using NUnitTestForCDStoreManagement.Model;

namespace NUnitTestingProject.Test_Package
{
    public class TestCheckUserRole
    {
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
        [TestCaseSource(nameof(UserRoleTestCases))]
        public void CheckUserRole_ReturnsExpectedResult(AccountModel account, string expectedResult)
        {
            // Act
            var result = AccountService.checkUserRole(account);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}