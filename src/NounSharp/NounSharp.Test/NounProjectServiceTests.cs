using System.Configuration;
using Xunit;

namespace NounSharp.Test
{
    public class NounProjectServiceTests
    {
        [Fact]
        public void CanCreateNounServiceWithoutApiKey()
        {
            // Arrange
            INounProjectService target;

            // Act
            target = new NounProjectService("", "");

            // Assert
            Assert.NotNull(target);
        }

        [Fact]
        public async void GetCollectionsAsyncReturnsCollections()
        {
            // Arrange
            INounProjectService target = GetService();

            // Act
            var result = await target.GetCollectionsAsync();

            // Assert
            Assert.NotNull(result);
        }

        private INounProjectService GetService()
        {
            return new NounProjectService(ConfigurationManager.AppSettings["apiKey"], ConfigurationManager.AppSettings["apiSecret"]);
        }
    }
}
