using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
		public float FollowStiffness = 10.0f;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (GameProperties.Inst.Player != null) {
						var player = GameProperties.Inst.Player;
						var targetVector = new Vector3 (player.transform.position.x, 
                                            player.transform.position.y,
                                            transform.position.z);

						transform.position = Vector3.Lerp (targetVector, transform.position, Mathf.Pow (0.98f, Time.deltaTime * 60f * FollowStiffness));
				}
		}
}
