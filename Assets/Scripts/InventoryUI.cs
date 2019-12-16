using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public PlayerInventory targetInventory;

    public void OnInventoryChanged() {
        //InventoryToDictionary(targetInventory.heldItems);
        UpdateImageGroups();
    }

    public GameObject imageGroupPanelPrefab;

    //public Dictionary<PickupableTypes, int> groups = new Dictionary<PickupableTypes, int>();

    //public void InventoryToDictionary(List<PickupableTypes> inventory) {
    //    groups.Clear();
    //    foreach (PickupableTypes p in inventory) {
    //        if (groups.ContainsKey(p))
    //        {
    //            groups[p] += 1;
    //        }
    //        else {
    //            groups.Add(p, 1);
    //        }
    //    }

    //    foreach (PickupableTypes p in groups.Keys) {
    //        Debug.Log(p.name + ": " + groups[p] + ",");
    //    }
    //}

    public void CreateImage(PickupableTypes p, Transform parent, int num) {
        for (int i = 0; i < num; i++)
        {
            //Debug.Log("Creating image");
            Image newImage = new GameObject().AddComponent<Image>();
            newImage.transform.SetParent(parent, false);

            newImage.sprite = p.icon;
        }
    }

    public void UpdateImageGroups() {
        //Debug.Log("Updating image groups");
        Dictionary<PickupableTypes, int> groups = targetInventory.heldItemsDict;
        foreach (PickupableTypes p in groups.Keys)
        {
            //Debug.Log("Looking at type " + p.name);
            bool exists = false;
            for (int i = 0; i < this.transform.childCount; i++)
            {
                //Debug.Log("Looking at child " + i);
                if (transform.GetChild(i).name == p.name)
                {
                    //Debug.Log("Found child with name " + p.name);
                    exists = true;
                    if (transform.GetChild(i).childCount == groups[p])
                    {
                        //Debug.Log("Child has correct number of images");
                        continue;
                    }
                    else
                    {
                        //Debug.Log("Wrong number of images!");
                        foreach (Transform childchild in transform.GetChild(i))
                        {
                            Destroy(childchild.gameObject);
                        }
                        
                        CreateImage(p, transform.GetChild(i), groups[p]);
                    }
                }
            }
            if (exists == false)
            {
                //Debug.Log("Creating new panel for " + p.name);
                GameObject newPanel = GameObject.Instantiate(imageGroupPanelPrefab);
                newPanel.transform.SetParent(this.transform, false);
                newPanel.name = p.name;

                CreateImage(p, newPanel.transform, groups[p]);
            }
        }
    }
}
