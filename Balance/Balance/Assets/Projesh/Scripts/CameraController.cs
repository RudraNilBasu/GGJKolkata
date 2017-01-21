using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public static CameraController reference;

	[Header ("Target Gameobject")]
	public GameObject target;

	private void Awake () {
		if (reference == null) {
			reference = this;
		}
		if (reference != this) {
			Destroy (this.gameObject);
		}
	}

	private void Update () {
		FollowTarget ();
	}

	private void FollowTarget () {
		transform.position = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);
	}
}
