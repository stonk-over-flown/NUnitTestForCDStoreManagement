using NUnitTestForCDStoreManagement.Model;

namespace NUnitTestingProject.Test_Package
{
    [TestFixture]
    public class TestSongFunction
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
        private static readonly object[] SearchTestCases =
        {
            new object[] {"Greatest", new [] { "The Greatest Hits" }},
            new object[] {"Revival", new [] { "Revival" }},
            new object[] { "AC/DC", new [] { "Back in Black" }},
            new object[] {"e", new [] { "The Greatest Hits", "Revival" } },
            new object[] {"Hip", new [] { "Revival" } },

        };
        private static readonly object[] SearchInvalidTestCases =
        {
            new object[] {"abc123", new string[] {}},
            new object[] {"AAA", new string[] {} },
            new object[] {"awayway", new string[] {}},
            new object[] {"Unknown", new string[] {}}
        };

        [Test]
        [TestCaseSource(nameof(DurationRegex))]
        public void CheckLogin_ReturnsExpectedResult(string s, string expectedResult)
        {
            var result = SongService.checkRegex(s);

            Assert.AreEqual(expectedResult, result);
        }
        


        [Test, TestCaseSource(nameof(SearchTestCases))]
        public void SearchAlbums_ReturnsExpectedResult(string searchValue, string[] expectedAlbums)
        {
            // Arrange
            List<AlbumModel> albums = AlbumService.GetAlbums();

            // Act
            List<AlbumModel> result = AlbumService.SearchAlbums(searchValue, albums);

            // Assert
            CollectionAssert.AreEquivalent(expectedAlbums, result.Select(album => album.AlbumName));
        }

        [Test, TestCaseSource(nameof(SearchInvalidTestCases))]
        public void SearchInvalidAlbums_ReturnsExpectedResult(string searchValue, string[] expectedAlbums)
        {
            // Arrange
            List<AlbumModel> albums = AlbumService.GetAlbums();

            // Act
            List<AlbumModel> result = AlbumService.SearchAlbums(searchValue, albums);

            // Assert
            CollectionAssert.AreEquivalent(expectedAlbums, result.Select(album => album.AlbumName));
        }
    }
}