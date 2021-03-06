using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class ToggleButton : Button {
	public Sprite defaultSprite;
	public Color defaultColor;
	public Sprite alternateSprite;
	public Color alternateColor;
	[System.Serializable]
	public class ToggleButtonEvent : UnityEvent<bool>{}
	public ToggleButtonEvent onClickDefault = new ToggleButtonEvent();
	public ToggleButtonEvent onClickAlternate = new ToggleButtonEvent();
	public ToggleButtonEvent onToggle = new ToggleButtonEvent();
	public Image targetImage;

	public bool isDefaultState = true;

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

	public void Toggle() {
		isDefaultState = !isDefaultState;
		UpdateSprite ();

		if (isDefaultState) {
			onClickDefault.Invoke (isDefaultState);
		} else {
			onClickAlternate.Invoke (isDefaultState);
		}
		onToggle.Invoke(isDefaultState);

	}

	//Set the value without calling the callbacks (used for init)
	public void Set(bool value)
	{
		isDefaultState = value;

		//In case the Set method is called before the button exists: don't try to update the sprite, simply take the new state into account
		if (started) {
			UpdateSprite ();	
		}
	}

	void UpdateSprite()
	{
		if (isDefaultState) {
			targetImage.sprite = defaultSprite;
			targetImage.color = defaultColor;
		} else {
			targetImage.sprite = alternateSprite;
			targetImage.color = alternateColor;
		}
	}


}
