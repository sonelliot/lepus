using UnityEngine;
using System.Collections;

public class Sticky : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				bool canStick = collision.gameObject.GetComponent<AllowStickables> () != null;

				if (canStick) {
						// If we can stick to the object
						gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
						gameObject.GetComponent<BoxCollider2D> ().enabled = false;
						gameObject.transform.parent = collision.gameObject.transform;
				}		
		}
}
