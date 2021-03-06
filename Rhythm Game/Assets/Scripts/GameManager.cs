using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    //GameManager를 싱글 톤 처리합니다.
    public static GameManager instance { get; set; } // GameManger 객체

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

    }
    public float noteSpeed;  // GameManger의 noteSpeed 값 

    public GameObject scoreUI;
    public float score;
    private Text scoreText;

    public GameObject comboUI;
    public int combo;
    private Text comboText;
    private Animator comboAnimator;
    public int maxCombo;

    // 음악 변수
    private AudioSource audioSource;
    private string music = "music";

    public enum judges { NONE = 0, BAD, GOOD, PERFECT, MISS };
    public GameObject judgeUI;
    private Sprite[] judgeSprites;
    private Image judgementSpriteRenderer;
    private Animator judgementSpriteAnimator;


    //auto
    public bool autoTest;

    // 음악을 실행하는 함수입니다.
    void MusicStart()
    {
        // 리소스에서 비트(Beat) 음악 파일을 불러와 재생합니다.
        AudioClip audioClip = Resources.Load<AudioClip>("Beats/" +music);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }



    void Start()
    {
        Invoke("MusicStart", 1);
        judgementSpriteRenderer = judgeUI.GetComponent<Image>();
        judgementSpriteAnimator = judgeUI.GetComponent<Animator>();
        scoreText = scoreUI.GetComponent<Text>();
        comboText = comboUI.GetComponent<Text>();
        comboAnimator = comboUI.GetComponent<Animator>();

        // 판정 결과를 보여주는 스프라이트 이미지를 미리 초기화합니다.
        judgeSprites = new Sprite[4];
        judgeSprites[0] = Resources.Load<Sprite>("Sprites/Bad");
        judgeSprites[1] = Resources.Load<Sprite>("Sprites/Good");
        judgeSprites[2] = Resources.Load<Sprite>("Sprites/Miss");
        judgeSprites[3] = Resources.Load<Sprite>("Sprites/Perfect");
    }

   
    void Update()
    {
        
    }

    // 노트 판정 이후에 판정 결과를 화면에 보여줍니다.
    void showJudgement()
    {
        // 점수 이미지를 보여줍니다.
        string scoreFormat = "000000";
        scoreText.text = score.ToString(scoreFormat);
        // 판정 이미지를 보여줍니다.
        judgementSpriteAnimator.SetTrigger("Show");
        // 콤보가 2 이상일 때만 콤보 이미지를 보여줍니다.
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

    // 노트 판정을 진행합니다.
    public void processJudge(judges judge, int noteType)
    {
        if (judge == judges.NONE) return;
        // MISS 판정을 받은 경우 콤보를 종료하고, 점수를 많이 깎습니다.
        if (judge == judges.MISS)
        {
            judgementSpriteRenderer.sprite = judgeSprites[2];
            combo = 0;
            if (score >= 15) score -= 15;
        }
        // BAD 판정을 받은 경우 콤보를 종료하고, 점수를 조금 깎습니다.
        else if (judge == judges.BAD)
        {
            judgementSpriteRenderer.sprite = judgeSprites[0];
            combo = 0;
            if (score >= 5) score -= 5;
        }
        // PERFECT 혹은 GOOD 판정을 받은 경우 콤보 및 점수를 올립니다.
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

