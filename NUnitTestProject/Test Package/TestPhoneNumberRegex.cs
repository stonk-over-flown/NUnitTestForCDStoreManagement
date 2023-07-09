using NUnitTestForCDStoreManagement.Model;

namespace NUnitTestingProject.Test_Package
{
    [TestFixture]
    public class TestPhoneNumberRegex
    {
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

        [Test]
        [TestCaseSource(nameof(PhoneNumberTestCases))]
        public void CheckUserRole_ReturnsExpectedResult(string phoneNumber, string expectedResult)
        {
            var result = AccountService.checkPhoneRegex(phoneNumber);
            Assert.AreEqual(expectedResult, result);
        }
    }
}