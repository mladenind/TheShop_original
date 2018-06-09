using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts.Interfaces;

namespace TheShop
{
    /// <summary>
    /// First generic supplier
    /// </summary>
    public class FirstSupplier : ISupplier
    {
        public FirstSupplier(Article article)
        {
            this._article = article;
        }

        public bool HasArticleInInventory(int ID)
        {
            return this.Article.ID == ID;
        }

        public Article GetArticle(int ID)
        {
            return this.Article;
        }

        public override string ToString()
        {
            return "The first supplier";
        }

        private Article _article;

        public Article Article
        {
            get { return _article; }
            set { _article = value; }
        }
        
    }
}
