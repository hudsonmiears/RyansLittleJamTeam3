using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitHolder : MonoBehaviour
{

    private FruitObject heldFruit;
    public FruitObject GetFruit { get { return heldFruit; } }
    bool holdBuffer = false;

    public float throwForce;

    [SerializeField]
    private Transform holdTransform;

    public Transform GetHoldTransform { get { return holdTransform; } }

    public void OnTriggerStay(Collider col) { 
        if (col.gameObject.TryGetComponent(out FruitObject fruit)) {
            if (fruit.IsHeld)
            {
                return;
            }
            else {
                if (Input.GetButtonDown("Jump"))
                {
                    fruit.PickUp(this);
                    this.heldFruit = fruit;
                    holdBuffer = true;
                }
            }
        }
    }

    public void Update() {
        if (heldFruit != null) {
            if (Input.GetButtonDown("Jump"))
            {
                if (holdBuffer) {
                    holdBuffer = false;
                    return;
                }
                heldFruit.Throw(transform.right, throwForce) ;
                this.heldFruit = null;
            }
        }
    }
}
