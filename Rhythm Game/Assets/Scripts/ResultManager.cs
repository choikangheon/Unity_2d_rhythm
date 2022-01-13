using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultManager : MonoBehaviour
{
    public Text MaxCombo;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "" + ResultInfo.score;
            MaxCombo.text = "" + ResultInfo.maxCombo;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
