using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Contracts.Consts;
using TheShop.Contracts.Interfaces;
using TheShop.Data;
using TheShop.Utils;

namespace TheShop
{
    public class ShopService
	{
		private IDatabaseDriver _databaseDriver;
		private ILogger _logger;
        private ISupplierFactory _supplierFactory;
        private FirstSupplier _firstSupplier;
        private SecondSupplier _secondSupplier;
        private ThirdSupplier _thirdSupplier;

		public ShopService()
		{
			_databaseDriver = new DatabaseDriver();
			_logger = new Logger();
            _supplierFactory = new SupplierFactory();
            _firstSupplier = _supplierFactory.CreateFirstSupplier(new Article(1, "Article of first supplier", 458));
            _secondSupplier = _supplierFactory.CreateSecondSupplier(new Article(1, "Article of second supplier", 459));
            _thirdSupplier = _supplierFactory.CreateThirdSupplier(new Article(1, "Article of first supplier", 460));
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
			#region ordering article

            List<KeyValuePair<int?, ISupplier>> priceList = new List<KeyValuePair<int?, ISupplier>>();
            Article articleForSelling = new Article();
            ISupplier articleSupplier;

            if (_firstSupplier.HasArticleInInventory(id))
            {
                priceList.Add(new KeyValuePair<int?, ISupplier>(_firstSupplier.GetArticle(id).ArticlePrice, _firstSupplier));
            }

            if (_secondSupplier.HasArticleInInventory(id))
            {
                priceList.Add(new KeyValuePair<int?, ISupplier>(_secondSupplier.GetArticle(id).ArticlePrice, _secondSupplier));
            }

            if (_thirdSupplier.HasArticleInInventory(id))
            {
                priceList.Add(new KeyValuePair<int?, ISupplier>(_thirdSupplier.GetArticle(id).ArticlePrice, _thirdSupplier));
            }

            if (!priceList.Any())
            {
                _logger.WriteMessage(LogLevelConsts.INFO, String.Format("No article with id: {0} found.", id));
                Console.WriteLine(String.Format("No article with id: {0} found.", id));
                return;
            }

            if (priceList.Select(y => y.Key).OrderBy(x => x.Value).First() <= maxExpectedPrice)
            {
                articleSupplier = priceList.First().Value;
                articleForSelling = articleSupplier.GetArticle(id);
            }
            else
            {
                _logger.WriteMessage(LogLevelConsts.INFO, String.Format("No article with price lower than: {0} found.", maxExpectedPrice));
                Console.WriteLine(String.Format("No article with price lower than: {0} found.", maxExpectedPrice));
                return;
            }
            
			#endregion

			#region selling article

			_logger.WriteMessage(LogLevelConsts.DEBUG, String.Format("Trying to sell article with id = {0}, from supplier '{1}'.", id, articleSupplier.ToString()));

            articleForSelling.IsSold = true;
            articleForSelling.SoldDate = DateTime.Now;
            articleForSelling.BuyerUserID = buyerId;
			
			try
			{
				_databaseDriver.Save(articleForSelling);
                _logger.WriteMessage(LogLevelConsts.INFO, String.Format("Article with id = {0} is sold.", id));
			}
			catch (ArgumentNullException ex)
			{
                _logger.WriteMessage(LogLevelConsts.ERROR, String.Format("Could not save article with id = {0}.", id));
                throw new Exception(String.Format("Could not save article with id = {0}. \n Message: {1}", id, ex.Message));
			}

			#endregion
		}
	}
}
