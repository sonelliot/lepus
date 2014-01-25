using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class KnifeyScript : MonoBehaviour
{
	void Start ()
	{
		var mouse_pos = Input.mousePosition;
		var object_pos = Camera.main.WorldToScreenPoint(transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;

		//rigidbody2D.transform.rotation = transform.rotation;
		rigidbody2D.AddForce(new Vector2(mouse_pos.x * 500f,
		                                 mouse_pos.y * 500f));
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}
}
