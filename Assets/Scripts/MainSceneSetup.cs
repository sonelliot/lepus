using UnityEngine;
using System.Collections;

public class MainSceneSetup : MonoBehaviour
{
	public GameObject PlayerPrefab;
	public GameObject AI_Prefab;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
	}

	void OnLevelWasLoaded (int lvl)
	{
		if (Network.isServer) {
			GameProperties.Inst.Chaser = true;
			Network.Instantiate (AI_Prefab, Vector3.up * 2, Quaternion.identity, 0);
		} else {
			GameProperties.Inst.Chasee = true;
		}

		GameProperties.Inst.Player = (GameObject)Network.Instantiate (PlayerPrefab, Vector3.up * 2, Quaternion.identity, 0);
	}
}
