using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Contracts.Consts;
using TheShop.Contracts.Interfaces;

namespace TheShop
{
    public class ShopService
	{
		private IDatabaseDriver _databaseDriver;
		private ILogger _logger;
        private List<ISupplier> _suppliers;

		public ShopService(IDatabaseDriver databaseDriver, ILogger logger, List<ISupplier> suppliers)
		{
			_databaseDriver = databaseDriver;
			_logger = logger;
            _suppliers = suppliers;
		}

        public Article GetArticleById(int articleId)
        {
            return _databaseDriver.GetArticleByID(articleId);
        }

        public ISupplier OrderArticle(int id, int maxExpectedPrice)
        {
            List<KeyValuePair<int?, ISupplier>> priceList = new List<KeyValuePair<int?, ISupplier>>();

            foreach (ISupplier supplier in _suppliers)
            { 
                if (supplier.HasArticleInInventory(id))
                {
                    priceList.Add(new KeyValuePair<int?, ISupplier>(supplier.GetArticle(id).ArticlePrice, supplier));
                }
            }

            if (!priceList.Any())
            {
                _logger.WriteMessage(LogLevelConsts.INFO, String.Format("No article with ID: {0} found.", id));
                Console.WriteLine(String.Format("No article with ID: {0} found.", id));
                return null;
            }

            if (priceList.Select(y => y.Key).OrderBy(x => x.Value).First() <= maxExpectedPrice)
            {
                return priceList.First().Value;
            }
            else
            {
                _logger.WriteMessage(LogLevelConsts.INFO, String.Format("No article with price lower than: {0} found.", maxExpectedPrice));
                Console.WriteLine(String.Format("No article with price lower than: {0} found.", maxExpectedPrice));
                return null;
            }
        }

        public void SellArticle(ISupplier supplier, int articleId, int buyerId)
        {
            Article article = supplier.GetArticle(articleId);

            if (article.ID == -1)
            {
                throw new NullReferenceException("It's not allowed to sell empty articles!");
            }

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserID = buyerId;

            _logger.WriteMessage(LogLevelConsts.DEBUG, String.Format("Trying to sell article with ID: {0}, from supplier: '{1}'", article.ID, supplier.ToString()));

            try
            {
                _databaseDriver.SaveArticle(article);
                _logger.WriteMessage(LogLevelConsts.INFO, String.Format("Article with ID: {0} is sold. Supplier is: '{1}'", article.ID, supplier.ToString()));
            }
            catch (NullReferenceException ex)
            {
                _logger.WriteMessage(LogLevelConsts.ERROR, String.Format("Could not save article with ID: {0}.", article.ID));
                throw new Exception(String.Format("Could not save article with ID: {0}. \n Message: {1}", article.ID, ex.Message));
            }
        }
	}
}
