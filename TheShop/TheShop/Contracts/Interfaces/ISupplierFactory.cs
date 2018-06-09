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
