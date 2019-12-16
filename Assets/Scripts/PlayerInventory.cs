using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{

    public Transform goToTransform;
    public float wallet = 0;

    //public List<PickupableTypes> heldItems = new List<PickupableTypes>();
    public Dictionary<PickupableTypes, int> heldItemsDict = new Dictionary<PickupableTypes, int>();

    public UnityEvent onInventoryChanged;

    public UnityEvent onWalletChanged;

    public GameManager gm;

    public void OnEnable() {
        gm = GameObject.FindObjectOfType<GameManager>();
        if (heldItemsDict != null) heldItemsDict.Clear();
        wallet = 0;
        gm.timer = gm.startTime;
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.TryGetComponent(out Pickupable pickup))
        {
            if (Input.GetButtonDown("Jump"))
            {
                AddToHeldItems(pickup);
                
            }
        }

        if (col.gameObject.TryGetComponent(out MarketStall marketStall)) {
            if (Input.GetButtonDown("Jump")) {
                marketStall.SellToMarket(this);
            }
        }
    }

    public void AddToHeldItems(Pickupable pickup) {
        //heldItems.Add(pickup.pickupableType);
        if (heldItemsDict.ContainsKey(pickup.pickupableType))
        {
            heldItemsDict[pickup.pickupableType] += 1;
        }
        else {
            heldItemsDict.Add(pickup.pickupableType, 1);
        }
        pickup.PickUp(this);
        onInventoryChanged.Invoke();
    }

    public void RemoveItemAndPay(PickupableTypes p, float paymentEach) {
        wallet += heldItemsDict[p] * paymentEach;
        heldItemsDict[p] = 0;
        onInventoryChanged.Invoke();
        onWalletChanged.Invoke();
        gm.playerWallet = wallet;
        Debug.Log("Wallet has " + wallet);
    }
}
