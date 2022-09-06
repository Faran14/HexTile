using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class MenuButton : MonoBehaviour
{
    public HorizontalScrollSnap ViewPage;
    //public Scrollbar HighLight;
    

    public void home()
    {
        ViewPage.GoToScreen(1);
        //HighLight.value = 0;
    }
    public void LeaderBoard()
    {
        ViewPage.GoToScreen(0);
        //HighLight.value = -313;
    }
    public void BattlePass()
    {
        ViewPage.GoToScreen(2);
        //HighLight.value = 313;
    }

    //IEnumerator Home()
    //{
    //    if (ViewPage.value > 0.5f)
    //    {
    //        for (float i = ViewPage.value; i > 0.5f; i = i - 0.01f)
    //        {
    //            ViewPage.value = i;
    //        }
    //    }
    //    if (ViewPage.value < 0.5f)
    //    {
    //        for (float i = ViewPage.value; i < 0.5f; i = i + 0.01f)
    //        {
    //            ViewPage.value = i;
    //        }
    //    }
    //    yield return null;
    //}

    //IEnumerator LB()
    //{
    //    Debug.Log("Inside the iEnum");
    //    Debug.Log(ViewPage.value);
    //    for (float i = ViewPage.value; i > 0.25f; i = i - 0.01f)
    //    {
    //        Debug.Log(i);
    //        ViewPage.value = i;
    //    }
    //    yield return null;
    //}

    //IEnumerator BP()
    //{
    //    for (float i = ViewPage.value; i < 0.75f; i = i + 0.01f)
    //    {
    //        ViewPage.value = i;
    //    }
    //    yield return null;
    //}

}
