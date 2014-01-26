using UnityEngine;
using System.Collections;

public class MainSceneSetup : MonoBehaviour
{
		public GameObject PlayerPrefab;
		public GameObject PlayerChasee;
		public GameObject AI_Prefab;

		public GameObject gameController;

		// Use this for initialization
		void Start ()
		{
		}

		void OnLevelWasLoaded (int lvl)
		{
				if (Network.isServer) {
						GameProperties.Inst.Chaser = true;
						GameProperties.Inst.Player = (GameObject)Network.Instantiate (PlayerPrefab, Vector3.up * 2, Quaternion.identity, 0);
						
				} else {
						GameProperties.Inst.Chasee = true;
						GameProperties.Inst.Player = (GameObject)Network.Instantiate (PlayerChasee, Vector3.up * 2, Quaternion.identity, 0);
				}

				gameController.GetComponent<GameController> ().NotifyJoined ();
		}
}
