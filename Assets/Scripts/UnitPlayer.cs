using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit
{
	public GameObject projectilePrefab;

	// Use this for initialization
	public override void Start ()
	{
		base.Start();
	}

	void OnGUI()
	{
		//move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		//GUI.TextArea(new Rect(100,100,100,100), string.Format("Move X: {0}\n Move Y: {1}", move.x, move.y));
	}

	// Update is called once per frame
	public override void FixedUpdate ()
	{
		//Movement shiat
		move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		move.Normalize();

		if(Input.GetKeyDown("space"))
	   	{
			Instantiate(projectilePrefab, transform.position, Quaternion.identity);
		}

		base.FixedUpdate();
	}

}
