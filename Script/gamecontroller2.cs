using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class gamecontroller2 : MonoBehaviour {

    public Animator anim;
    public Text Text_num_wishlist;

    public GameObject wishlist_prefab;
    public Transform wishlist_placeholder;
    char[] splitchar = { '|' };
    char[] Productsplitchar = { ':' };
    bool present;
    private void Awake()
    {
        anim.SetTrigger("startscene");
    }
    private void Start()
    {
        //string s = "Chipping Hammers:ST - B - BL|Electrode Holder:PFT Series|Chipping Hammers: ST - B - EX - CR";
        // PlayerPrefs.SetString("AddToWishlist", "");
       // anim.SetTrigger("startscene");
        string[] strArr = null;
        string pro = PlayerPrefs.GetString("AddToWishlist");
        //char[] splitchar = { '|' };
        strArr = pro.Split(splitchar);

        //Debug.Log("Wishlist string : " + pro + "  strArr.Length ::" + strArr.Length + " strArr[count] :" + strArr[0]);
        if (pro == "")
            Text_num_wishlist.text = "0";
        else
            Text_num_wishlist.text = strArr.Length.ToString();

    }

    public void changescreen(string name)
    {
        StartCoroutine(loadnextscene(name));
     // SceneManager.LoadScene(name);
    }

    IEnumerator loadnextscene(string name)
    {
        anim.SetTrigger("stopscene");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(name);
    }

    public void view_cart()
    {
        // wishlist_item
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

            Debug.Log("Name : " + btn.gameObject.name);



        }
    }

    public void delete_wishitem(string product_info)
    {
        
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
                if(newstring == "")
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
        if (wishlistindex != -1) {
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
        //
    }

    public void Changetohome()
    {
        //Debug.Log("ChangeToHome");
        StartCoroutine(loadnextscene("intro"));
        //SceneManager.LoadScene("intro");
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
           // GameObject gridelement = Instantiate(wishlist_prefab, wishlist_placeholder.transform) as GameObject;
            output_str += (count + 1).ToString() + " " + productArr[0] + " - " + productArr[1] + "NEWLINE";
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
           // GameObject gridelement = Instantiate(wishlist_prefab, wishlist_placeholder.transform) as GameObject;
            output_str += (count + 1).ToString() + " " + productArr[0] + " - " + productArr[1] + "NEWLINE";
        }
        string email = "kanika.modi@gmail.com";
        string subject = "Taurus Product Enquiry";
        string weburls = "Hi Sir, " + "I am interested in buying following products" + " " + "NEWLINE" + output_str;
        string mailm = "mailto:" + email + "?subject=" + subject + "&body=" + weburls;

        Application.OpenURL(mailm);

    }
}
