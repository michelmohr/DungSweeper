using UnityEngine;
using System.Collections;

public class ScreenTransitionData : ScriptableObject {

    //required
	public float    _time                       = 1f;
    public Texture  _transitionGradient;
    public Color    _fadeColour                 = new Color(0,0,0,1);

    //optional
    //public Texture _fadeTexture;
    //public string _textOverlay = "";
    //public AnimationCurve _speedCurve;



    //  * these are for non transition animations        *
    //  * for example a damage flash                     * 
    //  * because this doesn't cover the entire screen   *

        //         v      v
        //  *--------------------*
        //  instead of
        //  v             v
        //  *--------------------*
    public bool     _partialTransition          = false;
    public float    _partialTransitionLength    = 0.1f;

        //allow for parts of the gradient image to be ignored.
        //so not all of the screen has to have been covered at some point
    public Texture  _transitionAlpha;

}
