#region Namespaces

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

#endregion 

public class GA_script : MonoBehaviour {

    #region Variables

    public static bool firsttime = true;
    public Canvas m_Canvas;

    public GUIAnimFREE m_icon;
    public GUIAnimFREE m_Taurus;

    public GUIAnimFREE m_markettext;
    public GUIAnimFREE m_welding;

    public GUIAnimFREE m_rightpanel;
    public GUIAnimFREE m_sendenq;
    public GUIAnimFREE m_whatsapp;
    public GUIAnimFREE m_email;
    // public GUIAnimFREE m_wishlist;
    public GUIAnimFREE m_quit;
    public GUIAnimFREE m_contact;

    public Animator anim;
    #endregion
    // Use this for initialization
    void Awake()
    {
        if (enabled)
        {
            // Set GUIAnimSystemFREE.Instance.m_AutoAnimation to false in Awake() will let you control all GUI Animator elements in the scene via scripts.
            GUIAnimSystemFREE.Instance.m_AutoAnimation = false;
        }
        StartCoroutine(showscene());
        anim.SetTrigger("start");
        if (firsttime)
            StartCoroutine(MoveInCompanytitle());
        else
        {
            m_icon.enabled = false;
            m_Taurus.enabled = false;
            m_markettext.enabled = false;
            m_welding.enabled = false;
            m_rightpanel.enabled = false;
            m_sendenq.enabled = false;
            m_whatsapp.enabled = false;
            m_email.enabled = false;
            m_quit.enabled = false;
            m_contact.enabled = false;
           // anim.SetTrigger("start");
            //m_icon.enabled = false;
        }

        firsttime = false;
    }
    void Start()
    {
        //if(!firsttime)
        //    anim.SetTrigger("start");
        // MoveIn m_TopBar and m_BottomBar
        //m_Title1.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        //m_Title2.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);

        //StartCoroutine(MoveInCompanytitle());
        // MoveIn m_Title1 and m_Title2
        //StartCoroutine(MoveInTitleGameObjects());

        // Disable all scene switch buttons
        // http://docs.unity3d.com/Manual/script-GraphicRaycaster.html
        //s GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable(m_Canvas, false);

    }

    IEnumerator showscene()
    {
        yield return new WaitForSeconds(1.0f);
        anim.SetTrigger("start");
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator MoveInCompanytitle()
    {
        yield return new WaitForSeconds(2.0f);

        // MoveIn m_Title1 and m_Title2
        m_icon.PlayInAnims(GUIAnimSystemFREE.eGUIMove.Self);
        m_Taurus.PlayInAnims(GUIAnimSystemFREE.eGUIMove.Self);

        yield return new WaitForSeconds(0.5f);
        m_markettext.PlayInAnims(GUIAnimSystemFREE.eGUIMove.Self);
        yield return new WaitForSeconds(0.1f);
        m_welding.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        // MoveIn all primary buttons
        yield return new WaitForSeconds(0.2f);
        //m_wishlist.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_sendenq.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_whatsapp.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_email.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);

    m_quit.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);

        yield return new WaitForSeconds(0.2f);
        m_rightpanel.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_contact.PlayInAnims(GUIAnimSystemFREE.eGUIMove.Self);



    }
    /*
    public void HideAllGUIs()
    {

        m_sendenq.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_quit.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        StartCoroutine(moveout());


    }
    IEnumerator moveout()
    {
        yield return new WaitForSeconds(0.2f);
        m_markettext.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.Self);
        m_welding.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.Self);
        yield return new WaitForSeconds(0.2f);
        m_rightpanel.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_sendenq.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        //m_whatsapp.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
       // m_email.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        yield return new WaitForSeconds(0.2f);
        m_icon.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_Taurus.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_contact.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.Self);
    }*/

    public void OpenScene(string scenename)
    {
        // Disable all buttons
       // GUIAnimSystemFREE.Instance.EnableAllButtons(false);
        StartCoroutine(loadscene(scenename));
        // Waits 1.5 secs for Moving Out animation then load next level
       // GUIAnimSystemFREE.Instance.LoadLevel(scenename, 1.2f);

        //gameObject.SendMessage("HideAllGUIs");
    }

    IEnumerator loadscene(string scenename)
    {
        anim.SetTrigger("stopscene");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scenename);
        //GUIAnimSystemFREE.Instance.LoadLevel(scenename, 1.2f);
    }
    public void Applicationexit()
    {
        Application.Quit();
    }

    public void OnclickSendEnquiry()
    {
        m_whatsapp.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        m_email.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }
}
