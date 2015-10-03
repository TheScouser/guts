using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        float input = Input.GetAxis("Vertical");
        float inputH = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * input);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * speed * inputH);

    }
}
