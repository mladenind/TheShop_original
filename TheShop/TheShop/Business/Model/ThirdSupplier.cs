using TheShop.Contracts.Interfaces;

namespace TheShop
{
    /// <summary>
    /// Third generic supplier
    /// </summary>
    public class ThirdSupplier: ISupplier
    {
        public ThirdSupplier(Article article)
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
            return "The third supplier";
        }

        private Article _article;

        public Article Article
        {
            get { return _article; }
            set { _article = value; }
        }
    }
}
