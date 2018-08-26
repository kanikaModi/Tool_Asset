using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus_RadialMenu : MonoBehaviour {
	[System.Serializable]
	public class Action{
		public Color color;
		public Sprite sprite;
		public string title;
	}

	public Action[] options;
	public float range = 500;
	public torus_RadialButton buttonPrefab;
	public torus_RadialButton selected;

	void Start(){
		//Debug.Log ("Inside AnimateButtondsadsa");
		//print ("Hi");
		StartCoroutine (AnimateButton() );
	}

	IEnumerator AnimateButton(){
		//Debug.Log ("Inside AnimateButton");
		for(int i = 0; i < options.Length; i++)
		{
			torus_RadialButton newButton = Instantiate (buttonPrefab) as torus_RadialButton;
			newButton.transform.SetParent (transform, false);
			float theta = (2 * Mathf.PI / options.Length) * i;
			float xPos = Mathf.Sin (theta);
			float yPos = Mathf.Cos (theta);
			newButton.transform.localPosition = new Vector3 (xPos, yPos, 0f) * range;	
			newButton.circle.color = options [i].color;
			newButton.icon.sprite = options [i].sprite;
			newButton.icon.color = options [i].color;
			newButton.title = options [i].title;
			newButton.myMenu = this;
			yield return new WaitForSeconds (0.06f);
		}
	}

}
