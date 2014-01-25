using UnityEngine;
using System.Collections;

public class UnitAIChump : Unit 
{
	public float noticeDistance = 20.0f;
	public float runDistance = 10.0f;
	public UnitPlayer player;
	protected bool _hasNoticed = false;
	
	// Use this for initialization
	public override void Start ()
	{
		_transform = GetComponent<Transform>();
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		if(GameProperties.Inst.Chaser)
		{
			var distanceFromPlayer = GameProperties.Inst.Player.transform.position - transform.position;
			
			_hasNoticed = distanceFromPlayer.magnitude < noticeDistance;
			
			if(_hasNoticed && distanceFromPlayer.magnitude < runDistance)
			{
				move = new Vector2(-(distanceFromPlayer.x * movementSpeed * Time.deltaTime), 
				                   -(distanceFromPlayer.y * movementSpeed * Time.deltaTime));
			}
			else
			{
				move = Vector2.zero;
			}
		}
		
		base.Update ();
	}
}
