namespace UM.Store
{
    public interface IItemPurchase
    {
        void PurchaseSuccess(IAPItem iAPItem);
        void PurchaseFail(IAPItem iAPItem);
    }
}