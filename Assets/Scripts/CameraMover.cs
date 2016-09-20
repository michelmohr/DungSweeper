using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

    static CameraMover _instance;

    void Awake() {
        if(_instance==null) {
            _instance = this;
            Helper.LogCol("// WindowManager set", "green");
        }else if(_instance!=this) {
            Destroy(this);
        }
    }

    public static void TeleportCameraToWindow(Window window) {
        //supply the Window by calling WindowManager.GetWindow(string name)
    }
}
