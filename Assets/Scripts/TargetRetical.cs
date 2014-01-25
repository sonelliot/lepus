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

    void OnGUI ()
    {
        if (GameProperties.Inst.Player != null)
        {
            //var aimDir = GameProperties.Inst.Player.GetComponent<UnitChaser> ().AimDirection ();

            //GUI.TextArea (new Rect (50, 50, 100, 100), string.Format ("Aim X: {0}\n Aim Y: {1}", aimDir.x, aimDir.y));
            //GUI.TextArea(new Rect(100,200,500,100), string.Format("Mouse X: {0}, Mouse Y: {1}", Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    // Update is called once per frame
    void Update ()
    {
		var pos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
		
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
