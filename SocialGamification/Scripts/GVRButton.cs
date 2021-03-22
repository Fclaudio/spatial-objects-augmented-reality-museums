using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVRButton : MonoBehaviour
{

    public Image imageCircle;
    public UnityEvent GVRClick;
    private GameObject imageObject;
    public float totalTime = 2;
    bool gvrStatus;
    public float gvrTimer;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imageCircle.fillAmount = gvrTimer / totalTime;
        }

        if(gvrTimer > totalTime)
        {
            GVRClick.Invoke();
            gvrTimer = 0;
            
        }
    }

    public void GVROn()
    {
        imageCircle.gameObject.SetActive(true);
        gvrStatus = true;
    }
    public void GVROff()
    {
        imageCircle.gameObject.SetActive(false);
        gvrStatus = false;
        gvrTimer = 0;
        imageCircle.fillAmount = 0;
    }


}
