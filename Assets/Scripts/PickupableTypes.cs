using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickupableType", menuName = "ScriptableObjects/PickupableTypes", order = 1)]
public class PickupableTypes : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
    public float cost;
}
