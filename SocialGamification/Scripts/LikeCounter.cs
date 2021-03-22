using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Proyecto26;
public class LikeCounter : MonoBehaviour
{
    public TextMeshProUGUI textCounter;
    private int likeCounter;
    public static int externalLikeCounter;
    private bool likeIncrease = false;

    // Start is called before the first frame update
    void Start()
    {
        likeCounter = externalLikeCounter;
    }

    // Update is called once per frame
    void Update()
    {
        textCounter.text = likeCounter.ToString();
        if (likeIncrease){
            counterAdder();
            likeCounter++;
            likeIncrease = false;
            //From here uodate to the database
        }
        
    }
    public void counterAdder(){
        likeIncrease = true;
    }

}
