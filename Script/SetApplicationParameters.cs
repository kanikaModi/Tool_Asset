using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetApplicationParameters : MonoBehaviour {

    public Animator anim_screenchange;
	public string Screen_name;
	public void SetProduct(string Product_name){
		//Debug.Log ("SetProduct");
		ApplicationModel.curr_product = Product_name;
	}

	

	public void SetSeries(string Series_name){
		//Debug.Log ("SetSeries");
		ApplicationModel.curr_series = Series_name;
	}

	public void SetSprite(Sprite Sprite_name){
		//Debug.Log ("SetSprite");
		ApplicationModel.curr_sprite = Sprite_name;
	}

    public void Settechfilename(string Techfilename)
    {
        //Debug.Log("SetSprite");
        ApplicationModel.curr_techdatafile = Techfilename;
    }

    public void Setheadertechfilename(string headertechdatafile)
    {
        //Debug.Log("SetSprite");
        ApplicationModel.curr_headertechdatafile = headertechdatafile;
    }



    public void SwitchScreen(){
        //Debug.Log ("SwitchScreen");
        Scene scene = SceneManager.GetActiveScene();
        ApplicationModel.prev_scene = scene.name;
        ApplicationModel.curr_scene = Screen_name;
        StartCoroutine(loadanotherscene(Screen_name));
       // SceneManager.LoadScene (Screen_name);//Screen_name
	}
    IEnumerator loadanotherscene(string name)
    {
        anim_screenchange.SetTrigger("stopscene");          
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(name);
    }

    
}
