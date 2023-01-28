using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    public static Take Instance;

    public Transform pos;
    public Transform BasketPoint;
    public bool InBasket;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void TakeObject()
    {
        _rb.isKinematic = true;
        _rb.MovePosition(pos.position);
    }

    public void DropObject(Transform basket)
    {
        _rb.isKinematic = false;
        _rb.freezeRotation = true;
        InBasket = true;
        BasketPoint = basket;
        this.gameObject.transform.position = basket.position;
        //_rb.AddForce(Camera.main.transform.forward * 500);
    }

    private void FixedUpdate()
    {
        if (_rb.isKinematic)
        {
            this.gameObject.transform.position = pos.position;
        }
        if (InBasket)
        {
            this.gameObject.transform.position = BasketPoint.position;
        }
    }
}
