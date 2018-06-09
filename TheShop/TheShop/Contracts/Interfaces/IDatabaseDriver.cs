using System.Collections.Generic;
namespace TheShop.Contracts.Interfaces
{
    /// <summary>
    /// Database driver interface
    /// </summary>
    public interface IDatabaseDriver
    {
        /// <summary>
        /// Gets article by id from our storage. Returns default article if not found.
        /// </summary>
        /// <param name="id">Article ID</param>
        /// <returns></returns>
        Article GetArticleByID(int id);

        /// <summary>
        /// Saves an article to our storage, if it already doesn't exist.
        /// </summary>
        /// <param name="article">Article representation</param>
        /// <returns></returns>
        void SaveArticle(Article article);
    }
}
