using System.Collections.Generic;
using System.Threading.Tasks;

namespace NounSharp
{
    public interface INounProjectService
    {
        // Collection

        /// <summary>
        /// Returns a list of icons associated with a collection.
        /// </summary>
        /// <param name="id">collection id</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        Task<IEnumerable<Models.Icon>> GetCollectionIconsAsync(int id, int limit = 50, int offset = 0, int page = 1);

        /// <summary>
        /// Returns a list of icons associated with a collection.
        /// </summary>
        /// <param name="slug">collection slug</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        Task<IEnumerable<Models.Icon>> GetCollectionIconsAsync(string slug, int limit = 50, int offset = 0, int page = 1);

        /// <summary>
        /// Returns a single collection.
        /// </summary>
        /// <param name="id">collection id</param>
        /// <returns></returns>
        Task<Models.Collection> GetCollectionAsync(int id);

        /// <summary>
        /// Returns a single collection.
        /// </summary>
        /// <param name="slug">collection slug</param>
        /// <returns></returns>
        Task<Models.Collection> GetCollectionAsync(string slug);

        // Collections

        /// <summary>
        /// Return’s a list of all collections.
        /// </summary>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        Task<IEnumerable<Models.Collection>> GetCollectionsAsync(int limit = 50, int offset = 0, int page = 1);

        // Icon

        /// <summary>
        /// Returns a single icon.
        /// </summary>
        /// <param name="id">icon id</param>
        /// <returns></returns>
        Task<Models.Icon> GetIconAsync(int id);

        /// <summary>
        /// Returns a single icon.
        /// </summary>
        /// <param name="term">icon term</param>
        /// <returns></returns>
        Task<Models.Icon> GetIconAsync(string term);

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
        Task<IEnumerable<Models.Icon>> GetIconsAsync(string term, bool limitToPublicDomain = false, int limit = 50, int offset = 0, int page = 1);

        /// <summary>
        /// Returns list of most recently uploaded icons.
        /// </summary>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        Task<IEnumerable<Models.Icon>> GetIconRecentUploadsAsync(int limit = 50, int offset = 0, int page = 1);

        // User

        /// <summary>
        /// Returns a single collection associated with a user.
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="slug">collection slug</param>
        /// <returns></returns>
        Task<Models.Collection> GetUserCollection(int userID, string slug);

        /// <summary>
        /// Returns a list of collections associated with a user.
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns></returns>
        Task<IEnumerable<Models.Collection>> GetUserCollections(int userID);

        /// <summary>
        /// Returns a list of uploads associated with a user.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="limit">maximum number of results</param>
        /// <param name="offset">number of results to displace or skip over</param>
        /// <param name="page">number of results of limit length to displace or skip over</param>
        /// <returns></returns>
        Task<IEnumerable<Models.Icon>> GetUserUploads(string username, int limit = 50, int offset = 0, int page = 1);
    }
}
