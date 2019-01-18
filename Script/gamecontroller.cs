using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gamecontroller : MonoBehaviour {

	public Animator anim;
    public Text btnwishlist_text;
    public Text Text_num_wishlist;

    public GameObject wishlist_prefab;
    public Transform wishlist_placeholder;
    char[] splitchar = { '|' };
    char[] Productsplitchar = { ':' };
    bool present;

    private void Start()
    {
        anim.SetTrigger("startscene");
        Debug.Log("Application Start PrevScene : " + ApplicationModel.prev_scene + " Curr Scene : " + ApplicationModel.curr_scene);
        string[] strArr = null;
        string pro = PlayerPrefs.GetString("AddToWishlist");
        //char[] splitchar = { '|' };
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
        GameObject[] GO = GameObject.FindGameObjectsWithTag("wishlist_item");

        foreach (GameObject child in GO)
        {
            Destroy(child);
        }

        string[] strArr = null;
        // char[] splitchar = { '|' };
        string pro = PlayerPrefs.GetString("AddToWishlist");
        if (pro == "")
            return;
        strArr = pro.Split(splitchar);

        string[] productArr = null;
        // char[] Productsplitchar = { ':' };
        for (int count = 0; count < strArr.Length; count++)
        {

            string str = strArr[count];
            productArr = str.Split(Productsplitchar);
            GameObject gridelement = Instantiate(wishlist_prefab, wishlist_placeholder.transform) as GameObject;
            Text product_text = gridelement.GetComponentInChildren<Text>();
            string s = productArr[0] + " (" + productArr[1] + ") ";
            product_text.text = s;

            ///attach the on click function to the X

            string parameter = productArr[0] + ":" + productArr[1];
            Button btn = gridelement.transform.GetChild(1).GetComponent<Button>();
            btn.onClick.AddListener(() => delete_wishitem(parameter));

           // Debug.Log("Name : " + btn.gameObject.name);



        }
    }

    public void delete_wishitem(string product_info)
    {
        Debug.Log(" wishlist item " + wishlist_placeholder.childCount);
        for (int i=0; i < wishlist_placeholder.childCount; i++)
        {
            Debug.Log(" wishlist item : " + i + " " + wishlist_placeholder.GetChild(i).name);
        }
        string[] strArr = null;
        string newstring = "";
        // char[] splitchar = { '|' };
        string pro = PlayerPrefs.GetString("AddToWishlist");
        Debug.Log("before delete wishlist :" + pro);
        strArr = pro.Split(splitchar);
        int wishlistindex = -1;
        for (int count = 0; count < strArr.Length; count++)
        {
            if (strArr[count].CompareTo(product_info) != 0)
            {
                if (newstring == "")
                    newstring += strArr[count];
                else
                    newstring = newstring + "|" + strArr[count];
            }
            else
            {
                wishlistindex = count;
            }
        }
        PlayerPrefs.SetString("AddToWishlist", newstring);
        Debug.Log("After delete wishlist :" + newstring);
        if (wishlistindex != -1)
        {
            int itemcount = int.Parse(Text_num_wishlist.text);
            Text_num_wishlist.text = (itemcount - 1).ToString();
            //c = Text_num_wishlist.text - 1;
            GameObject.Destroy(wishlist_placeholder.GetChild(wishlistindex).gameObject);
        }
        //Destroy(transform.parent.gameObject);
        /*for (int i = 0; i < wishlist_placeholder.childCount; i++)
        {

        }*/
        //delete gameobject;
    }


    private bool findproduct(string str, string substring)
    {
        string[] strArr = null;
        // char[] splitchar = { '|' };
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
           // Debug.Log("I am here inside");
            ApplicationModel.prev_scene = "";
            StartCoroutine(loadnextscene(ApplicationModel.curr_scene));
           //loadnextscene(ApplicationModel.curr_scene);
            //SceneManager.LoadScene(ApplicationModel.curr_scene);
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
        StartCoroutine(quitscene());
        Application.Quit ();
	}


    IEnumerator quitscene()
    {
        anim.SetTrigger("stopscene");
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }

    public void Changetohome(){
		Debug.Log ("ChangeToHome");
        StartCoroutine(loadnextscene("intro"));
        //SceneManager.LoadScene ("intro");
	}

    IEnumerator loadnextscene(string name)
    {
        anim.SetTrigger("stopscene");
        yield return new WaitForSeconds(2f);
        Debug.Log("Prev Scene Name Kanika : " + name);
        SceneManager.LoadScene(name);
    }

    public void sendwhatsapp()
    {
        string[] strArr = null;
        // char[] splitchar = { '|' };
        string pro = PlayerPrefs.GetString("AddToWishlist");
        strArr = pro.Split(splitchar);

        string[] productArr = null;
        //char[] Productsplitchar = { ':' };
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
        // char[] splitchar = { '|' };
        string pro = PlayerPrefs.GetString("AddToWishlist");
        strArr = pro.Split(splitchar);

        string[] productArr = null;
        // char[] Productsplitchar = { ':' };
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
