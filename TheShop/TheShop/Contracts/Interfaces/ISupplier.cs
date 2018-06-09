namespace TheShop.Contracts.Interfaces
{
    /// <summary>
    /// Supplier interface
    /// </summary>
    public interface ISupplier
    {
        /// <summary>
        /// Checks whether the Supplier has the article in his inventory
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        bool HasArticleInInventory(int ID);

        /// <summary>
        /// Gets the article from the supplier
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Article GetArticle(int ID);
    }
}
