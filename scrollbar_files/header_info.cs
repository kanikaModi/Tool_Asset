using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class header_info : MonoBehaviour {

    public class header {
        public int header_count;
        public string header1_path;
        public string header2_path;
        public string header3_path;
        public string header4_path;
        public string header5_path;
        public header(int count, string p1, string p2, string p3, string p4, string p5)
        {
            header_count = count;
            header1_path = p1;
            header2_path = p2;
            header3_path = p3;
            header4_path = p4;
            header5_path = p5;
        }
       
    }
    //public string fff = "jhs";
    // " icon/4" = = "Asset/Resources/icon/4.png"
    public header Electrode_holder = new header(5, "icon/1", "icon/2", "icon/3", "icon/4", "icon/5");
   
    void Awake () {
        
        //Debug.Log("Electrode_holder : " + Electrode_holder.header1_path);
       // Debug.Log("sfaf : " + Electrode_holder.header1_path);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
