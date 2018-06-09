using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    /// <summary>
    /// Article for selling
    /// </summary>
    public class Article
    {
        #region Constructors

        public Article(int ID, string NameOfArticle, int? ArticlePrice, bool? IsSold, DateTime? SoldDate, int? BuyerUserId)
        {
            this.ID = ID;
            this.NameOfArticle = NameOfArticle;
            this.ArticlePrice = ArticlePrice;
            this.IsSold = IsSold;
            this.SoldDate = SoldDate;
            this.BuyerUserID = BuyerUserId;
        }
        
        public Article(int ID, string NameOfArticle, int ArticlePrice) 
            : this(ID, NameOfArticle, ArticlePrice, null, null, null)
        {

        }

        public Article()
            : this(-1, String.Empty, null, null, null, null)
        {

        }

        #endregion

        #region Properties

        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _nameOfArticle;

        public string NameOfArticle
        {
            get { return _nameOfArticle; }
            set { _nameOfArticle = value; }
        }

        private int? _articlePrice;

        public int? ArticlePrice
        {
            get { return _articlePrice; }
            set { _articlePrice = value; }
        }

        private bool? _isSold;

        public bool? IsSold
        {
            get { return _isSold; }
            set { _isSold = value; }
        }

        private DateTime? _soldDate;

        public DateTime? SoldDate
        {
            get { return _soldDate; }
            set { _soldDate = value; }
        }

        private int? _buyerUserID;

        public int? BuyerUserID
        {
            get { return _buyerUserID; }
            set { _buyerUserID = value; }
        }

        #endregion
    }
}
