using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LevelCreator : MonoBehaviour
{
#if UNITY_EDITOR
		public bool Regenerate = false;
#endif
		public float SpatterDensity = 0.1f;
		public Transform[] Spatter;

		// Use this for initialization
		void Start ()
		{
				Generate ();
		}

		void Generate ()
		{
				if (Network.isServer &&
						Spatter.Length != 0) {
						Vector3 pos = transform.localPosition;
						float halfWidth = transform.localScale.x / 2f;
						float halfHeight = transform.localScale.y / 2f;
						float step = 0.1f;
						for (float x = pos.x - halfWidth; x < pos.x + halfWidth - step; x += step) {
								for (float y = pos.y - halfHeight; y < pos.y + halfHeight - step; y += step) {
										if (Random.value < SpatterDensity) {
												Transform p = (Transform)Network.Instantiate (Spatter [Random.Range (0, Spatter.Length)], new Vector3 (x + Random.Range (0f, step / 2f), y + Random.Range (0f, step / 2f), 0f), transform.localRotation, 0);
												p.parent = transform;
										}
								}
						}
				}
		}

#if UNITY_EDITOR
		void Clear ()
		{
				for (int i=transform.childCount-1; i>=0; --i) {
						var child = transform.GetChild (i).gameObject;
						DestroyImmediate (child);
				}
		}

		void Update ()
		{
				if (Regenerate) {
						Clear ();
						Generate ();
						Regenerate = false;
				}
		}
#endif
}