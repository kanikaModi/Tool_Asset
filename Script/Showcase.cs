using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase : MonoBehaviour {
	public GameObject[] WeldingToolModel;
	void Awake(){
		if (ApplicationModel.curr_tool == 0) {
			Instantiate (WeldingToolModel [0], this.transform);
		};
	}
}
