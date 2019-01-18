using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class jsonfileread : MonoBehaviour {
    //string type = "FCL";
    public RectTransform rt_view;
    public GameObject button_prefab;
    public GameObject button_placeholder;
    public RectTransform horizontal_scrollbar;
    public RectTransform vertical_scrollbar;
    RectTransform rt;
    // [System.Serializable]
    /*public int max_width = 280;
    public int max_height = 200;
    public int button_width = 60;
    public int button_height = 30;
    public int button_gap_horizontal = 5;
    public int button_gap_vertical = 5;*/
    //private header_info header_script;

    private string jsonstring;
    private JsonData itemData;
	// Use this for initialization
	void Start () {
        jsonstring = File.ReadAllText(Application.dataPath + "/Resources/json/" + ApplicationModel.curr_techdatafile + ".json");
        itemData = JsonMapper.ToObject(jsonstring);
        string d = (string)itemData[ApplicationModel.curr_headertechdatafile][0][0];
        int num_cols = int.Parse(d);
        int width = grid_technicaldata.button_width * num_cols + (num_cols + 1) * grid_technicaldata.button_gap_horizontal;

        Debug.Log(Application.dataPath + "/Resources/json/" + ApplicationModel.curr_techdatafile + ".json");

        jsonstring = File.ReadAllText(Application.dataPath + "/Resources/json/" + ApplicationModel.curr_techdatafile + ".json");
        itemData = JsonMapper.ToObject(jsonstring);
        //Debug.Log("jsonstring[1] : " + itemData["FCL"][1][1]);
        
        int num_rows = itemData[ApplicationModel.curr_techdatafile].Count;
        Debug.Log("num_cols : " + num_cols + " , num_rows : " + num_rows);
        int height = grid_technicaldata.button_width * num_rows + (num_rows + 1) * grid_technicaldata.button_gap_vertical;
        //Debug.Log("number of rows are " + itemData[ApplicationModel.curr_series][1][1]);

        if (width > grid_technicaldata.max_width)
            width = grid_technicaldata.max_width;
        if (height > grid_technicaldata.max_height)
            height = grid_technicaldata.max_height;
        rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width, height);
        rt_view.sizeDelta = new Vector2(width, height);

        horizontal_scrollbar.localPosition = new Vector3(0, -(height / 2 ), 0);
        horizontal_scrollbar.sizeDelta = new Vector2(width, 20);
        vertical_scrollbar.localPosition = new Vector3((width / 2 ), 0, 0);
        vertical_scrollbar.sizeDelta = new Vector2(20, height);

        GridLayoutGroup glg = button_placeholder.GetComponent<GridLayoutGroup>();
        glg.constraintCount = num_cols;
        //int j = 0;
        for (int i = 0; i < num_rows; i++)
        {
            for (int j = 0; j < num_cols; j++)
            {
                GameObject gridelement = Instantiate(button_prefab, button_placeholder.transform) as GameObject;
                Button btnelement = gridelement.GetComponent<Button>();
                //btnelement.GetComponentInChildren<Te>
                btnelement.GetComponentInChildren<Text>().text = itemData[ApplicationModel.curr_techdatafile][i][j].ToString();
               // Debug.Log("i and j : " + i + " " + j);
            }
        }
        //Debug.Log(jsonstring);

    }
	
	
}
