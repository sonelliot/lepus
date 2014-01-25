using UnityEngine;
using System.Collections;

public class SetParentObject : MonoBehaviour
{

		public GameObject Parent;

		private Vector3 Offset = Vector3.zero;

		public void SetParent (GameObject parent)
		{
				Parent = parent;
				Offset = gameObject.transform.position - parent.transform.position;
		}

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void LateUpdate ()
		{
				if (Parent != null) {
						var offset = Offset;
						gameObject.transform.position = Parent.transform.position + offset;
				}
		}
}
