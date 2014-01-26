using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
		public GameObject gameController;

		public GUITexture GetReady_Happy;

		public GUIText TimeRemainingText;

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
				var controller = gameController.GetComponent<GameController> ();

				GUI.Label (new Rect (20, 20, 300, 30), "Game Time: " + controller.timeRemaining);
				GUI.Label (new Rect (20, 50, 300, 30), "Game Stsate: " + controller.state.ToString ());


				
				if (controller.state == GameController.GameState.COUNT_DOWN) {
						GetReady_Happy.enabled = true;
				} else {
						GetReady_Happy.enabled = false;
				}
				
				if (controller.state == GameController.GameState.PLAYING) {
						TimeRemainingText.text = string.Format ("{0} SECONDS REMAINING!", (int)gameController.GetComponent<GameController> ().timeRemaining);
				} else {
						TimeRemainingText.enabled = false;
				}
				
		}

		public void CountDownGUI ()
		{

				//GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), GetReady_Happy);
		}

}
