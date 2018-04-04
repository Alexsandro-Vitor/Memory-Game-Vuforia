using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraFocusController : MonoBehaviour {
	void Start() {    
		VuforiaARController vuforia = VuforiaARController.Instance;    
		vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);    
		vuforia.RegisterOnPauseCallback(OnPaused);
	}  

	private void OnVuforiaStarted() {    
		CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}

	private void OnPaused(bool paused) {    
		// resumed
		if (!paused) {
			// Set again autofocus mode when app is resumed
			CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);    
		}
	}
}