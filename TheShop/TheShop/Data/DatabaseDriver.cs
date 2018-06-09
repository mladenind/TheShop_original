using System.Collections.Generic;
using System.Linq;
using TheShop.Contracts.Interfaces;

namespace TheShop.Data
{
    public class DatabaseDriver : IDatabaseDriver
    {
        private List<Article> _articles = new List<Article>();

        public Article GetArticleByID(int id)
        {
            return _articles.FirstOrDefault(x => x.ID == id) ?? new Article();
        }

        public void SaveArticle(Article article)
        {
            if (!_articles.Contains(article))
            {
                _articles.Add(article);
            }
        }
    }
}
