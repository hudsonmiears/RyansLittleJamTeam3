using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletUpdater : MonoBehaviour
{

    public TextMeshProUGUI text;
    public PlayerInventory inventory;

    public void OnWalletChanged() {
        this.text.text = inventory.wallet.ToString() + " frogbucks";
    }
}
