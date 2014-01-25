using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class KnifeyScript : MonoBehaviour
{
		public Vector2 ForceDirection;

		void Start ()
		{
				//if (GetComponent<NetworkView> ().isMine) {
				var mouse_pos = Input.mousePosition;
				var object_pos = Camera.main.WorldToScreenPoint (transform.position);
				mouse_pos.x = mouse_pos.x - object_pos.x;
				mouse_pos.y = mouse_pos.y - object_pos.y;
            
				const float FORCE_AMOUNT = 500.0f;

				//rigidbody2D.transform.rotation = transform.rotation;
				var forceDirection = ForceDirection.normalized;

				rigidbody2D.AddForce (forceDirection * FORCE_AMOUNT);
				//}/
		}

		// Update is called once per frame
		void Update ()
		{

		}
}
