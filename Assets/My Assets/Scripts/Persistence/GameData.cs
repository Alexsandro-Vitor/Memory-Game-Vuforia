using System;

[Serializable]
public class GameData {
	private static GameData instance;

	public static GameData Instance {
		get {
			if (instance == null) instance = new GameData();
			return instance;
		}
		set {
			instance = value;
		}
	}

	public float highScore;

	private GameData() {
		highScore = .0f;
	}

	public void updateHighScore(float newHighScore) {
		if (highScore == .0f) highScore = newHighScore;
		else highScore = Math.Min (newHighScore, highScore);
	}
}