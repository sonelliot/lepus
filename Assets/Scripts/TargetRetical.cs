using UnityEngine;
using System.Collections;

public class TargetRetical : MonoBehaviour
{
		protected Transform m_transform;

		// Use this for initialization
		void Start ()
		{
				m_transform = GetComponent<Transform> ();
		}

		// Update is called once per frame
		void Update ()
		{
				var pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
		
				var mouseXPos = pos.x;
				var mouseYPos = pos.y;

				Vector3 reticalPosition = new Vector3 (){
			x = mouseXPos,
			y = mouseYPos,
			z = 0
		};

				m_transform.position = reticalPosition;
		}
}
