using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conv : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1f;
    public float Materialspeed = 10f;
    public Material mt;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        mt.mainTextureOffset = new Vector2(Time.time * Materialspeed * Time.deltaTime, 0f);
        Vector3 pos = rb.position;
        rb.position += Vector3.left * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
