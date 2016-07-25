using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text text;

	void OnEnable() {
		// check if low power mode is already on at start, and set the right text
		if(LowPowerMode.IsLowPowerModeOn()) {
			text.text = "Low Power Mode is ON.";
		} else {
			text.text = "Low Power Mode is OFF.";
		}

		// attaches the observer in Objective C code to listen to the low power mode change notification.
		LowPowerMode.AddObserverForLowPower();
	}

	void OnDisable() {
		// removes the observer in Objective C code that was listening to low power mode change notification.
		LowPowerMode.RemoveObserverForLowPower();
	}

	/// <summary>
	/// This function is called from "lowPowerModeCallback" callback function in LowPowerModeDetector.mm Objective C code, using UnitySendMessage.
	/// Use this function to handle your custom code when low power is turned on/off.
	/// </summary>
	/// <param name="boolString">"YES" if low power mode is turned on, else "NO".</param>
	void lowPowerModeOn(string boolString) {
		if(boolString.CompareTo("YES") == 0) {
			text.text = "Low Power Mode is ON.";
		} else {
			text.text = "Low Power Mode is OFF.";
		}
	}
}
