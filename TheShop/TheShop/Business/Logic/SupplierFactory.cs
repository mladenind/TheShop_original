﻿using TheShop.Contracts.Interfaces;

namespace TheShop
{
    public class SupplierFactory : ISupplierFactory
    {
        public FirstSupplier CreateFirstSupplier(Article article)
        {
            return new FirstSupplier(article);
        }

        public SecondSupplier CreateSecondSupplier(Article article)
        {
            return new SecondSupplier(article);
        }

        public ThirdSupplier CreateThirdSupplier(Article article)
        {
            return new ThirdSupplier(article);
        }
    }
}
