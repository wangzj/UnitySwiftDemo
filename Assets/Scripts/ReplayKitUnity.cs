using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class ReplayKitUnity : MonoBehaviour {

	[DllImport("__Internal")]
	private static extern void _rp_startRecording ();

	void Start () {
		Debug.Log ("[IOSToUnity] Start: begin calling ios function");
		#if UNITY_IOS && !UNITY_EDITOR
		_rp_startRecording ();
		#endif
	}

	void SayHi (string message) {
		Debug.Log ("[IOSToUnity] SayHi: " + message);
	}
}
