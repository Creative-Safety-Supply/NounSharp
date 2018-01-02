using Moq;
using System.Threading.Tasks;
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
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "collections"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("collections"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetCollectionsAsync();

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetCollectionBySlugAsyncReturnsCollection()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "collection/{slug}"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("collection_slug"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetCollectionAsync("fun");

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetCollectionByIdAsyncReturnsCollection()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "collection/{id}"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("collection_id"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetCollectionAsync(4);

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetCollectionIconsBySlugAsyncReturnsCollection()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "collection/{slug}/icons"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("collection_slug_icons"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetCollectionIconsAsync("fun");

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetCollectionIconsByIdAsyncReturnsCollection()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "collection/{id}/icons"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("collection_id_icons"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetCollectionIconsAsync(4);

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetIconByIdAsyncReturnsIcon()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "icon/{id}"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("icon_id"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetIconAsync(4);

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetIconByTermAsyncReturnsIcon()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "icon/{term}"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("icon_term"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetIconAsync("fun");

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetIconsByTermAsyncReturnsIcons()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "icons/{term}"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("icons_term"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetIconsAsync("fun");

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetRecentUploadIconsAsyncReturnsIcons()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "icons/recent_uploads"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("recent_uploads"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetIconRecentUploadsAsync();

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetUserCollectionsByIdAsyncReturnsCollections()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "user/{user_id}/collections"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("user_collections"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetUserCollectionsAsync(12);

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetUserCollectionByIdAndSlugAsyncReturnsCollection()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "user/{user_id}/collections/{slug}"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("user_collection_slug"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetUserCollectionAsync(12, "fun");

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }

        [Fact]
        public async void GetUserUploadsAsyncReturnsIcons()
        {
            // Arrange
            Mock<RestSharp.IRestClient> clientMock = new Mock<RestSharp.IRestClient>();
            clientMock.Setup(c => c.ExecuteTaskAsync(It.Is<RestSharp.IRestRequest>(req => req.Resource == "user/{username}/uploads"))).Returns(() => Task.FromResult(RestUtils.GetOkResponse(ResponseResource.ResourceManager.GetString("user_uploads"))));
            INounProjectService target = new NounProjectService(clientMock.Object, new Internal.RequestBuilder());

            // Act
            var result = await target.GetUserUploadsAsync("john");

            // Assert
            Assert.NotNull(result);
            // TODO: Add more checks
        }
    }
}
