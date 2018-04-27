using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameController {
	private static String filepath = Application.persistentDataPath + "/HighScores.dat";

	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(filepath);

		bf.Serialize(file, GameData.Instance);
		file.Close ();
	}

	public static void Load() {
		if (File.Exists (filepath)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (filepath, FileMode.Open);

			GameData.Instance = (GameData)bf.Deserialize(file);
			file.Close ();
		}
	}

	public static void Reset() {
		File.Delete (filepath);
		GameData.Instance = null;
	}
}