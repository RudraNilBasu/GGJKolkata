using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour {

	[Header ("Menu Panels")]
	public GameObject mainPanel;
	public GameObject helpPanel;
	public GameObject aboutPanel;
	public GameObject levelsPanel;

	private Animator mainPanelAnim;
	private Animator helpPanelAnim;
	private Animator aboutPanelAnim;
	private Animator levelsPanelAnim;

	private void Start () {
		Initialize ();
	}

	private void Initialize () {
		mainPanel.SetActive (true);
		helpPanel.SetActive (true);
		aboutPanel.SetActive (true);
		levelsPanel.SetActive (true);

		mainPanelAnim = mainPanel.GetComponent <Animator> ();
		helpPanelAnim = helpPanel.GetComponent <Animator> ();
		aboutPanelAnim = aboutPanel.GetComponent <Animator> ();
		levelsPanelAnim = levelsPanel.GetComponent <Animator> ();

		helpPanelAnim.SetTrigger ("Left");
		aboutPanelAnim.SetTrigger ("Right");
		levelsPanelAnim.SetTrigger ("Up");
	}

	public void PlayButton () {
	}

	public void HelpButton () {
		mainPanelAnim.SetTrigger ("Right");
		helpPanelAnim.SetTrigger ("Centre");
		UnityStandardAssets.ImageEffects.BloomController.reference.highLimitModifier = 1;
	}

	public void AboutButton () {
		mainPanelAnim.SetTrigger ("Left");
		aboutPanelAnim.SetTrigger ("Centre");
		UnityStandardAssets.ImageEffects.BloomController.reference.highLimitModifier = 1;
	}

	public void LevelsButton () {		
		mainPanelAnim.SetTrigger ("Down");
		levelsPanelAnim.SetTrigger ("Centre");
		UnityStandardAssets.ImageEffects.BloomController.reference.highLimitModifier = 1;
	}

	public void CloseHelpButton () {
		mainPanelAnim.SetTrigger ("Centre");
		helpPanelAnim.SetTrigger ("Left");
		UnityStandardAssets.ImageEffects.BloomController.reference.highLimitModifier = 2;
	}

	public void CloseAboutButton () {
		mainPanelAnim.SetTrigger ("Centre");
		aboutPanelAnim.SetTrigger ("Right");
		UnityStandardAssets.ImageEffects.BloomController.reference.highLimitModifier = 2;
	}

	public void CloseLevelsButton () {
		mainPanelAnim.SetTrigger ("Centre");
		levelsPanelAnim.SetTrigger ("Up");
		UnityStandardAssets.ImageEffects.BloomController.reference.highLimitModifier = 2;
	}
}
