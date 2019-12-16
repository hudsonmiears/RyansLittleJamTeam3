using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketStall : MonoBehaviour
{

    public MarketDetails marketDetails;

    public void SellToMarket(PlayerInventory playerInventory) {
        foreach (PickupableTypes p in playerInventory.heldItemsDict.Keys) {
            if (p == marketDetails.favoriteItem) {
                playerInventory.RemoveItemAndPay(p, marketDetails.moneyPerItem);
                return;
            }
        }
    }
}
