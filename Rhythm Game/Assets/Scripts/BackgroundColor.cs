using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    public GameObject gameObject;
    private SpriteRenderer backgroundSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        backgroundSpriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
        //초기화 게임 백그라운드에 포함 되어있는 SpriteRenderer
        StartCoroutine(changeBackground(backgroundSpriteRenderer, 0.007f));
        //특정 이미지 갈수록 작아지게 하는 함수
    }

    IEnumerator changeBackground(SpriteRenderer sprite, float size)
    {
        Color color = sprite.color; //칼라 값을 받아온다

        while (color.a > 0.0f) //불투명도 값이 존재하면
        {
            color.a -= size; //불투명도 주기
            sprite.color = color;
            yield return new WaitForSeconds(size); //0.007 대기
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
