# iOSLowPowerMode
Unity Plugin for iOS to detect if device is in Low Power Mode

This plugin helps to recieve notification callback when user turns on/off the low power mode option on iOS devices.

Steps for successful integration:
1. The signature for the callback function in your C# code should match "void lowPowerModeOn(string input)".
2. The name of the gameobject on which the script with the callback function is attached should match "Game Manager".
3. If you wish to change the name of the gameobject and the callback function, make sure it matches the first two parameters of the function call "UnitySendMessage("Game Manager", "lowPowerModeOn", cString);" inside the file "LowPowerModeDetector.mm" in Assets/Plugins/iOS/ folder.

Steps to test:
1. You will have to build the project on an iOS device.
2. Once the app runs, you will see a text that displays the current state of low power mode.
3. Go to Settings->Battery and toggle the low power mode option.
4. Come back to the app and you will see the text change to display the current toggled state.

FYI: The current callback function resides in "GameManager.cs" script attached to the "Game Manager" gameobject in the scene. If you want to use this project out-of-box then just add your custom code inside this callback.
