using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class MainMenu : MonoBehaviour {

	[Tooltip("New Game button")][SerializeField] private Button btnNewGame;
	[Tooltip("Exit Button")][SerializeField] private Button btnExit;

	// Use this for initialization
	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		btnNewGame.onClick.AddListener(NewGame);
		btnExit.onClick.AddListener(Exit);
	}

	void NewGame() {
		Debug.Log("Clicou em novo jogo");
		SceneManager.LoadScene("Scene1");
	}

	void Exit() {
		Debug.Log("Clicou em sair");
		Application.Quit();
	}
}
