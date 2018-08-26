using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetApplicationParameters : MonoBehaviour {
	public string Screen_name;
	public void SetProduct(string Product_name){
		Debug.Log ("SetProduct");
		ApplicationModel.curr_product = Product_name;
	}

	public void SetProduct1(){
		Debug.Log ("SetProduct11");

	}

	public void SetSeries(string Series_name){
		Debug.Log ("SetSeries");
		ApplicationModel.curr_series = Series_name;
	}

	public void SetSprite(Sprite Sprite_name){
		Debug.Log ("SetSprite");
		ApplicationModel.curr_sprite = Sprite_name;
	}

	/*
	public void setparameter(string s1, string s2)
	{
		ApplicationModel.curr_product = s1;
		ApplicationModel.curr_series = s2;
	}*/

	public void SwitchScreen(){
		Debug.Log ("SwitchScreen");
		SceneManager.LoadScene (Screen_name);//Screen_name
	}
	/*
	public void SetparameterSwitch(string parameter, string s2){
		//ApplicationModel.curr_tool = parameter;
		int len = parameter.IndexOf ('_');
		ApplicationModel.curr_product = parameter.Substring(0,len-1);
		ApplicationModel.curr_series = parameter.Substring (len + 1, parameter.Length-1);
		Debug.Log("Pr : " + ApplicationModel.curr_product + " " + ApplicationModel.curr_series);
	}

	public void SetspriteSwitch(Sprite sprite_image){
		ApplicationModel.curr_sprite = sprite_image;
	}*/




}
