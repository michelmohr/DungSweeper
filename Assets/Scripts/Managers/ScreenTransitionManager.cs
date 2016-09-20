using UnityEngine;
using System.Collections.Generic;

public class ScreenTransitionManager : MonoBehaviour {

    
    static ScreenTransitionManager _instance;

    ScreenTransitionData _transition;

    public static void SetTransition(ScreenTransitionData transition) {
        _instance._transition = transition;
    }

    public static void TriggerTransition() {

    }


    void Awake() {
        if(_instance==null) {
            _instance = this;
            Helper.LogCol("// ScreenTransitionManager set", "green");
        }else if(_instance!=this) {
            Destroy(this);
        }
    }
    




}
