using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;
namespace UM.Store {

    [CreateAssetMenu(fileName = "IAPstore", menuName = "ScriptableObjects/IAPstore", order = 1)]
    public class IAPstore : ScriptableObject, IStoreListener
    {
        [SerializeField] public List<IAPItem> IAPItems;
        private IStoreController _storeController;
        private IExtensionProvider _extensionProvider;
        private ConfigurationBuilder _configurationBuilder;
        private IItemPurchase _purchaseListener;
        public bool IAPInProgress;
        private StandardPurchasingModule _purchasingModule;
        private FakeStoreUIMode FakeStoreUIMode;
        [SerializeField] private RewardHandler RewardHandler;
        [SerializeField] private dynaimicPopup Prefab;
        //[SerializeField] private AdHandler _adHandler;
        //private IAPRecordBook IAPRecordBook;
        

        public bool IsInitialized
        {
            get
            {
                return _storeController != null && _extensionProvider != null;
            }
        }
        public void Initialize()
        {
            Debug.Log("[INFO] Initializing IAP store");
            SetupStoreConfigurationBuilder();
            if (!IsInitialized)
            {
                UnityPurchasing.Initialize(this, _configurationBuilder);
            }
        }

        public IAPItem GetIAPItem(string id)
        {
            return IAPItems.FirstOrDefault(x => x.SKU == id);
        }

        public Product GetProduct(string id)
        {
            var item = GetIAPItem(id);
            return item != null ? item.Product : null;
        }

        public bool PurchaseItemWithId(string id, IItemPurchase purchaseListener)
        {
            if (!IsInitialized) return false;
            if (_purchaseListener != null) return false;
            _purchaseListener = purchaseListener;
            _storeController.InitiatePurchase(id);
            IAPInProgress = true;
            //_rewardHandler.GiveReward(item);
            return true;
        }

        public bool PurcahseItem(IAPItem item, IItemPurchase purchaseListener)
        {

            return PurchaseItemWithId(item.SKU, purchaseListener);
            
        }


        private void SetupStoreConfigurationBuilder()
        {
            if (_configurationBuilder == null)
            {
                _purchasingModule = StandardPurchasingModule.Instance();
                _purchasingModule.useFakeStoreUIMode = FakeStoreUIMode;
                _configurationBuilder = ConfigurationBuilder.Instance(_purchasingModule);
                _configurationBuilder.AddProducts(IAPItems.Select(x => x.ProductDefinition));
            }
        }



        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            Debug.Log("[INFO][IAP] IAP Store initialized");
         
            _storeController = controller;
            _extensionProvider = extensions;
            AssignProductsToItems();

            if (RestorePurchases())
            {
                dynaimicPopup.ShowRestorePop("Restore Successful", Prefab);
            }
        }

        public void buttonrestore()
        {
            if (RestorePurchases())
            {
                dynaimicPopup.ShowRestorePop("Restore Successful", Prefab);
            }
        }

        public bool RestorePurchases()
        {
            if (!IsInitialized) 
            {
                return false;
            }
            else
            {
                _extensionProvider.GetExtension<IGooglePlayStoreExtensions>().RestoreTransactions(OnTransactionsRestored);
                return true;

            }
        }

        
        private void AssignProductsToItems()
        {
            for (int i = 0; i < IAPItems.Count; i++)
            {
                var item = IAPItems[i];
                item.Product = _storeController.products.WithID(item.SKU);
            }
        }
        void OnTransactionsRestored(bool success)
        {
            Debug.Log("[INFO][IAP] Restore Transactions completed.");
        }
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.LogError($"[ERROR][IAP] Purchasing failed to initialize. Reason: {error}");
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.LogError($"[ERROR][IAP] Product purchase failed. Product: {product.definition.id}. Reason: {failureReason}");

            if (failureReason == PurchaseFailureReason.DuplicateTransaction)
            {
                var prod = GetIAPItem(product.definition.id);
                _purchaseListener?.PurchaseSuccess(prod);
            }
            else
            {
                _purchaseListener?.PurchaseFail(GetIAPItem(product.definition.id));
            }

            _purchaseListener = null;
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            Debug.LogError($"[INFO][IAP] Product purchased. Product: {purchaseEvent.purchasedProduct.definition.id}.");

            if (_purchaseListener == null)
            {
                RewardHandler.GiveReward(GetIAPItem(purchaseEvent.purchasedProduct.definition.id));
            }
            else
                _purchaseListener?.PurchaseSuccess(GetIAPItem(purchaseEvent.purchasedProduct.definition.id));

            _purchaseListener = null;
            IAPInProgress = false;
            return PurchaseProcessingResult.Complete;
        }

    }
}
