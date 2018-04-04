using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class CardChecker : MonoBehaviour {
	[Header("Tracking")]
	[Tooltip("The GameObject that contains the ImageTargets")][SerializeField] private GameObject trackables;
	[Tooltip("Objects currently being tracked")] public List<TestTrackableEventHandler> trackedObjects;

	[Header("UI")]
	private IconManager foodIcon;
	[Tooltip("The icons for found pairs")][SerializeField] private UnityEngine.UI.Image[] foundIcons = new UnityEngine.UI.Image[8];
	private Text text;

	[Header("Scores")]
	private int score = 0;
	public int Score {
		get {
			return score;
		}
	}

	private CardSceneManager sceneManager;

	// Use this for initialization
	void Start () {
		trackedObjects = new List<TestTrackableEventHandler>();

		TestTrackableEventHandler[] handlers = trackables.GetComponentsInChildren<TestTrackableEventHandler> ();
		foreach (TestTrackableEventHandler handler in handlers)
			handler.cardChecker = this;
		
		foodIcon = GetComponentInChildren<IconManager>();

		text = GetComponentInChildren<Text>();

		sceneManager = GetComponent<CardSceneManager> ();
		sceneManager.StartScene ();
	}
	
	// Update is called once per frame
	void Update () {
		int trackedCount = trackedObjects.Count;
		text.text = "Found: " + score + " / " + foundIcons.Length + " pairs";
		if (trackedCount > 2) {
			//O jogador está trapaceando se levantar mais de 2 cartões
			sceneManager.CatchCheat();
			score = 0;
		} else if (trackedCount == 2) {
			if (trackedObjects[0].name.Split(' ')[0] == trackedObjects[1].name.Split(' ')[0])
				FoundPair(trackedObjects[0].name.Split(' ')[0]);
			foodIcon.TrackedFood = null;
		} else if (trackedCount == 1) {
			foreach (TestTrackableEventHandler handler in trackedObjects) {
				foodIcon.TrackedFood = handler.name.Split(' ')[0];

				//FoundPair (handler.name.Split (' ') [0]);
			}
		} else foodIcon.TrackedFood = null;
	}

	void FoundPair(string pairName) {
		for (int i = 0; i < foundIcons.Length; i++) {
			if ((foundIcons[i] != null) && (foundIcons [i].name == pairName)
					&& !foundIcons[i].enabled && !sceneManager.isPaused()) {
				foundIcons[i].enabled = true;
				score++;
			}
		}
		if (score == foundIcons.Length) sceneManager.finishLevel();
	}
}