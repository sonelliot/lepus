using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
		public GameObject gameController;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void OnGUI ()
		{
				GUI.Box (new Rect (10, 10, 300, 100), "");

				GUI.Label (new Rect (20, 20, 300, 30), "Game Time: " + gameController.GetComponent<GameController> ().timeRemaining);

		
				GUI.Label (new Rect (20, 50, 300, 30), "Game Stsate: " + gameController.GetComponent<GameController> ().state.ToString ());

				if (gameObject.GetComponent<GameController> ().state == GameController.GameState.COUNT_DOWN) {
						CountDownGUI ();
				}
		}

		public void CountDownGUI ()
		{

		}

}
