using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

    public string WindowName = "default";

    void Awake() {
        WindowManager.RegisterWindow(this);
    }
}
