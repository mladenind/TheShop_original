using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Contracts.Interfaces
{
    /// <summary>
    /// Interface for supplier factory
    /// </summary>
    public interface ISupplierFactory
    {
        FirstSupplier  CreateFirstSupplier(Article article);
        SecondSupplier CreateSecondSupplier(Article article);
        ThirdSupplier  CreateThirdSupplier(Article article);
    }
}
