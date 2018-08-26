using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class torus_RadialButton : MonoBehaviour {
	public Image circle;
	public Image icon;
	public string title;
	Color defaultColor;
	public Torus_RadialMenu myMenu;
	public Text label;
	void Start(){
		label.text = title;
		label.color = Color.white;
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		myMenu.selected = this;
		defaultColor = circle.color;
		circle.color = Color.white;
		//Debug.Log ("I am selected");
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		myMenu.selected = null;
		circle.color = defaultColor;
	}
}
