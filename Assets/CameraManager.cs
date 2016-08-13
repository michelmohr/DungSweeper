using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {

    [SerializeField] List<GameObject> Windows = new List<GameObject>();
    [SerializeField] bool StartAtZero = true;

    void Start() {
        if(StartAtZero) transform.position = Windows[0].transform.position + new Vector3(0,0,-10);
    }

    public void MoveCamera(int i) {
        iTween.MoveTo(gameObject, Windows[i].transform.position + new Vector3(0,0,-10),0.3f);
    }
}
