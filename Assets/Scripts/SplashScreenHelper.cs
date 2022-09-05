using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SplashScreenHelper : MonoBehaviour
{
    public TMP_Text _text;
    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        bar.fillAmount = 0;
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        //Don't let the Scene activate until you allow it to
        //asyncOperation.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            bar.fillAmount = asyncOperation.progress;
            //_text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            //if (asyncOperation.progress >= 0.9f)
            //{
            //    //Change the Text to show the Scene is ready
            //    //_text.text = "Press the space bar to continue";
            //    //Wait to you press the space key to activate the Scene
            //    //if (Input.GetKeyDown(KeyCode.Space))
            //        //Activate the Scene
            //        //asyncOperation.allowSceneActivation = true;
            //}

            yield return null;
        }
    }
}
