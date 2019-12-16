using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pickupable : MonoBehaviour
{

    public PickupableTypes pickupableType;
    public bool isPickedUp = false;
    public Rigidbody body;

    private void Awake() {
        this.body = GetComponent<Rigidbody>();    
    }

    public void PickUp(PlayerInventory inventory) {
        if (isPickedUp == true) return;
        Sequence pickUpSequence = DOTween.Sequence();
        this.transform.DOJump(inventory.goToTransform.position, 5, 1, 0.5f, false).OnComplete(DestroySelf);
        isPickedUp = true;
        this.GetComponent<BoxCollider>().enabled = false;
        //Destroy(this.gameObject);
    }

    public void DestroySelf() {
        Destroy(this.gameObject);
    }

    public void Throw(Vector3 direction, float force)
    {
        this.body.AddForce(direction * force + new Vector3(0, force / 2, 0), ForceMode.Impulse);
    }
}
