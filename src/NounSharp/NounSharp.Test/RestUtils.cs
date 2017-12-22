using Moq;

namespace NounSharp.Test
{
    public static class RestUtils
    {
        public static RestSharp.IRestResponse GetOkResponse(string content)
        {
            var mock = new Mock<RestSharp.IRestResponse>();
            mock.SetupGet(c => c.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            mock.SetupGet(c => c.Content).Returns(content);
            return mock.Object;
        }
    }
}
