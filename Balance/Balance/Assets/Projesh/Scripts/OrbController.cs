using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (CircleCollider2D))]
public class OrbController : MonoBehaviour {

	public static OrbController reference;

	[Header ("Horizontal Speed")]
	public float hSpeed = 5F;

	private Rigidbody2D rb;
	private int gravityFactor;

	private void Awake () {
		if (reference == null) {
			reference = this;
		}
		if (reference != this) {
			Destroy (this.gameObject);
		}
	}

	private void Start () {
		rb = GetComponent <Rigidbody2D> ();
		gravityFactor = 0;
		rb.gravityScale = gravityFactor;
	}

	private void Update () {
		GetInput ();
	}

	private void FixedUpdate () {
		HorizontalMovement ();
	}

	private void GetInput () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			gravityFactor = (gravityFactor == 0) ? 1 : gravityFactor * -1;
			rb.gravityScale = gravityFactor;
		}
	}

	private void HorizontalMovement () {
		if (gravityFactor != 0) {
			rb.velocity = new Vector2 (hSpeed, rb.velocity.y);
		}
	}
}
