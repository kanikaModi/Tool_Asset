using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class populate_header : MonoBehaviour {
    public RectTransform rt_view;
    public GameObject header_prefab;
    public GameObject Data_prefab;
    public Transform placeholder;
    public RectTransform horizontal_scrollbar;
    public RectTransform vertical_scrollbar;

    RectTransform rt;
    private string path;
    private Sprite mySprite = null;
    private string wholetext;
    private JsonData itemData;
    private int num_col_grid;
    private int num_rows_grid;

    private int Colsize_X;
    private int Colsize_Y;
    // private string column_width_name = "colWidth";
    private int scrollbar_width = 20;

    public string filename;
    void Start() {
        RectTransform rt = (RectTransform)this.transform;

        float width = rt.rect.width;
        float height = rt.rect.height;
        //Debug.Log("width : " + width + " height : " + height);
        Readfile();
        SetColumnConstraint();

        fillheader();
        fillcontentfile();
    }
    // First fulfill the header

    void Readfile()
    {
        //filename = "json/" + ApplicationModel.curr_techdatafile;
        filename = "json/" + ApplicationModel.curr_product;
       // Debug.Log("filename " + filename);
        var jsonTextFile = Resources.Load<TextAsset>(filename);
       // Debug.Log("FileContent " + jsonTextFile.text);
        //wholetext = File.ReadAllText(Application.dataPath + "/Resources/json/" + ApplicationModel.curr_techdatafile + ".json");
        itemData = JsonMapper.ToObject(jsonTextFile.text);
        string d = (string)itemData[ApplicationModel.curr_headertechdatafile][0][0];
      //  Debug.Log("D : " + d);        
        num_col_grid = int.Parse(d);
     //   Debug.Log("num_col_grid : " + num_col_grid);
        num_rows_grid = itemData[ApplicationModel.curr_techdatafile].Count;
        //   Debug.Log("num_rows_grid : " + num_rows_grid);
        d = (string)itemData["Colsize"][0][0];
        Colsize_X = int.Parse(d);
        //Colsize_X = int.Parse(d);
        d = (string)itemData["Colsize"][0][1];
        Colsize_Y = int.Parse(d);

        
}

    void DetermineWidthHeight()
    {
        int width = grid_technicaldata.button_width * num_col_grid + (num_col_grid - 1) * grid_technicaldata.button_gap_horizontal + 2 * grid_technicaldata.outer_gap;
        int height = grid_technicaldata.button_width * num_rows_grid + (num_rows_grid - 1) * grid_technicaldata.button_gap_vertical + 2 * grid_technicaldata.outer_gap;
        //Debug.Log("number of rows are " + itemData[ApplicationModel.curr_series][1][1]);
        Debug.Log("Determined width height : " + width + " " + height);
        if (width > grid_technicaldata.max_width )
            width = grid_technicaldata.max_width;
        if (height > grid_technicaldata.max_height)
            height = grid_technicaldata.max_height;
       // if (column_width != 0)
        //    width = column_width;
        rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width, height);
        rt_view.sizeDelta = new Vector2(width, height);
        //Debug.Log("now width height : " + width + " " + height);
        horizontal_scrollbar.localPosition = new Vector3(0, -(height / 2 + scrollbar_width), 0);
        horizontal_scrollbar.sizeDelta = new Vector2(width, scrollbar_width);
        vertical_scrollbar.localPosition = new Vector3((width / 2 + scrollbar_width), 0, 0);
        vertical_scrollbar.sizeDelta = new Vector2(scrollbar_width, height);

    }

    void SetColumnConstraint()
    {
        GridLayoutGroup glg = placeholder.GetComponent<GridLayoutGroup>();
        glg.constraintCount = num_col_grid;

       // RectTransform rt = (RectTransform)this.transform;

        //float width = rt.rect.width - 60 - num_col_grid * 10;
       // float height = rt.rect.height - 60 - num_col_grid * 10;
        // glg.cellSize = new Vector2(width/ num_col_grid, 60);
        glg.cellSize = new Vector2(Colsize_X, Colsize_Y);
        //glg.cellSize.x = width / num_col_grid;

    }

    void fillheader() {
        for (int i = 0; i < num_col_grid; i++)
        {
            GameObject gridelement = Instantiate(header_prefab, placeholder) as GameObject;
            Image ii = gridelement.GetComponent<Image>();
            path = (string)itemData[ApplicationModel.curr_headertechdatafile][0][i+1];      
            mySprite = Resources.Load<Sprite>(path);
            ii.sprite = mySprite;
        }       

    }

    void fillcontentfile()
    {
        for (int i = 0; i < num_rows_grid; i++)
        {
            for (int j = 0; j < num_col_grid; j++)
            {
                GameObject gridelement = Instantiate(Data_prefab, placeholder.transform) as GameObject;
                Button btnelement = gridelement.GetComponent<Button>();
                btnelement.GetComponentInChildren<Text>().text = itemData[ApplicationModel.curr_techdatafile][i][j].ToString();
                // Debug.Log("i and j : " + i + " " + j);
            }
        }
    }


}
