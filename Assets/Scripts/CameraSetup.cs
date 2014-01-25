using UnityEngine;
using System.Collections;

public class CameraSetup : MonoBehaviour {
	
	void Start () {

		Color GOOD_BACKGROUND = new Color(0.30f,0.29f,0.27f);
		Color BAD_BACKGROUND = new Color(0.35f,0.50f,0.32f);

		var camera = gameObject.camera;

		if (GameProperties.Inst.Chaser)
		{
			camera.backgroundColor = GOOD_BACKGROUND;
		}
		else
		{
			camera.backgroundColor = BAD_BACKGROUND;
		}
	}
}
