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
        //�ʱ�ȭ ���� ��׶��忡 ���� �Ǿ��ִ� SpriteRenderer
        StartCoroutine(changeBackground(backgroundSpriteRenderer, 0.007f));
        //Ư�� �̹��� ������ �۾����� �ϴ� �Լ�
    }

    IEnumerator changeBackground(SpriteRenderer sprite, float size)
    {
        Color color = sprite.color; //Į�� ���� �޾ƿ´�

        while (color.a > 0.0f) //������ ���� �����ϸ�
        {
            color.a -= size; //������ �ֱ�
            sprite.color = color;
            yield return new WaitForSeconds(size); //0.007 ���
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
