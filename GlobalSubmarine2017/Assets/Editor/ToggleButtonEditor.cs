﻿using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;

[CustomEditor(typeof(ToggleButton))]
public class UISegmentedControlButtonEditor : UnityEditor.UI.ButtonEditor {

	public override void OnInspectorGUI() {
		
		ToggleButton component = (ToggleButton)target;
		
		base.OnInspectorGUI();
		
		component.defaultSprite = (Sprite)EditorGUILayout.ObjectField("Default Sprite", component.defaultSprite, typeof(Sprite), true);
		component.defaultColor = (Color)EditorGUILayout.ColorField ("Default Color", component.defaultColor);
		component.alternateSprite = (Sprite)EditorGUILayout.ObjectField("Alternate Sprite", component.alternateSprite, typeof(Sprite), true);		
		component.alternateColor = (Color)EditorGUILayout.ColorField ("Alternate Color", component.alternateColor);
		component.targetImage = (Image)EditorGUILayout.ObjectField("Target Image", component.targetImage, typeof(Image), true);
	}
}