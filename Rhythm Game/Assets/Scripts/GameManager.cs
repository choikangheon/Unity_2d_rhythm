using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    //GameManager�� �̱� �� ó���մϴ�.
    public static GameManager instance { get; set; } // GameManger ��ü

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

    }
    public float noteSpeed;  // GameManger�� noteSpeed �� 

    public GameObject scoreUI;
    public float score;
    private Text scoreText;

    public GameObject comboUI;
    private int combo;
    private Text comboText;
    private Animator comboAnimator;
    public int maxCombo;

    // ���� ����
    private AudioSource audioSource;
    private string music = "music";

    public enum judges { NONE = 0, BAD, GOOD, PERFECT, MISS };
    public GameObject judgeUI;
    private Sprite[] judgeSprites;
    private Image judgementSpriteRenderer;
    private Animator judgementSpriteAnimator;

    // ������ �����ϴ� �Լ��Դϴ�.
    void MusicStart()
    {
        // ���ҽ����� ��Ʈ(Beat) ���� ������ �ҷ��� ����մϴ�.
        AudioClip audioClip = Resources.Load<AudioClip>("Beats/" +music);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }



    void Start()
    {
        Invoke("MusicStart", 2);
        judgementSpriteRenderer = judgeUI.GetComponent<Image>();
        judgementSpriteAnimator = judgeUI.GetComponent<Animator>();
        scoreText = scoreUI.GetComponent<Text>();
        comboText = comboUI.GetComponent<Text>();
        comboAnimator = comboUI.GetComponent<Animator>();

        // ���� ����� �����ִ� ��������Ʈ �̹����� �̸� �ʱ�ȭ�մϴ�.
        judgeSprites = new Sprite[4];
        judgeSprites[0] = Resources.Load<Sprite>("Sprites/Bad");
        judgeSprites[1] = Resources.Load<Sprite>("Sprites/Good");
        judgeSprites[2] = Resources.Load<Sprite>("Sprites/Miss");
        judgeSprites[3] = Resources.Load<Sprite>("Sprites/Perfect");
    }

   
    void Update()
    {
        
    }

    // ��Ʈ ���� ���Ŀ� ���� ����� ȭ�鿡 �����ݴϴ�.
    void showJudgement()
    {
        // ���� �̹����� �����ݴϴ�.
        string scoreFormat = "000000";
        scoreText.text = score.ToString(scoreFormat);
        // ���� �̹����� �����ݴϴ�.
        judgementSpriteAnimator.SetTrigger("Show");
        // �޺��� 2 �̻��� ���� �޺� �̹����� �����ݴϴ�.
        if (combo >= 2)
        {
            comboText.text = "COMBO " + combo.ToString();
            comboAnimator.SetTrigger("Show");
        }
        if (maxCombo < combo)
        {
            maxCombo = combo;
        }
    }

    // ��Ʈ ������ �����մϴ�.
    public void processJudge(judges judge, int noteType)
    {
        if (judge == judges.NONE) return;
        // MISS ������ ���� ��� �޺��� �����ϰ�, ������ ���� ����ϴ�.
        if (judge == judges.MISS)
        {
            judgementSpriteRenderer.sprite = judgeSprites[2];
            combo = 0;
            if (score >= 15) score -= 15;
        }
        // BAD ������ ���� ��� �޺��� �����ϰ�, ������ ���� ����ϴ�.
        else if (judge == judges.BAD)
        {
            judgementSpriteRenderer.sprite = judgeSprites[0];
            combo = 0;
            if (score >= 5) score -= 5;
        }
        // PERFECT Ȥ�� GOOD ������ ���� ��� �޺� �� ������ �ø��ϴ�.
        else
        {
            if (judge == judges.PERFECT)
            {
                judgementSpriteRenderer.sprite = judgeSprites[3];
                score += 20;
            }
            else if (judge == judges.GOOD)
            {
                judgementSpriteRenderer.sprite = judgeSprites[1];
                score += 15;
            }
            combo += 1;
            score += (float)combo * 0.1f;
        }
        showJudgement();
    }

}

