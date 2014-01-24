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

	// Update is called once per frame
	void Update ()
	{
		RaycastHit rayHit;
		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit);

		var mouseXPos = rayHit.point.x;
		var mouseYPos = rayHit.point.z;

		Vector3 reticalPosition = new Vector3(){
			x = player.transform.position.x + mouseXPos,
			y = 0,
			z = player.transform.position.z + mouseYPos
		};

		if(Mathf.Abs(player.transform.position.x - mouseXPos) > 5 || 
		   Mathf.Abs(player.transform.position.y - mouseYPos) > 5)
		{
			m_transform.position = reticalPosition.normalized * 5;	
		}
		else
		{
			m_transform.position = reticalPosition;
		}
	}
}
