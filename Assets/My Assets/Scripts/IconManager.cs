using System;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {
	public string food;
	private Image image;

	void Start() {
		image = GetComponent<Image>();
	}

	public string TrackedFood {
		set {
			image.enabled = !String.IsNullOrEmpty(value);
			if (image.enabled) image.sprite = Resources.Load<UnityEngine.Sprite> ("Images/" + value);
			food = value;
		}
	}
}