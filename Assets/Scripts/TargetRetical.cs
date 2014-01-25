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
		var aimDir = player.AimDirection();

		GUI.TextArea(new Rect(50,50,100,100), string.Format("Aim X: {0}\n Aim Y: {1}", aimDir.x, aimDir.y));
		//GUI.TextArea(new Rect(100,200,500,100), string.Format("Mouse X: {0}, Mouse Y: {1}", Input.mousePosition.x, Input.mousePosition.y));
	}
	// Update is called once per frame
	void Update ()
	{
		RaycastHit rayHit;
		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit);
		
		var mouseXPos = rayHit.point.x;
		var mouseYPos = rayHit.point.y;

		Vector3 reticalPosition = new Vector3(){
			x = mouseXPos,
			y = mouseYPos,
			z = 0
		};

		m_transform.position = reticalPosition;
	}
}
