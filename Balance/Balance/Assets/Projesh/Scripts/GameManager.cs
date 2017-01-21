using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager reference;

	private void Awake () {
		if (reference == null) {
			reference = this;
		}
		if (reference != this) {
			Destroy (this.gameObject);
		}
	}
}
