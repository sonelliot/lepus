using UnityEngine;
using System.Collections;

public class FlipSpriteBasedOnDirection : MonoBehaviour
{
		private Vector3 LastPosition;

		private float MIN_MOVE_DISTANCE = 0.1f;

		// Use this for initialization
		void Start ()
		{
	
		}

		// Update is called once per frame
		void Update ()
		{
				NetworkView NV = gameObject.GetComponent<NetworkView> ();

				if (NV == null || NV.isMine) {
						if (LastPosition != null) {

								float moveAmount = (transform.position - LastPosition).magnitude;

								if (moveAmount > MIN_MOVE_DISTANCE) {
										if (transform.position.x < LastPosition.x) {
												transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
										} else {
												transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
										}
								}
	
						}
						LastPosition = transform.position;
				}
		}
}
