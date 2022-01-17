using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public int noteType;
    private GameManager.judges judge; // judges 라인에 따른 점수 
    private KeyCode key; // 키보드 입력시 받아올것 

    // Start is called before the first frame update
    void Start()
    {
        if (noteType == 1) key = KeyCode.D;
        else if (noteType == 2) key = KeyCode.F;
        else if (noteType == 3) key = KeyCode.J;
        else if (noteType == 4) key = KeyCode.K;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * GameManager.instance.noteSpeed);
        //key 입력 디버그
        if (Input.GetKey(key))
        {
            GameManager.instance.processJudge(judge, noteType);
            if (judge != GameManager.judges.NONE) Destroy(gameObject);
        }
    }


    //라인판정선에 따른 점수
    private void OnTriggerEnter2D(Collider2D judgment) // 충돌에 따른
    {
        if(judgment.gameObject.tag == "Bad Line") // 
        {
            judge = GameManager.judges.BAD;
        }
        else if (judgment.gameObject.tag == "Good Line")
        {
            judge = GameManager.judges.GOOD;
        }
        else if (judgment.gameObject.tag == "Perfect Line")
        {
            judge = GameManager.judges.PERFECT;
            if(GameManager.instance.autoTest)
            {
                GameManager.instance.processJudge(judge, noteType);
                gameObject.SetActive(false);
            }
        }
        else if (judgment.gameObject.tag == "Miss Line")
        {
            judge = GameManager.judges.MISS;
            GameManager.instance.processJudge(judge, noteType);
            Destroy(gameObject);
        }
     
    }
}
