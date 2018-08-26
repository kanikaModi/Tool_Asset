using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeicon : MonoBehaviour {
    public Sprite AudioOn;
    public Sprite AudioOff;
    DontDestroy scr;
    void Start () {
        scr = GameObject.FindGameObjectWithTag("music").GetComponent<DontDestroy>();
        if (scr.audiostatus)
        {
            this.GetComponent<Image>().sprite = AudioOn;           
        }
        else
        {
            this.GetComponent<Image>().sprite = AudioOff;
        }
         
    }
	
	// Update is called once per frame
	public  void setaudio () {
        //DontDestroy scr = GameObject.FindGameObjectWithTag("music").GetComponent<DontDestroy>();
        if (scr.audiostatus)
        {
            this.GetComponent<Image>().sprite = AudioOff;
            scr.musicOff();
        }
        else
        {
            this.GetComponent<Image>().sprite = AudioOn;
            scr.musicOn();
        }
    }
}
