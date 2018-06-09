using TheShop.Contracts.Interfaces;

namespace TheShop
{
    /// <summary>
    /// Second generic supplier
    /// </summary>
    public class SecondSupplier: ISupplier
    {
        public SecondSupplier(Article article)
        {
            this._article = article;
        }

        public bool HasArticleInInventory(int ID)
        {
            return this.Article.ID == ID;
        }

        public Article GetArticle(int Id)
        {
            return this.Article;
        }

        public override string ToString()
        {
            return "The second supplier";
        }

        private Article _article;

        public Article Article
        {
            get { return _article; }
            set { _article = value; }
        }
    }
}
