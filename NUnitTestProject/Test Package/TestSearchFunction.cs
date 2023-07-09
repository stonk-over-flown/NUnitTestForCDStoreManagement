using NUnitTestForCDStoreManagement.Model;

namespace NUnitTestingProject.Test_Package 
{
    [TestFixture]
    public class TestSearchFunction
    {
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