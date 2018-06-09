using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheShop.Data;
using TheShop;
using TheShop.Common;
using System.Collections.Generic;
using TheShop.Contracts.Interfaces;

namespace TestShopService
{
    [TestClass]
    public class TestShopService
    {
        /// <summary>
        /// Saves an article to the DB, and sucessfully retrieves it
        /// </summary>
        [TestMethod]
        public void GetArticleById_Success()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver();
            Logger logger = new Logger();
            ShopService shopService = new ShopService(databaseDriver, logger, new List<ISupplier>());

            Article article = new Article()
            {
                ID = 10,
                NameOfArticle = "Silly hats",
                ArticlePrice = 100
            };

            databaseDriver.SaveArticle(article);

            Assert.AreEqual(10, shopService.GetArticleById(10).ID);
        }

        /// <summary>
        /// Tries to retrieve an non-existent item from the DB
        /// </summary>
        [TestMethod]
        public void GetArticleById_Failure()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver();
            Logger logger = new Logger();
            ShopService shopService = new ShopService(databaseDriver, logger, new List<ISupplier>());
            Assert.AreEqual(-1, shopService.GetArticleById(1).ID);
        }

        /// <summary>
        /// Orders an article with price inside the limitation
        /// </summary>
        [TestMethod]
        public void OrderArticle_Success()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver();
            Logger logger = new Logger();
            Article testArticle = new Article(1, "Test article", 100);
            ShopService shopService = new ShopService(databaseDriver, logger, new List<ISupplier>() { new FirstSupplier(testArticle) } );
            Assert.AreEqual("The first supplier", shopService.OrderArticle(1, 1000).ToString());

        }

        /// <summary>
        /// Orders an article with price below the limit
        /// </summary>
        [TestMethod]
        public void OrderArticle_Failure()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver();
            Logger logger = new Logger();
            ShopService shopService = new ShopService(databaseDriver, logger, new List<ISupplier>());
            Assert.AreEqual(null, shopService.OrderArticle(1, 100));
        }

        /// <summary>
        /// Sucessfully sells an existing article
        /// </summary>
        [TestMethod]
        public void SellArticle_Success()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver();
            Logger logger = new Logger();
            ShopService shopService = new ShopService(databaseDriver, logger, new List<ISupplier>());

            shopService.SellArticle(new FirstSupplier(new Article(1, "Test", 1)), 1, 9);
            Assert.AreEqual(9, databaseDriver.GetArticleByID(1).BuyerUserID);
        }

        /// <summary>
        /// Tries to sell a null Article
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SellArticle_Failure()
        {
            DatabaseDriver databaseDriver = new DatabaseDriver();
            Logger logger = new Logger();
            ShopService shopService = new ShopService(databaseDriver, logger, new List<ISupplier>());
            shopService.SellArticle(null, -1, 1);
        }
    }
}
