using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CameraManager : MonoBehaviour {

    [SerializeField] List<GameObject>   Windows = new List<GameObject>();
    [SerializeField] Material           TransitionMaterial;
    [SerializeField] float              TransitionTime = 1;
    [SerializeField] Texture            TransInTex; 
    [SerializeField] Texture            TransOutTex; 
    [SerializeField] bool               DisableOthers = true;
    [SerializeField] Color              FadeColor = new Color();


    int     CurrentActive     = 0;
    bool    TransitioningIn   = false;
    bool    TransitioningOut  = false;
    int     TransitioningTo   = 0;
    float   TransitionTimer   = 0;
    bool    FinishOff         = false;

    void Start() {
        CurrentActive=0;
        transform.position = Windows[CurrentActive].transform.position + new Vector3(0,0,-10);
        if(DisableOthers) {
            for(int i=0;i<Windows.Count;i++) {
                Windows[i].SetActive(i==CurrentActive);
            }
        }
        TransitionMaterial.SetColor("_Color", FadeColor);
    }

    public void MoveCamera(int i) {
        TransitioningTo = i;
        TransitionTimer = TransitionTime/2;
        TransitioningIn = true;
        TransitionMaterial.SetTexture("_TransitionTex", TransInTex);
    }

    void Update() {
        if(TransitioningIn) { 
            TransitionTimer -= Time.deltaTime;
            if(TransitionTimer<=0) {
                TransitioningOut = true;
                TransitioningIn = false;
                transform.position = Windows[TransitioningTo].transform.position + new Vector3(0,0,-10);
                TransitionTimer = TransitionTime/2;
                TransitionMaterial.SetTexture("_TransitionTex", TransOutTex);
                Windows[CurrentActive].SetActive(false);
                CurrentActive = TransitioningTo;
                Windows[CurrentActive].SetActive(true);
            }
        }else
        if(TransitioningOut) { 
            TransitionTimer -= Time.deltaTime;
            if(TransitionTimer<=0) {
                TransitioningOut = false;
                FinishOff = true;
                TransitionMaterial.SetFloat("_Cutoff", 0);
            }
        }
    }
    
    void OnRenderImage(RenderTexture src, RenderTexture dst){
         if(TransitionMaterial != null) {
            if(TransitioningIn) {
                TransitionMaterial.SetFloat("_Cutoff", 1-TransitionTimer/(TransitionTime/2));
                Graphics.Blit(src, dst, TransitionMaterial);
            }
            if(TransitioningOut) {
                TransitionMaterial.SetFloat("_Cutoff", TransitionTimer/(TransitionTime/2));
                Graphics.Blit(src, dst, TransitionMaterial);
            }
        }

        if(FinishOff) {
                Graphics.Blit(src, dst, TransitionMaterial);
            FinishOff = false;
        }
    }
}
