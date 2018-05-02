using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndReached : MonoBehaviour {

    public CanvasGroup uiElement;

    private float Transition;
    private float duration;

    private bool SetOnce = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(Fade(uiElement, uiElement.alpha, 1));
        StartCoroutine(WaitAMoment());
    }

    IEnumerator Fade(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        if (SetOnce == false)
        {
            Debug.Log(SetOnce);
            SetOnce = true;
            Debug.Log(SetOnce);
            float _timeStartedLerping = Time.time;
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpTime;

            while (true)
            {
                timeSinceStarted = Time.time - _timeStartedLerping;
                percentageComplete = timeSinceStarted / lerpTime;

                float currentValue = Mathf.Lerp(start, end, percentageComplete);

                cg.alpha = currentValue;

                if (percentageComplete >= 1) break;

                yield return new WaitForEndOfFrame();
            }
        }
        print("Faded");
    }

    IEnumerator WaitAMoment()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
