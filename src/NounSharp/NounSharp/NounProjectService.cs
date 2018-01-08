using Newtonsoft.Json;
using NounSharp.Internal;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NounSharp
{
    public class NounProjectService : INounProjectService
    {
        public NounProjectService(string apiKey, string apiSecret)
        {
            _client = new RestClient("http://api.thenounproject.com/");
            _client.Authenticator = OAuth1Authenticator.ForRequestToken(apiKey, apiSecret);
            _requestBuilder = new RequestBuilder();
        }

        public NounProjectService(IRestClient client, IRequestBuilder requestBuilder)
        {
            _client = client;
            _requestBuilder = requestBuilder;
        }

        private IRestClient _client;
        private IRequestBuilder _requestBuilder;

        /// <summary>
        /// Returns a list of icons associated with a collection.
        /// </summary>
        /// <param name="id">collection id</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Icon>> GetCollectionIconsAsync(int id, int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest restRequest = _requestBuilder.GetCollectionIconsRequest(id, limit, offset, page);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<IconsResponse, IEnumerable<Models.Icon>>(response.StatusCode, response.Content, res => res?.Icons);
        }

        /// <summary>
        /// Returns a list of icons associated with a collection.
        /// </summary>
        /// <param name="slug">collection slug</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Icon>> GetCollectionIconsAsync(string slug, int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest restRequest = _requestBuilder.GetCollectionIconsRequest(slug, limit, offset, page);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<IconsResponse, IEnumerable<Models.Icon>>(response.StatusCode, response.Content, res => res?.Icons);
        }

        /// <summary>
        /// Returns a single collection.
        /// </summary>
        /// <param name="id">collection id</param>
        /// <returns></returns>
        public async Task<Models.Collection> GetCollectionAsync(int id)
        {
            IRestRequest restRequest = _requestBuilder.GetCollectionRequest(id);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<CollectionResponse, Models.Collection>(response.StatusCode, response.Content, res => res?.Collection);
        }

        /// <summary>
        /// Returns a single collection.
        /// </summary>
        /// <param name="slug">collection slug</param>
        /// <returns></returns>
        public async Task<Models.Collection> GetCollectionAsync(string slug)
        {
            IRestRequest restRequest = _requestBuilder.GetCollectionRequest(slug);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<CollectionResponse, Models.Collection>(response.StatusCode, response.Content, res => res?.Collection);
        }

        // Collections

        /// <summary>
        /// Return’s a list of all collections.
        /// </summary>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Collection>> GetCollectionsAsync(int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest restRequest = _requestBuilder.GetCollectionsRequest(limit, offset, page);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<CollectionsResponse, IEnumerable<Models.Collection>>(response.StatusCode, response.Content, res => res?.Collections);
        }

        // Icon

        /// <summary>
        /// Returns a single icon.
        /// </summary>
        /// <param name="id">icon id</param>
        /// <returns></returns>
        public async Task<Models.Icon> GetIconAsync(int id)
        {
            IRestRequest restRequest = _requestBuilder.GetIconRequest(id);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<IconResponse, Models.Icon>(response.StatusCode, response.Content, res => res?.Icon);
        }

        /// <summary>
        /// Returns a single icon.
        /// </summary>
        /// <param name="term">icon term</param>
        /// <returns></returns>
        public async Task<Models.Icon> GetIconAsync(string term)
        {
            IRestRequest restRequest = _requestBuilder.GetIconRequest(term);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<IconResponse, Models.Icon>(response.StatusCode, response.Content, res => res?.Icon);
        }

        // Icons

        /// <summary>
        /// Returns a single icon.
        /// </summary>
        /// <param name="term">icon term</param>
        /// <param name="limitToPublicDomain">limit results to public domain icons only</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Icon>> GetIconsAsync(string term, bool? limitToPublicDomain = null, int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest restRequest = _requestBuilder.GetIconsRequest(term, limitToPublicDomain, limit, offset, page);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<IconsResponse, IEnumerable<Models.Icon>>(response.StatusCode, response.Content, res => res?.Icons);
        }

        /// <summary>
        /// Returns list of most recently uploaded icons.
        /// </summary>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Icon>> GetIconRecentUploadsAsync(int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest restRequest = _requestBuilder.GetIconRecentUploadsRequest(limit, offset, page);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<IconsRecentUploadsResponse, IEnumerable<Models.Icon>>(response.StatusCode, response.Content, res => res?.RecentUploads);
        }

        // User

        /// <summary>
        /// Returns a single collection associated with a user.
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="slug">collection slug</param>
        /// <returns></returns>
        public async Task<Models.Collection> GetUserCollectionAsync(int userID, string slug)
        {
            IRestRequest restRequest = _requestBuilder.GetUserCollectionRequest(userID, slug);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<CollectionResponse, Models.Collection>(response.StatusCode, response.Content, res => res?.Collection);
        }

        /// <summary>
        /// Returns a list of collections associated with a user.
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Collection>> GetUserCollectionsAsync(int userID)
        {
            IRestRequest restRequest = _requestBuilder.GetUserCollectionsRequest(userID);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<CollectionsResponse, IEnumerable<Models.Collection>>(response.StatusCode, response.Content, res => res?.Collections);
        }

        /// <summary>
        /// Returns a list of uploads associated with a user.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Icon>> GetUserUploadsAsync(string username, int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest restRequest = _requestBuilder.GetUserUploadsRequest(username, limit, offset, page);

            var response = await _client.ExecuteTaskAsync(restRequest);
            return HandleResponse<IconsUserUploadsResponse, IEnumerable<Models.Icon>>(response.StatusCode, response.Content, res => res?.Uploads);
        }

        private static TResult HandleResponse<TResponse, TResult>(System.Net.HttpStatusCode statusCode, string content, Func<TResponse, TResult> resultSelector)
        {
            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                switch (statusCode)
                {
                    case System.Net.HttpStatusCode.Unauthorized:
                        throw new UnauthorizedAccessException(content);
                    case System.Net.HttpStatusCode.NotFound:
                        return default(TResult);
                    default:
                        throw new System.Net.WebException(content);
                }
            }

            TResponse response = JsonConvert.DeserializeObject<TResponse>(content);
            return resultSelector(response);
        }
    }
}
