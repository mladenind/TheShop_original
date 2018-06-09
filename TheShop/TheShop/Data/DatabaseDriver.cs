using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts.Interfaces;

namespace TheShop.Data
{
    public class DatabaseDriver : IDatabaseDriver
    {
        private List<Article> _articles = new List<Article>();

        public DatabaseDriver()
        {
            // just some default values
            _articles = new List<Article>()
            {
                new Article(1, "Fender guitars", 300, false, null, null),
                new Article(4, "Clown trousers", 1200, true, new DateTime(2017, 10, 08), 123),
                new Article(7, "Silly hats", 230, true, new DateTime(2016, 10, 08), 11),
            };
        }

        public Article GetByID(int id)
        {
            return _articles.FirstOrDefault(x => x.ID == id) ?? new Article();
        }

        public void Save(Article article)
        {
            if (!_articles.Contains(article))
            {
                _articles.Add(article);
            }
        }
    }
}
