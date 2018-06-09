using System;
using System.Collections.Generic;
using TheShop.Common;
using TheShop.Contracts.Interfaces;
using TheShop.Data;

namespace TheShop
{
	internal class Program
	{
        private static ShopService _shopService;
        private static List<ISupplier> _suppliers;

        private static void Main(string[] args)
		{
            CreateSuppliers();

            _shopService = new ShopService(new DatabaseDriver(), new Logger(), _suppliers);

            OrderAndSellArticle(1, 1000, 10);

            FindAndDisplayArticleOnConsole(1);

            FindAndDisplayArticleOnConsole(9);

            Console.ReadKey();
        }

        /// <summary>
        /// Creates a list of suppliers
        /// </summary>
        private static void CreateSuppliers()
        {
            SupplierFactory _supplierFactory = new SupplierFactory();
            _suppliers = new List<ISupplier>()
            {
                _supplierFactory.CreateFirstSupplier(new Article(1, "Article of first supplier", 458)),
                _supplierFactory.CreateSecondSupplier(new Article(1, "Article of second supplier", 459)),
                _supplierFactory.CreateThirdSupplier(new Article(1, "Article of third supplier", 460)),
            };
        }

        /// <summary>
        /// Displays an article on console, if it exists
        /// </summary>
        /// <param name="articleId">Article id</param>
        private static void FindAndDisplayArticleOnConsole(int articleId)
        {
            var article = _shopService.GetArticleById(articleId);

            Console.WriteLine(
                String.Format("{0}: {1}",
                article.ID != -1 ? "Found article with ID" : "Could not find article with ID", 
                articleId));
        }

        /// <summary>
        /// Orders and sell an article, if it exists
        /// </summary>
        /// <param name="articleId"> Article id</param>
        /// <param name="maxExpectedPrice">Max expected price</param>
        /// <param name="buyerId">Buyer id</param>
        private static void OrderAndSellArticle(int articleId, int maxExpectedPrice, int buyerId)
        {
            try
            {
                ISupplier supplier = _shopService.OrderArticle(articleId, maxExpectedPrice);

                if (supplier != null)
                {
                    _shopService.SellArticle(supplier, articleId, buyerId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}