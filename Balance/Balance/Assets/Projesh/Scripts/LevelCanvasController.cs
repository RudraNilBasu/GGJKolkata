using UnityEngine;
using System.Collections;

public class LevelCanvasController : MonoBehaviour {

	public static LevelCanvasController reference;

	public GameObject winPanel;
	public GameObject losePanel;

	private void Awake () {
		if (reference == null) {
			reference = this;
			DontDestroyOnLoad (this.gameObject);
		}
		if (reference != this) {
			Destroy (this.gameObject);
		}
	}

	public void ShowLosePanel () {
		winPanel.SetActive (false);
		losePanel.SetActive (true);
	}

	public void ShowWinPanel () {
		winPanel.SetActive (true);
		losePanel.SetActive (false);
	}

	public void CloseAllPanel () {		
		winPanel.SetActive (false);
		losePanel.SetActive (false);
	}

	public void Restart () {
		LevelLoader.reference.RestartLevel ();
		CloseAllPanel ();
	}

	public void Menu () {
		LevelLoader.reference.LoadLevel (0);
		CloseAllPanel ();
	}

	public void Next () {
		LevelLoader.reference.NextLevel ();
		CloseAllPanel ();
	}
}

//LevelCanvasController.reference.ShowWinPanel () <-- for win panel
//LevelCanvasController.reference.ShowLosePanel () <-- for loose panel
//LevelCanvasController.reference.CloseAllPanel () <-- for closing all panels