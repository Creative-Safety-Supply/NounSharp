using NounSharp.Internal;
using RestSharp;
using Xunit;

namespace NounSharp.Test
{
    public class RequestBuilderTests
    {
        [Fact]
        public void GetCollectionIconsRequest_OnlyWithID_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionIconsRequest(5);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collection/5/icons", uri);
        }

        [Fact]
        public void GetCollectionIconsRequest_WithIDAndLimit_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionIconsRequest(5, limit: 10);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collection/5/icons?limit=10", uri);
        }

        [Fact]
        public void GetCollectionIconsRequest_WithIDAndLimitOffsetPage_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionIconsRequest(5, limit: 10, offset:5, page:2);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collection/5/icons?limit=10&offset=5&page=2", uri);
        }

        [Fact]
        public void GetCollectionIconsRequest_OnlyWithSlug_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionIconsRequest("fun");
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collection/fun/icons", uri);
        }

        [Fact]
        public void GetCollectionIconsRequest_WithSlugAndLimit_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionIconsRequest("fun", limit: 10);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collection/fun/icons?limit=10", uri);
        }

        [Fact]
        public void GetCollectionIconsRequest_WithSlugAndLimitOffsetPage_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionIconsRequest("fun", limit: 10, offset: 5, page: 2);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collection/fun/icons?limit=10&offset=5&page=2", uri);
        }

        [Fact]
        public void GetCollectionRequest_WithID_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionRequest(5);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collection/5", uri);
        }

        [Fact]
        public void GetCollectionRequest_WithSlug_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionRequest("fun");
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collection/fun", uri);
        }

        [Fact]
        public void GetCollectionsRequest_NoParameters_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionsRequest();
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collections", uri);
        }

        [Fact]
        public void GetCollectionsRequest_WithLimit_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionsRequest(limit: 10);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collections?limit=10", uri);
        }

        [Fact]
        public void GetCollectionsRequest_WithLimitAndOffsetPage_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetCollectionsRequest(limit: 10, offset: 5, page: 2);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/collections?limit=10&offset=5&page=2", uri);
        }

        [Fact]
        public void GetIconRequest_WithID_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconRequest(5);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icon/5", uri);
        }

        [Fact]
        public void GetIconRequest_WithTerm_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconRequest("fun");
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icon/fun", uri);
        }

        [Fact]
        public void GetIconRecentUploadsRequest_NoParameters_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconRecentUploadsRequest();
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/recent_uploads", uri);
        }

        [Fact]
        public void GetIconRecentUploadsRequest_WithLimit_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconRecentUploadsRequest(limit: 10);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/recent_uploads?limit=10", uri);
        }

        [Fact]
        public void GetIconRecentUploadsRequest_WithLimitAndOffsetPage_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconRecentUploadsRequest(limit: 10, offset: 5, page: 2);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/recent_uploads?limit=10&offset=5&page=2", uri);
        }

        [Fact]
        public void GetIconsRequest_OnlyWithTerm_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconsRequest("fun");
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/fun", uri);
        }

        [Fact]
        public void GetIconsRequest_WithTermAndLimit_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconsRequest("fun", limit: 10);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/fun?limit=10", uri);
        }

        [Fact]
        public void GetIconsRequest_WithTermAndLimitToPublicDomainTrue_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconsRequest("fun", limitToPublicDomain: true);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/fun?limit_to_public_domain=1", uri);
        }

        [Fact]
        public void GetIconsRequest_WithTermAndLimitToPublicDomainFalse_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconsRequest("fun", limitToPublicDomain: false);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/fun?limit_to_public_domain=0", uri);
        }

        [Fact]
        public void GetIconsRequest_WithTermAndLimitOffsetPage_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconsRequest("fun", limit: 10, offset: 5, page: 2);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/fun?limit=10&offset=5&page=2", uri);
        }

        [Fact]
        public void GetIconsRequest_WithTermAndLimitOffsetPageLimitToPublicDomainFalse_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetIconsRequest("fun", limit: 10, offset: 5, page: 2, limitToPublicDomain: false);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/icons/fun?limit_to_public_domain=0&limit=10&offset=5&page=2", uri);
        }

        [Fact]
        public void GetUserCollectionRequest_WithUserIDAndSlug_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetUserCollectionRequest(5, "fun");
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/user/5/collections/fun", uri);
        }

        [Fact]
        public void GetUserCollectionsRequest_WithUserID_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetUserCollectionsRequest(5);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/user/5/collections", uri);
        }

        [Fact]
        public void GetUserUploadsRequest_OnlyWithUsername_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetUserUploadsRequest("ivan");
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/user/ivan/uploads", uri);
        }

        [Fact]
        public void GetUserUploadsRequest_WithUsernameAndLimit_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetUserUploadsRequest("ivan", limit: 10);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/user/ivan/uploads?limit=10", uri);
        }

        [Fact]
        public void GetUserUploadsRequest_WithUsernameAndLimitOffsetPage_ReturnsCorrectRequest()
        {
            // Arrange
            IRequestBuilder builder = new RequestBuilder();
            IRestClient client = new RestClient("http://api.thenounproject.com/");

            // Act
            IRestRequest request = builder.GetUserUploadsRequest("ivan", limit: 10, offset: 5, page: 2);
            string uri = client.BuildUri(request)?.ToString();

            // Assert
            Assert.Equal("http://api.thenounproject.com/user/ivan/uploads?limit=10&offset=5&page=2", uri);
        }
    }
}
