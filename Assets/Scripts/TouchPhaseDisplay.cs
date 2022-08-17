using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchPhaseDisplay : MonoBehaviour
{
    public TMP_Text PhaseDisplayText;
    private Touch _theTouch;
    private float _timeTouchedEnded;
    private float _displayTime =0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            _theTouch = Input.GetTouch(0);
            if (_theTouch.phase== TouchPhase.Ended)
            {
                PhaseDisplayText.text = _theTouch.phase.ToString();
                _timeTouchedEnded = Time.time;
            }
            else if (Time.time - _timeTouchedEnded>_displayTime)
            {
                PhaseDisplayText.text = _theTouch.phase.ToString();
                _timeTouchedEnded = Time.time;
            }

        }
        else if (Time.time - _timeTouchedEnded > _displayTime)
        {
            PhaseDisplayText.text = " ";
        }


    }
}
