using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed );


    }
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			Destroy (other.gameObject);
		}

	}
    // Update is called once per frame
    void Update () {
	
	}
}
