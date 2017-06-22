using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	void Start () {
        RuntimePlatform rp = Application.platform;

        if (rp == RuntimePlatform.Android)
        {
            gameObject.AddComponent<TouchInput>();
        }
        else if(rp == RuntimePlatform.WindowsEditor || rp == RuntimePlatform.WindowsPlayer || rp == RuntimePlatform.WebGLPlayer)
        {
            gameObject.AddComponent<MouseInput>();
        }
	}
}
