using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    public bool audiostatus = true;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    /*public void Clickaudio()
    {
        if (audiostatus)
        {
            //GameObject audobj = GameObject.FindGameObjectWithTag("audio");
            audiostatus = false;
        }
        else
        {
            audiostatus = true;
        }
    }*/

    public void  musicOn()
    {
        audiostatus = true;
        this.GetComponent<AudioSource>().enabled = true;
    }

    public void musicOff()
    {
        audiostatus = false;
        this.GetComponent<AudioSource>().enabled = false;
    }
}
