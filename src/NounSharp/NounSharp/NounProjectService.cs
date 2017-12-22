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
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Internal.IconsResponse>(response.Content)?.Icons;
            }

            // TODO: Throw exception
            return null;
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
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Internal.IconsResponse>(response.Content)?.Icons;
            }

            // TODO: Throw exception
            return null;
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
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Internal.CollectionResponse>(response.Content)?.Collection;
            }

            // TODO: Throw exception
            return null;
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
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Internal.CollectionResponse>(response.Content)?.Collection;
            }

            // TODO: Throw exception
            return null;
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
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Internal.CollectionsResponse>(response.Content)?.Collections;
            }

            // TODO: Throw exception
            return null;
        }

        // Icon

        /// <summary>
        /// Returns a single icon.
        /// </summary>
        /// <param name="id">icon id</param>
        /// <returns></returns>
        public Task<Models.Icon> GetIconAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a single icon.
        /// </summary>
        /// <param name="term">icon term</param>
        /// <returns></returns>
        public Task<Models.Icon> GetIconAsync(string term)
        {
            throw new NotImplementedException();
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
        public Task<IEnumerable<Models.Icon>> GetIconsAsync(string term, bool? limitToPublicDomain = null, int? limit = null, int? offset = null, int? page = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns list of most recently uploaded icons.
        /// </summary>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public Task<IEnumerable<Models.Icon>> GetIconRecentUploadsAsync(int? limit = null, int? offset = null, int? page = null)
        {
            throw new NotImplementedException();
        }

        // User

        /// <summary>
        /// Returns a single collection associated with a user.
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="slug">collection slug</param>
        /// <returns></returns>
        public Task<Models.Collection> GetUserCollectionAsync(int userID, string slug)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of collections associated with a user.
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns></returns>
        public Task<IEnumerable<Models.Collection>> GetUserCollectionsAsync(int userID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of uploads associated with a user.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public Task<IEnumerable<Models.Icon>> GetUserUploadsAsync(string username, int? limit = null, int? offset = null, int? page = null)
        {
            throw new NotImplementedException();
        }
    }
}
