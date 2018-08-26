using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gamecontroller : MonoBehaviour {
	public Animator anim;


    public void changescreen(string name){
		SceneManager.LoadScene (name);
	}

    public void info_click(){
		anim.Play ("infopanel_anim");
	}

	public void info_closeclick(){
		anim.Play ("infopanel_anim_reverse");
	}

	public void quit(){
		Application.Quit ();
	}

	public void Changetohome(){
		Debug.Log ("ChangeToHome");
		SceneManager.LoadScene ("intro");
	}

}
