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
    }
}
