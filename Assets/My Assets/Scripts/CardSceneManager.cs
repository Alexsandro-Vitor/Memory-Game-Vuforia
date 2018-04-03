using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardSceneManager : MonoBehaviour {
	[Tooltip("Paused Game screen")][SerializeField] private GameObject gamePaused;
	[Tooltip("Text of Paused Game screen")][SerializeField] private Text text;
	[Tooltip("Button for starting/finishing the level")][SerializeField] private Button btnContinue;
	[Tooltip("Button for exiting the level")][SerializeField] private Button btnBack;

	public bool isPaused() {
		return gamePaused.activeInHierarchy;
	}

	public void StartScene() {
		gamePaused.SetActive(true);
		text.text = "Flip the pairs of cards to win";
		btnBack.enabled = false;
		btnContinue.onClick.AddListener(StartLevel);
		btnContinue.GetComponentInChildren<Text>().text = "Start Game";
		btnBack.onClick.AddListener(Back);
	}

	void StartLevel() {
		gamePaused.SetActive(false);
		btnBack.enabled = true;
		btnBack.onClick.AddListener(Back);
	}

	public void finishLevel() {
		gamePaused.SetActive(true);
		text.text = "You win!";
		btnBack.enabled = false;
		btnContinue.onClick.RemoveAllListeners();
		btnContinue.onClick.AddListener(Back);
		btnContinue.GetComponentInChildren<Text>().text = "Back to Menu";
	}

	void Back() {
		Debug.Log("Clicked on Back");
		SceneManager.LoadScene("Main Menu");
	}

	public void CatchCheat() {
		gamePaused.SetActive(true);
		text.text = "You cheated! Game Over";
		btnBack.enabled = false;
		btnContinue.onClick.RemoveAllListeners();
		btnContinue.onClick.AddListener(Back);
		btnContinue.GetComponentInChildren<Text>().text = "Back to Menu";
	}
}