using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WindowManager : MonoBehaviour {

    //this  class is for moving the camera.
    
    List<Window> _windows;
    
    static WindowManager _instance; 

    void Awake() {
        if(_instance==null) {
            _instance = this;
            Helper.LogCol("// WindowManager set", "green");
        }else if(_instance!=this) {
            Destroy(this);
        }
    }

    public static void RegisterWindow(Window window) {
        List<Window> windows = _instance._windows;

        if(windows==null) windows = new List<Window>();
        if(!windows.Contains(window)) {
            windows.Add(window);
        }
    }

    public static Window GetWindow(string name) {
        return _instance._windows.First(window => window.WindowName == name);
    }
}
