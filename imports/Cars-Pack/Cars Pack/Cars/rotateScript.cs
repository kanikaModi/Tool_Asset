using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotateScript : MonoBehaviour {


	private float speed = 25f;

 
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, speed * Time.deltaTime, 0);
	}

    public void changescreen(string name)
    {
        /*Scene scene = SceneManager.GetActiveScene();
        ApplicationModel.prev_scene = scene.name;
        ApplicationModel.curr_scene = name;*/

        SceneManager.LoadScene(name);
    }
}
