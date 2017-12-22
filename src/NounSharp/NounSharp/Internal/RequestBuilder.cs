using RestSharp;

namespace NounSharp.Internal
{
    public interface IRequestBuilder
    {
        IRestRequest GetCollectionIconsRequest(int id, int? limit = null, int? offset = null, int? page = null);

        IRestRequest GetCollectionIconsRequest(string slug, int? limit = null, int? offset = null, int? page = null);

        IRestRequest GetCollectionRequest(int id);

        IRestRequest GetCollectionRequest(string slug);

        // Collections

        IRestRequest GetCollectionsRequest(int? limit = null, int? offset = null, int? page = null);

        // Icon

        IRestRequest GetIconRequest(int id);

        IRestRequest GetIconRequest(string term);

        // Icons
        IRestRequest GetIconsRequest(string term, bool? limitToPublicDomain = null, int? limit = null, int? offset = null, int? page = null);

        IRestRequest GetIconRecentUploadsRequest(int? limit = null, int? offset = null, int? page = null);

        // User
        IRestRequest GetUserCollectionRequest(int userID, string slug);

        IRestRequest GetUserCollectionsRequest(int userID);

        IRestRequest GetUserUploadsRequest(string username, int? limit = null, int? offset = null, int? page = null);
    }

    public class RequestBuilder : IRequestBuilder
    {
        // Collection

        public IRestRequest GetCollectionIconsRequest(int id, int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest request = new RestRequest("collection/{id}/icons", Method.GET)
                .AddUrlSegment("id", id);
            AddFiltering(request, limit, offset, page);
            return request;
        }

        public IRestRequest GetCollectionIconsRequest(string slug, int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest request = new RestRequest("collection/{slug}/icons", Method.GET)
               .AddUrlSegment("slug", slug);
            AddFiltering(request, limit, offset, page);
            return request;
        }

        public IRestRequest GetCollectionRequest(int id)
        {
            return new RestRequest("collection/{id}", Method.GET)
               .AddUrlSegment("id", id);
        }

        public IRestRequest GetCollectionRequest(string slug)
        {
            return new RestRequest("collection/{slug}", Method.GET)
               .AddUrlSegment("slug", slug);
        }

        // Collections

        public IRestRequest GetCollectionsRequest(int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest request = new RestRequest("collections", Method.GET);
            AddFiltering(request, limit, offset, page);
            return request;
        }

        // Icon

        public IRestRequest GetIconRequest(int id)
        {
            return new RestRequest("icon/{id}", Method.GET)
                .AddUrlSegment("id", id);
        }

        public IRestRequest GetIconRequest(string term)
        {
            return new RestRequest("icon/{term}", Method.GET)
               .AddUrlSegment("term", term);
        }

        // Icons

        public IRestRequest GetIconsRequest(string term, bool? limitToPublicDomain = null, int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest request = new RestRequest("icons/{term}", Method.GET)
                .AddUrlSegment("term", term);
            if (limitToPublicDomain != null)
                request.AddQueryParameter("limit_to_public_domain", limitToPublicDomain.Value ? "1" : "0");
            AddFiltering(request, limit, offset, page);
            return request;
        }

        public IRestRequest GetIconRecentUploadsRequest(int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest request = new RestRequest("icons/recent_uploads", Method.GET);
            AddFiltering(request, limit, offset, page);
            return request;
        }

        // User

        public IRestRequest GetUserCollectionRequest(int userID, string slug)
        {
            return new RestRequest("user/{user_id}/collections/{slug}", Method.GET)
                .AddUrlSegment("user_id", userID)
                .AddUrlSegment("slug", slug);
        }

        public IRestRequest GetUserCollectionsRequest(int userID)
        {
            return new RestRequest("user/{user_id}/collections", Method.GET)
                .AddUrlSegment("user_id", userID);
        }

        public IRestRequest GetUserUploadsRequest(string username, int? limit = null, int? offset = null, int? page = null)
        {
            IRestRequest request = new RestRequest("user/{username}/uploads", Method.GET)
                .AddUrlSegment("username", username);
            AddFiltering(request, limit, offset, page);
            return request;
        }

        private static void AddFiltering(IRestRequest request, int? limit, int? offset, int? page)
        {
            if (limit != null)
                request.AddQueryParameter("limit", limit.Value.ToString());
            if (offset != null)
                request.AddQueryParameter("offset", offset.Value.ToString());
            if (page != null)
                request.AddQueryParameter("page", page.Value.ToString());
        }
    }
}
