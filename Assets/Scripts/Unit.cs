using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    protected Vector2 move = Vector2.zero;
    protected Transform _transform;

    // Use this for initialization
    public virtual void Start ()
    {
        _transform = GetComponent<Transform> ();
    }

    // Update is called once per frame
    public virtual void FixedUpdate ()
    {
        if (GetComponent<NetworkView> ().isMine)
        {
            _transform.position += new Vector3 (move.x * movementSpeed, move.y * movementSpeed, 0);
        }
    }

    public Vector2 AimDirection ()
    {
        var mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
        var playerPosition = new Vector2 (Screen.width * 0.5f, Screen.height * 0.5f);
        var aimDir = (mousePosition - playerPosition).normalized;
		
        return aimDir;
    }
}
