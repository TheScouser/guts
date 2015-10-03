using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
	public float ShotTimer = 0.01f;
	public float nextFire = 0.0f;
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
		if (Input.GetMouseButton (0) && Time.time > nextFire) {
			nextFire = Time.time + ShotTimer;
			GameObject instance =(GameObject) Instantiate (bullet, transform.position , Quaternion.identity);
			instance.GetComponent<Rigidbody2D> ().AddForce (transform.forward * speed,ForceMode2D.Impulse);
		}

    }
}
