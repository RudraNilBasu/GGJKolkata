using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.ImageEffects {

	public class BloomController : MonoBehaviour {

		public static BloomController reference;

		public Bloom b;
		public float flashSpeed = 2F;
		public float lowLimit = 0.1F;
		public float highLimit = 1F;

		[HideInInspector]
		public int highLimitModifier = 2; 

		private float lerpAmt;
		private bool doIncrease = true;

		private void Awake () {
			if (reference == null) {
				reference = this;
			}
			if (reference != this) {
				Destroy (this.gameObject);
			}
		}

		private void Update () {			
			lerpAmt = (doIncrease) ? lerpAmt + (flashSpeed * Time.deltaTime * 2F) : lerpAmt - (flashSpeed * Time.deltaTime * 0.5F);
			b.bloomIntensity = Mathf.Lerp (lowLimit, highLimit * highLimitModifier, lerpAmt);	

			if (lerpAmt > 1) {
				doIncrease = false;
			} else if (lerpAmt < 0.1F) {
				doIncrease = true;
			}
		}
	}
}
