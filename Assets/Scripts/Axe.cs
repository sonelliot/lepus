using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {

	GameController controller;

	UnitChasee chasee;

	// Use this for initialization
	void Start () {
		controller = (GameController)GameObject.Find ("GameController").GetComponent<GameController>();
	}

	void Update()
	{
		if (chasee == null)
		{
			chasee = GameObject.FindObjectOfType<UnitChasee>();
		}

		Vector3 toChasee = chasee.transform.position - transform.position;

		if (toChasee.magnitude < 3f && Input.GetMouseButtonDown(0))
		{
			controller.ChaserWin();
		}
	}
}	
