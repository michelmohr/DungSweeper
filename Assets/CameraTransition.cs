using UnityEngine;
using System.Collections;

public class CameraTransition : MonoBehaviour {

    //[SerializeField] float TimeToTransition
    [SerializeField] Camera A, B;
    [SerializeField] bool AActive = true;


    public void Awake() {
        A.gameObject.SetActive(AActive);
        B.gameObject.SetActive(!AActive);
    }

    public void SwitchCamera() {
        AActive=!AActive;

        Camera camera   = AActive?A:B;
        int resWidth    = Screen.width;
        int resHeight   = Screen.height;

        RenderTexture rt        = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture    = rt; //Create new renderTexture and assign to camera
        Texture2D screenShot    = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false); //Create new texture

        camera.Render();

        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0); //Apply pixels from camera onto Texture2D

        camera.targetTexture = null;
        RenderTexture.active = null; //Clean
        Destroy(rt); //Free memory




        A.gameObject.SetActive(AActive);
        B.gameObject.SetActive(!AActive);
    }
}
