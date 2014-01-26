using UnityEngine;
using System.Collections;

public class SetupClouds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Cloud";
		particleSystem.renderer.sortingLayerID = 5;
	}
}
