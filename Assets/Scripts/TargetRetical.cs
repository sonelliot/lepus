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
				RaycastHit rayHit;
				Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rayHit);
		
				var mouseXPos = rayHit.point.x;
				var mouseYPos = rayHit.point.y;

				Vector3 reticalPosition = new Vector3 (){
			x = mouseXPos,
			y = mouseYPos,
			z = 0
		};

				m_transform.position = reticalPosition;
		}
}
