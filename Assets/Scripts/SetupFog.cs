using UnityEngine;
using System.Collections;

public class SetupFog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Fog";
		particleSystem.renderer.sortingLayerID = 4;
	}
}
