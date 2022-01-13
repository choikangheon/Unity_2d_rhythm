using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class SongSelectManager : MonoBehaviour
{
    
    public Image musicImageUI;
    public Text musicTitleUI;
    public Text bpmUI;

    private int musicIndex;
    private int musicCount = 3;



    private void UpdateSong(int musicIndex)
    {

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        // ���ҽ����� ��Ʈ(Beat) �ؽ�Ʈ ������ �ҷ��ɴϴ�.
        TextAsset textAsset = Resources.Load<TextAsset >("Beats/" + musicIndex.ToString());
        StringReader stringReader = new StringReader(textAsset.text);
        // ù ��° �ٿ� ���� �� �̸��� �о UI�� ������Ʈ�մϴ�.
        musicTitleUI.text = stringReader.ReadLine();
        // �� ��° ���� �б⸸ �ϰ� �ƹ� ó���� ���� �ʽ��ϴ�.
        stringReader.ReadLine();
        // �� ��° �ٿ� ���� BPM�� �о� UI�� ������Ʈ�մϴ�.
        bpmUI.text = "BPM: " + stringReader.ReadLine().Split(' ')[0];
        // ���ҽ����� ��Ʈ(Beat) ���� ������ �ҷ��� ����մϴ�.
        AudioClip audioClip = Resources.Load<AudioClip>("Beats/" + musicIndex.ToString());
        audioSource.clip = audioClip;
        audioSource.Play();
        // ���ҽ����� ��Ʈ(Beat) �̹��� ������ �ҷ��ɴϴ�.
        musicImageUI.sprite = Resources.Load<Sprite>("Beats/" + musicIndex.ToString());

    }
 

  

    

    public void Right()
    {
        musicIndex = musicIndex + 1;
        if (musicIndex > musicCount) musicIndex = 1;
        UpdateSong(musicIndex);
    }

    public void Left()
    {
        musicIndex = musicIndex - 1;
        if (musicIndex < 1) musicIndex = musicCount;
        UpdateSong(musicIndex);
    }

   

    void Start()
    {
        
        musicIndex = 1;
        UpdateSong(musicIndex);
        

    }

    public void GameStart()
    {
        
        
        SceneManager.LoadScene("Game");
    }

}
