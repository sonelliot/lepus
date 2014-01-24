using UnityEngine;
using System.Collections;

public class TargetRetical : MonoBehaviour
{
	public UnitPlayer player;
	protected Transform m_transform;

	// Use this for initialization
	void Start ()
	{
		m_transform = GetComponent<Transform>();
	}

	void OnGUI()
	{
		RaycastHit rayHit;
		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit);
		
		var mouseXPos = rayHit.point.x;
		var mouseYPos = rayHit.point.z;
		GUI.TextArea(new Rect(100,100,500,100), string.Format("Mouse X: {0}, Mouse Z: {1}",Mathf.Abs(player.transform.position.x - mouseXPos),
		                                                      Mathf.Abs(player.transform.position.y - mouseYPos)));
	}
	// Update is called once per frame
	void Update ()
	{
		RaycastHit rayHit;
		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit);
		
		var mouseXPos = rayHit.point.x;
		var mouseYPos = rayHit.point.z;

		Vector3 reticalPosition = new Vector3(){
			x = mouseXPos,
			y = 0,
			z = mouseYPos
		};

		m_transform.position = reticalPosition;
	}

	// Gets the normalised 'aiming' vector
	public Vector3 AimDirection
	{
		get
		{
			// We need to specify a z position to correctly use the ScreenToWorldPoint function,
			// so work our how far away the camera is to 0 on the z plane..
			var mousePos = Input.mousePosition;
			mousePos.z = -Camera.main.transform.position.z;
			mousePos.x = -Camera.main.transform.position.x;

			var mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePos);
			return (mousePointInWorld - player.transform.position).normalized;
		}
	}
}
