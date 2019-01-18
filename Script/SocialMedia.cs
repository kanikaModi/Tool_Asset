
#region Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class SocialMedia : MonoBehaviour {
    #region Variable
        char[] splitchar = { '|' };
        char[] Productsplitchar = { ':' };
    #endregion
    #region Whatsapp
    public void Sendwhatsapp()
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
            //GameObject gridelement = Instantiate(wishlist_prefab, wishlist_placeholder.transform) as GameObject;
            output_str += (count + 1).ToString() + " " + productArr[0] + " - " + productArr[1] + "NEWLINE";
        }

        string weburls = "https://wa.me/919899414486?text=I'm interested in buying following products" + " " + "NEWLINE" + output_str;
        weburls = weburls.Replace("NEWLINE", "\n");

        Application.OpenURL(weburls);

    }
    #endregion

    #region mail
    public void Emailenquiry()
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
            //GameObject gridelement = Instantiate(wishlist_prefab, wishlist_placeholder.transform) as GameObject;
            output_str += (count + 1).ToString() + " " + productArr[0] + " - " + productArr[1] + "NEWLINE";
        }
        string email = "kanika.modi@gmail.com";
        string subject = "Taurus Product Enquiry";
        string weburls = "Hi Sir, " + "I am interested in buying following products" + " " + "NEWLINE" + output_str;
        string mailm = "mailto:" + email + "?subject=" + subject + "&body=" + weburls;

        Application.OpenURL(mailm);

    }
    #endregion

}
