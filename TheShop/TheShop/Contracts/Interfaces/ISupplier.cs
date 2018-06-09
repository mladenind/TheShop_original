using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="Id"></param>
        /// <returns></returns>
        bool HasArticleInInventory(int Id);

        /// <summary>
        /// Gets the article from the supplier
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Article GetArticle(int Id);
    }
}
