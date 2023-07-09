using NUnitTestForCDStoreManagement.Model;

namespace NUnitTestingProject.Test_Package
{
    [TestFixture]
    public class TestCheckSongDurationRegex
    {
        private static IEnumerable<TestCaseData> DurationRegex()
        {
            string duration1 = "03:58";
            string duration2 = "04:55";
            string duration3 = "-00:12";
            string duration4 = "55:99";
            string duration5 = "88:55";
            yield return new TestCaseData(duration1, duration1 + " is valid");
            yield return new TestCaseData(duration2, duration2 + " is valid");
            yield return new TestCaseData(duration3, duration3 + " isn't valid");
            yield return new TestCaseData(duration4, duration4 + " isn't valid");
            yield return new TestCaseData(duration5, duration5 + " isn't valid");
        }

        [Test]
        [TestCaseSource(nameof(DurationRegex))]
        public void CheckLogin_ReturnsExpectedResult(string s, string expectedResult)
        {
            var result = SongService.checkRegex(s);

            Assert.AreEqual(expectedResult, result);
        }
    }
}