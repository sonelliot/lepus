using UnityEngine;
using System.Collections;

/// <summary>
/// Simple camera movement script for testing.
/// </summary>
public class CameraMove : MonoBehaviour {

	Transform _cameraPosition;

	// Use this for initialization
	void Start () {
		_cameraPosition = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		const float moveSpeed = 0.5f;

		var horizontal = Input.GetAxis ("Horizontal");
		var vertical = Input.GetAxis("Vertical");

		_cameraPosition.position = new Vector3(
			_cameraPosition.position.x + (horizontal * moveSpeed),
			_cameraPosition.position.y + (vertical * moveSpeed),
			_cameraPosition.position.z);
	}
}
