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
				// Does the topmost game object have the "Allow stickables" script attached?
				var topMostGameObject = collision.gameObject.transform.root.gameObject;
				bool canStick = topMostGameObject.GetComponent<AllowStickables> () != null;

				if (canStick) {
						//gameObject.GetComponent<SetParentObject>().SetParent(
						GetComponent<SetParentObject> ().SetParent (topMostGameObject);
						gameObject.rigidbody2D.isKinematic = true;
						gameObject.collider2D.enabled = false;
						//gameObject.transform.parent = topMostGameObject.transform;
				}		
		}
}
