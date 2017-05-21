using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public static LevelLoader reference;

	private void Awake () {
		if (reference == null) {
			reference = this;
			DontDestroyOnLoad (this.gameObject);
		}
		if (reference != this) {
			Destroy (this.gameObject);
		}
	}

	public void LoadLevel (int index) {
		SceneManager.LoadScene (index);
		//LevelCanvasController.reference.CloseAllPanel ();
	}

	/*public void LoadLevel (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}*/

	public void RestartLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void NextLevel () {
		if (SceneManager.GetActiveScene ().buildIndex < 12) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		} else {
			SceneManager.LoadScene (0);
		}
	}
}
