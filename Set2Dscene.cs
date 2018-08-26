using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Set2Dscene : MonoBehaviour {

	public Animator anim_info;
	//public Sprite tool_image;
	//public GameObject[] WeldingToolModel;
	public float fixedImageHeight = 525.0f;
	private float ScaleMul = 1.0f;
	public Image showcase_tool;
	public TextMeshProUGUI product;
	public TextMeshProUGUI series;
	//public Ima

	void Awake(){
		/*if (ApplicationModel.curr_tool == 0) {
			product.SetText ("Elec");
			series.SetText ("series");

			//Instantiate (WeldingToolModel [0], this.transform);
		};*/
		//float ImageSizeX = aa.bounds.size.x * 100.0f;
		float ImageSizeY = ApplicationModel.curr_sprite.bounds.size.y * 100.0f;
		float ImageSizeX = ApplicationModel.curr_sprite.bounds.size.x * 100.0f;
		print ("ImageSizesdsdY : " + ImageSizeY + " " + fixedImageHeight);
		//print ("ImageSizeX : " + tool_image.bounds.size.x * 100.0f);
		ScaleMul = (fixedImageHeight / ImageSizeY);// * ImageSizeX;
		print("ScaleMul : " + ScaleMul);
		showcase_tool.rectTransform.localScale = new Vector3(ScaleMul, ScaleMul, ScaleMul);
		showcase_tool.rectTransform.sizeDelta = new Vector2 (ImageSizeX, ImageSizeY);
		//showcase_tool.sprite = ApplicationModel.curr_sprite;

	}

	void Start(){
		//product.text
		print("ApplicationModel.curr_product : " + ApplicationModel.curr_product + " " + ApplicationModel.curr_series);
		showcase_tool.sprite = ApplicationModel.curr_sprite;
		product.text = ApplicationModel.curr_product;
		series.text = ApplicationModel.curr_series;
		//print("SizeX : " + aa.bounds.size.x);
		//print("SizeY : " + aa.bounds.size.y);
	}

	public void changescreen(string name){
		SceneManager.LoadScene (name);
	}

	public void info_click(){
		anim_info.Play ("infopanel_anim");
	}

	public void info_closeclick(){
		anim_info.Play ("infopanel_anim_reverse");
	}

	public void quit(){
		Application.Quit ();
	}

	public void Changetohome(){
		SceneManager.LoadScene ("intro");
	}
}
