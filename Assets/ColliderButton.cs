using System;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ColliderButton : MonoBehaviour {
    
    //events
    [Serializable] public class ButtonClickedEvent : UnityEvent {}
    
    [FormerlySerializedAs("onDown")]
    [SerializeField] private ButtonClickedEvent m_OnDown = new ButtonClickedEvent();
    
    public ButtonClickedEvent onDown{
        get { return m_OnDown; }
        set { m_OnDown = value; }
    }

    [FormerlySerializedAs("onUp")]
    [SerializeField] private ButtonClickedEvent m_OnUp = new ButtonClickedEvent();
    
    //sprites
    [SerializeField] Sprite OnDownSprite, OnDisableSprite;
    [SerializeField] Sprite ToggledOnDownSprite, ToggledSprite;
    Sprite BaseSprite;
    [SerializeField] Vector3 OnDownMovement = Vector3.zero;
    [SerializeField] bool Toggleable = false;
	bool Disabled, Toggled;

    void Awake() {
		if(GetComponent<SpriteRenderer>())BaseSprite = GetComponent<SpriteRenderer>().sprite;
    }

    
    public ButtonClickedEvent onUp{
        get { return m_OnUp; }
        set { m_OnUp = value; }
    }
    
    void OnMouseDown() {
		if(Disabled) return;


        if(Toggleable) {
            GetComponent<SpriteRenderer>().sprite = Toggled ? ToggledOnDownSprite : OnDownSprite;
            transform.localPosition += OnDownMovement;
        }else if(OnDownSprite) {
            GetComponent<SpriteRenderer>().sprite = OnDownSprite;
            transform.localPosition += OnDownMovement;
        }
        m_OnDown.Invoke();
    }
	void OnMouseUp() {
		if(Disabled) return;
        
        if(Toggleable) {
            Toggled = !Toggled;
            GetComponent<SpriteRenderer>().sprite = Toggled ? ToggledSprite : BaseSprite;
            transform.localPosition -= OnDownMovement;
        }else if(OnDownSprite) {
            GetComponent<SpriteRenderer>().sprite = BaseSprite;
            transform.localPosition -= OnDownMovement;
        }
        m_OnUp.Invoke();
    }

	public void Disable(bool disable){
	//	Debug.Log("Disable: "+disable+", "+name);
		Disabled = disable;
		if(disable && OnDisableSprite)  GetComponent<SpriteRenderer>().sprite = OnDisableSprite;
		if(!disable && OnDisableSprite)  GetComponent<SpriteRenderer>().sprite = BaseSprite;
	}

    public void Toggle(bool toggled) {
		Toggled = toggled;
		if(toggled && ToggledSprite)  GetComponent<SpriteRenderer>().sprite = ToggledSprite;
		if(!toggled && ToggledSprite)  GetComponent<SpriteRenderer>().sprite = BaseSprite;
    }
}
