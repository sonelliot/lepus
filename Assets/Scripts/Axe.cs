using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {

	GameController controller;

	// Use this for initialization
	void Start () {
		controller = (GameController)GameObject.Find ("GameController").GetComponent<GameController>();
	}
	
	public void OnTriggerStay2D(Collision2D coll)
	{
		bool attacking = Input.GetMouseButtonDown(0);

		if (attacking && coll.gameObject.tag == "chasee")
		{
			controller.ChaserWin();
		}
	}
}
