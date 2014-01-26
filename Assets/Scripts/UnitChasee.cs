using UnityEngine;
using System.Collections;

public class UnitChasee : Unit
{
		public GameObject gameController;
		public Transform[] Weapons;

		// Use this for initialization
		public override void Start ()
		{
				gameController = GameObject.Find ("GameController");
				base.Start ();
		}

		[RPC]
		void FireWeapon (Vector3 position, float angle, int weaponType, Vector3 forceDirection)
		{
				var obj = Instantiate (Weapons [weaponType], position, Quaternion.Euler (new Vector3 (0, 0, angle + 90)));

				if (obj != null) {
						var knifyScript = ((Transform)obj).gameObject.GetComponent<KnifeyScript> ();
						((KnifeyScript)knifyScript).ForceDirection = new Vector2 (forceDirection.x, forceDirection.y);
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
			
						if (Input.GetMouseButtonDown (0)) {
								var mouse_pos = Input.mousePosition;
								var object_pos = Camera.main.WorldToScreenPoint (transform.position);
								mouse_pos.x = mouse_pos.x - object_pos.x;
								mouse_pos.y = mouse_pos.y - object_pos.y;
								var angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
								var forceDirection = new Vector3 (mouse_pos.x,
				                                  mouse_pos.y, 0);

								networkView.RPC ("FireWeapon", RPCMode.AllBuffered, transform.position, angle, Random.Range (0, Weapons.Length), forceDirection);
						}
			
						base.Update ();
				}
		}
}
