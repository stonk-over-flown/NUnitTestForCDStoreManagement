using NUnitTestForCDStoreManagement.Model;

namespace NUnitTestingProject.Test_Package
{
    public class TestCheckEmailRegex
    {
        [TestCase("example@fpt.edu.vn", true)]
        [TestCase("example.first.middle.lastname@email.com", true)]
        [TestCase("example@subdomain.email.com", true)]
        [TestCase("0987654321@example.com", true)]
        [TestCase("_______@email.com",true)]
        [TestCase("example.firstname-lastname@email.com",true)]
        [TestCase("abcde",false)]
        [TestCase("@#@@##@%^%#$@#$@#.com", false)]
        [Test]
        public void CheckEmailRegex(string email, bool expectedResult)
        {
            var result = AccountService.isValid(email);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
