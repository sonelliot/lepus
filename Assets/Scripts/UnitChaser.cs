using UnityEngine;
using System.Collections;

public class UnitChaser : Unit
{
		public GameObject gameController;
		private bool prevStrike;
		// Use this for initialization
		public override void Start ()
		{
				gameController = GameObject.Find ("GameController");
				base.Start ();
		}


		void OnGUI ()
		{
				//move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				//GUI.TextArea(new Rect(100,100,100,100), string.Format("Move X: {0}\n Move Y: {1}", move.x, move.y));
		}
    
		[RPC]
		void SetStrike (int strike)
		{
				if (anim) {
						anim.SetBool ("Strike", strike != 0);
				}
		}


		// Update is called once per frame
		public override void Update ()
		{
				if (GetComponent<NetworkView> ().isMine &&
						gameController.GetComponent<GameController> ().InputEnabled) {
						//Movement shiat
						move = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
						move.Normalize ();

						bool strike = Input.GetMouseButtonDown (0);

						if (anim && (prevStrike != strike)) {
								//Swing Weapon Here
								anim.SetBool ("Strike", strike);
								networkView.RPC ("SetStrike", RPCMode.AllBuffered, strike ? 2 : 0);
								prevStrike = strike;
						}

						base.Update ();
				}
		}
}
