 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FruitObject : MonoBehaviour
{

    private bool isHeld = false;
    public bool IsHeld { get { return isHeld; } }
    private FruitHolder holder;
    public FruitHolder GetHolder { get { return holder; } }

    private Rigidbody body;

    public void Start() {
        this.body = GetComponent<Rigidbody>();
    }

    public void PickUp(FruitHolder holder) {
        this.isHeld = true;
        this.holder = holder;

        this.transform.SetParent(holder.GetHoldTransform, false);
        this.transform.localPosition = Vector3.zero;

        this.body.isKinematic = true;

        Debug.Log("Picked up and holder is " + holder.name);
    }

    public void Throw(Vector3 direction, float force) {
        this.transform.SetParent(null);
        this.isHeld = false;
        this.holder = null;
        //this.transform.DOJump(this.transform.position + (direction * force), force/2, 1, 0.5f, false);
        //body.DOJump(this.transform.position + (direction * distance), 2, 1, 0.5f, false);
        this.body.isKinematic = false;
        this.body.AddForce(direction * force + new Vector3(0, force/2, 0), ForceMode.Impulse);

    }
    
    
}
