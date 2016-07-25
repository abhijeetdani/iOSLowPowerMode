using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class LowPowerMode {

	#if UNITY_IOS
		[DllImport("__Internal")]
		private static extern bool _IsLowPowerModeOn();

		[DllImport("__Internal")]
		private static extern void _AddObserverForLowPower();

		[DllImport("__Internal")]
		private static extern void _RemoveObserverForLowPower();
	#endif

	public static bool IsLowPowerModeOn() {
		#if UNITY_IOS
			return _IsLowPowerModeOn();
		#else
			return false;
		#endif
	}

	public static void AddObserverForLowPower() {
		#if UNITY_IOS
			_AddObserverForLowPower();
		#endif
	}

	public static void RemoveObserverForLowPower() {
		#if UNITY_IOS
			_RemoveObserverForLowPower();
		#endif
	}

}
