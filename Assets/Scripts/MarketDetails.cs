using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MarketDetails", menuName = "ScriptableObjects/MarketDetails", order = 2)]
public class MarketDetails : ScriptableObject
{
    public string name;
    public PickupableTypes favoriteItem;
    public float moneyPerItem;
}
