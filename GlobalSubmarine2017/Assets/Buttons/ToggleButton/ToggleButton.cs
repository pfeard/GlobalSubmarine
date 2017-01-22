using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleButton : Button {
	public Sprite defaultSprite;
	public Color defaultColor;
	public Sprite alternateSprite;
	public Color alternateColor;
	public ButtonClickedEvent onClickDefault;
	public ButtonClickedEvent onClickAlternate;
	public Image targetImage;

	bool defaultState = true;

	bool started = false; //Was the Start() method called?

	// Use this for initialization
	override protected void Start () {
		base.Start ();
		this.onClick.AddListener( () => { Toggle(); });
		if (targetImage == null) {
			targetImage = transform.GetComponent<Image> ();
		}
		UpdateSprite ();

		started = true;
	}

	void Toggle() {
		if (defaultState) {
			onClickDefault.Invoke ();
		} else {
			onClickAlternate.Invoke ();
		}
		defaultState = !defaultState;
		UpdateSprite ();
	}

	//Set the value without calling the callbacks (used for init)
	public void Set(bool value)
	{
		defaultState = value;

		//In case the Set method is called before the button exists: don't try to update the sprite, simply take the new state into account
		if (started) {
			UpdateSprite ();	
		}
	}

	void UpdateSprite()
	{
		if (defaultState) {
			targetImage.sprite = defaultSprite;
			targetImage.color = defaultColor;
		} else {
			targetImage.sprite = alternateSprite;
			targetImage.color = alternateColor;
		}
	}


}
