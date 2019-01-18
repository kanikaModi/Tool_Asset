using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using UnityEngine.JSONSerializeModule;

public class jsonread : MonoBehaviour {
    string path;
    string jsonstring;
	// Use this for initialization
	void Start () {
        Debug.Log(Application.streamingAssetsPath);
        path = Application.streamingAssetsPath + "/" + ApplicationModel.curr_series + ".json";
        jsonstring = File.ReadAllText(path);
        Creature Yumn = JsonUtility.FromJson<Creature>(jsonstring);
        Debug.Log(Yumn.name + " " + Yumn.level + " " + Yumn.Stats);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
[System.Serializable]
public class Creature
{
    public string name;
    public int level;
    public int Stats;
}
