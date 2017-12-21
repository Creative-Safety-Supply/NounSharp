using Newtonsoft.Json;
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
        }

        private RestSharp.RestClient _client;

        /// <summary>
        /// Returns a list of icons associated with a collection.
        /// </summary>
        /// <param name="id">collection id</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public Task<IEnumerable<Models.Icon>> GetCollectionIconsAsync(int id, int limit = 50, int offset = 0, int page = 1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of icons associated with a collection.
        /// </summary>
        /// <param name="slug">collection slug</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Icon>> GetCollectionIconsAsync(string slug, int limit = 50, int offset = 0, int page = 1)
        {
            IRestRequest restRequest = new RestRequest("collection/{slug}/icons", Method.GET)
               .AddUrlSegment("slug", slug);

            var aa = _client.BuildUri(restRequest);

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
            IRestRequest restRequest = new RestRequest("collection", Method.GET)
               .AddParameter("id", id);

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
            IRestRequest restRequest = new RestRequest("collection", Method.GET)
               .AddParameter("slug", slug);

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
        public async Task<IEnumerable<Models.Collection>> GetCollectionsAsync(int limit = 50, int offset = 0, int page = 1)
        {
            IRestRequest restRequest = new RestRequest("collections", Method.GET)
                .AddQueryParameter("limit", limit.ToString())
                .AddQueryParameter("offset", offset.ToString())
                .AddQueryParameter("page", page.ToString());

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
        public Task<IEnumerable<Models.Icon>> GetIconsAsync(string term, bool limitToPublicDomain = false, int limit = 50, int offset = 0, int page = 1)
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
        public Task<IEnumerable<Models.Icon>> GetIconRecentUploadsAsync(int limit = 50, int offset = 0, int page = 1)
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
        public Task<Models.Collection> GetUserCollection(int userID, string slug)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of collections associated with a user.
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns></returns>
        public Task<IEnumerable<Models.Collection>> GetUserCollections(int userID)
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
        public Task<IEnumerable<Models.Icon>> GetUserUploads(string username, int limit = 50, int offset = 0, int page = 1)
        {
            throw new NotImplementedException();
        }
    }
}
