using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gamecontroller_back : MonoBehaviour {

	public Animator anim;
    public Text btnwishlist_text;
    public Text Text_num_wishlist;

    public GameObject wishlist_prefab;
    public Transform wishlist_placeholder;

    bool present;

    private void Start()
    {
        Debug.Log("Application Start PrevScene : " + ApplicationModel.prev_scene + " Curr Scene : " + ApplicationModel.curr_scene);
        string[] strArr = null;
        string pro = PlayerPrefs.GetString("AddToWishlist");
        char[] splitchar = { '|' };
        strArr = pro.Split(splitchar);
        if (pro == "")
            Text_num_wishlist.text = "0";
        else
            Text_num_wishlist.text = strArr.Length.ToString();
        //Debug.Log("Start : " + pro);
        present = findproduct(pro, ApplicationModel.curr_product + ":" + ApplicationModel.curr_series);
        if (present)
        {
            btnwishlist_text.text = "Remove from the Wishlist";
            // startlist = false;
        }
        else
        {
            btnwishlist_text.text = "Add to the Wishlist";
            //startlist = true;
        }
    }

    public void view_cart()
    {
        // wishlist_item
        GameObject[] GO = GameObject.FindGameObjectsWithTag("wishlist_item");
        //public List<GameObject> Children;
        ///Transform[] GO = wishlist_placeholder.GetComponentsInChildren<Transform>();
        //Debug.Log("GO : " + GO.Length);
        foreach (GameObject child in GO)
        {
            //Debug.Log("GO");
            Destroy(child);
        }

        string[] strArr = null;
        char[] splitchar = { '|' };
        string pro = PlayerPrefs.GetString("AddToWishlist");
        if (pro == "")
            return;
        strArr = pro.Split(splitchar);

        string[] productArr = null;
        char[] Productsplitchar = { ':' };
        for (int count = 0; count < strArr.Length; count++)
        {

            string str = strArr[count];
            productArr = str.Split(Productsplitchar);
            GameObject gridelement = Instantiate(wishlist_prefab, wishlist_placeholder.transform) as GameObject;
            Text product_text = gridelement.GetComponentInChildren<Text>();
            string s = productArr[0] + " (" + productArr[1] + ") ";
            product_text.text = s;
        }
    }



    private bool findproduct(string str, string substring)
    {
        string[] strArr = null;
        char[] splitchar = { '|' };
        strArr = str.Split(splitchar);
        for (int count = 0; count <= strArr.Length - 1; count++)
        {
            if (strArr[count].CompareTo(substring) == 0)
                return true;
        }
        return false;
    }

    public void changescreen(string name){

        SceneManager.LoadScene (name);
	}

    public void GoPrevScreen()
    {
        Debug.Log("In previous Screen : prev_scene : " + ApplicationModel.prev_scene);
        ApplicationModel.curr_scene = ApplicationModel.prev_scene;
        if(ApplicationModel.prev_scene!="")
        {
            ApplicationModel.prev_scene = "";
            SceneManager.LoadScene(ApplicationModel.curr_scene);
        }
    }
    public void AddToWishlist()
    {

        if (!present)
        {
            string pro = PlayerPrefs.GetString("AddToWishlist");
            //Debug.Log("Pro11112 : " + pro);
            string info = null;
            if (pro == "")
            {
                info = ApplicationModel.curr_product + ":" + ApplicationModel.curr_series;
            }
            else
            {
                info = "|" + ApplicationModel.curr_product + ":" + ApplicationModel.curr_series;
            }
            pro += info;

            //Debug.Log("Pro : " + pro);
            PlayerPrefs.SetString("AddToWishlist", pro);

            btnwishlist_text.text = "Remove from the Wishlist";
            present = true;
            Text_num_wishlist.text = (int.Parse(Text_num_wishlist.text) + 1).ToString();
        }
        else
        {
            //Debug.Log("I am here");
            present = false;
            btnwishlist_text.text = "Add to the Wishlist";
            string str = null;
            string pro = PlayerPrefs.GetString("AddToWishlist");
            // Debug.Log("Remove11 : " + pro);
            string[] strArr = null;
            char[] splitchar = { '|' };
            strArr = pro.Split(splitchar);
            int jj = 0;
            string info = ApplicationModel.curr_product + ":" + ApplicationModel.curr_series;
            for (int count = 0; count <= strArr.Length - 1; count++)
            {
                //Debug.Log("Remove3324 : " + strArr[count]);
                if (strArr[count].CompareTo(info) != 0)
                {
                    //Debug.Log("Remove3324 : " + strArr[count]);
                    if (jj == 0)
                    {
                        jj = 1;
                    }
                    else
                    {
                        str += "|";
                    }
                    str += strArr[count];


                }
                else
                {
                    Text_num_wishlist.text = (strArr.Length - 1).ToString();
                }
            }

            PlayerPrefs.SetString("AddToWishlist", str);
        }
        string pro1 = PlayerPrefs.GetString("AddToWishlist");
    }


    public void quit(){
		Application.Quit ();
	}

	public void Changetohome(){
		Debug.Log ("ChangeToHome");
		SceneManager.LoadScene ("intro");
	}

    public void sendwhatsapp()
    {
        string[] strArr = null;
        char[] splitchar = { '|' };
        string pro = PlayerPrefs.GetString("AddToWishlist");
        strArr = pro.Split(splitchar);

        string[] productArr = null;
        char[] Productsplitchar = { ':' };
        string output_str = "";
        for (int count = 0; count < strArr.Length; count++)
        {

            string str = strArr[count];
            productArr = str.Split(Productsplitchar);
            GameObject gridelement = Instantiate(wishlist_prefab, wishlist_placeholder.transform) as GameObject;
            output_str += (count + 1).ToString() + " " + productArr[0] + " : " + productArr[1] + "NEWLINE";
        }

        string weburls = "https://wa.me/919899414486?text=I'm interested in buying following products" + " " + "NEWLINE" + output_str;
        weburls = weburls.Replace("NEWLINE", "\n");

        Application.OpenURL(weburls);


    }

    public void emailenquiry()
    {
        string[] strArr = null;
        char[] splitchar = { '|' };
        string pro = PlayerPrefs.GetString("AddToWishlist");
        strArr = pro.Split(splitchar);

        string[] productArr = null;
        char[] Productsplitchar = { ':' };
        string output_str = "";
        for (int count = 0; count < strArr.Length; count++)
        {

            string str = strArr[count];
            productArr = str.Split(Productsplitchar);
            GameObject gridelement = Instantiate(wishlist_prefab, wishlist_placeholder.transform) as GameObject;
            output_str += (count + 1).ToString() + " " + productArr[0] + " : " + productArr[1] + "NEWLINE";
        }
        string email = "kanika.modi@gmail.com";
        string subject = "Taurus Product Enquiry";
        string weburls = "https://wa.me/919899414486?text=I'm interested in buying following products" + " " + "NEWLINE" + output_str;
        string mailm = "mailto:" + email + "?subject=" + subject + "&body=" + weburls;

        Application.OpenURL(mailm);


    }

}
