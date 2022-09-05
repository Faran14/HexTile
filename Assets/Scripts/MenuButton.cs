using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Scrollbar ViewPage;

    public void home()
    {
        ViewPage.value = 0.5f;
    }
    public void LeaderBoard()
    {
        ViewPage.value = 0.25f;
    }
    public void BattlePass()
    {
        ViewPage.value = 0.75f;
    }
}
