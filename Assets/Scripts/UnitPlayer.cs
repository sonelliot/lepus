using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit
{
		public Transform[] Weapons;

		// Use this for initialization
		public override void Start ()
		{
				base.Start ();
		}

		void OnGUI ()
		{
				//move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				//GUI.TextArea(new Rect(100,100,100,100), string.Format("Move X: {0}\n Move Y: {1}", move.x, move.y));
		}

		// Update is called once per frame
		public override void Update ()
		{
				if (GetComponent<NetworkView> ().isMine) {
						//Movement shiat
						move = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
						move.Normalize ();

						if (Input.GetMouseButtonDown (0)) {
								var mouse_pos = Input.mousePosition;
								var object_pos = Camera.main.WorldToScreenPoint (transform.position);
								mouse_pos.x = mouse_pos.x - object_pos.x;
								mouse_pos.y = mouse_pos.y - object_pos.y;
								var angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

								Network.Instantiate (Weapons [Random.Range (0, Weapons.Length)], transform.position, Quaternion.Euler (new Vector3 (0, 0, angle + 90)), 0);
						}

						base.Update ();
				}
		}
}
