using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class MainMenu : MonoBehaviour {

	[Tooltip("New Game button")][SerializeField] private Button btnNewGame;
	[Tooltip("Reset Highscores button")][SerializeField] private Button btnResetHighScore;
	[Tooltip("Exit Button")][SerializeField] private Button btnExit;
	[Tooltip("High Score")][SerializeField] private Text txtHighScore;

	// Desliga o Vuforia na tela inicial, adiciona as funções dos botões, e carrega os dados do jogo
	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		btnNewGame.onClick.AddListener(NewGame);
		btnResetHighScore.onClick.AddListener(ResetHighScore);
		btnExit.onClick.AddListener(Exit);
		GameController.Load();
		if (GameData.Instance.highScore == .0f) txtHighScore.text = "No Highscores";
		else txtHighScore.text = "Highscore: " + GameData.Instance.highScore + " secs";
	}

	void NewGame() {
		Debug.Log("Clicou em novo jogo");
		SceneManager.LoadScene("Scene1");
	}

	void ResetHighScore() {
		GameController.Reset ();
		txtHighScore.text = "No Highscores";
	}

	void Exit() {
		Debug.Log("Clicou em sair");
		Application.Quit();
	}
}
