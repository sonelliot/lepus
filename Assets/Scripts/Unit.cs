using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Unit : MonoBehaviour
{
	public float movementSpeed = 3.0f;
	protected CharacterController control;
	protected Vector3 move = Vector3.zero;

	// Use this for initialization
	public virtual void Start ()
	{
		control = GetComponent<CharacterController>();
		if(!control)
		{
			Debug.LogError ("Unit.Start() " + name + " has no character controller");
			enabled = false;
		}
	}

	// Update is called once per frame
	public virtual void Update ()
	{
		control.SimpleMove(move * movementSpeed);
	}
}
