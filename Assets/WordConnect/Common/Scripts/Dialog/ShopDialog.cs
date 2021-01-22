#if IAP && UNITY_PURCHASING
using UnityEngine.Purchasing;
#endif
using UnityEngine.UI;
using UnityEngine;

public class ShopDialog : Dialog
{
    public Text[] numRubyTexts, priceTexts;

    protected override void Start()
    {
        base.Start();
#if IAP && UNITY_PURCHASING
        Purchaser.instance.onItemPurchased += OnItemPurchased;

        for(int i = 0; i < numRubyTexts.Length; i++)
        {
            numRubyTexts[i].text = Purchaser.instance.iapItems[i].value.ToString();
            priceTexts[i].text = Purchaser.instance.iapItems[i].price + "$";
        }
#endif
    }

    public override void Close()
    {
       // Debug.Log("Close shop");
        base.Close();
        
           // DialogController.instance.ShowDialog(DialogType.PromotePopup);
       
    }

    public void OnBuyProduct(int index)
	{
#if IAP && UNITY_PURCHASING
        Sound.instance.PlayButton();
        Purchaser.instance.BuyProduct(index);
#else
        Debug.LogError("Please enable, import and install Unity IAP to use this function");
#endif
    }

#if IAP && UNITY_PURCHASING
    private void OnItemPurchased(IAPItem item, int index)
    {
        // A consumable product has been purchased by this user.
        if (item.productType == ProductType.Consumable)
        {
            CurrencyController.CreditBalance(item.value);
            Toast.instance.ShowMessage("Your purchase is successful");
            CUtils.SetBuyItem();
        }
        // Or ... a non-consumable product has been purchased by this user.
        else if (item.productType == ProductType.NonConsumable)
        {
            // TODO: The non-consumable item has been successfully purchased, grant this item to the player.
        }
        // Or ... a subscription product has been purchased by this user.
        else if (item.productType == ProductType.Subscription)
        {
            // TODO: The subscription item has been successfully purchased, grant this to the player.
        }
    }
#endif

#if IAP && UNITY_PURCHASING
    private void OnDestroy()
    {
        Purchaser.instance.onItemPurchased -= OnItemPurchased;
    }
#endif
}
