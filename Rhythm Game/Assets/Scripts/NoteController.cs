using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class NoteController : MonoBehaviour
{
    //�ϳ��� ��Ʈ�� ���� ������ ��� ��Ʈ(Note) Ŭ������ ����
    class Note
    {
        public int noteType { get; set; }
        public int order { get; set; }
        public Note(int noteType, int order)
        {
            this.noteType = noteType;
            this.order = order;
        }
    }

    public GameObject[] Notes;
    private List<Note> notes = new List<Note>();
    private float beatInterval = 1.0f;

    IEnumerator delayNote(Note note)
    {
        int noteType = note.noteType;
        int order = note.order;
        yield return new WaitForSeconds(order * beatInterval);
        Instantiate(Notes[noteType - 1]);
    }

    void Start()
    {
        notes.Add(new Note(1, 1));
        notes.Add(new Note(2, 2));
        notes.Add(new Note(0, 3));
        notes.Add(new Note(4, 4));
        notes.Add(new Note(4, 5));
        notes.Add(new Note(1, 6));
        notes.Add(new Note(3, 7));
        notes.Add(new Note(1, 8));
        notes.Add(new Note(0, 10));
        notes.Add(new Note(3, 11));
        notes.Add(new Note(2, 12));
        notes.Add(new Note(1, 13));
        notes.Add(new Note(3, 14));
        notes.Add(new Note(0, 15));
        notes.Add(new Note(3, 17));
        notes.Add(new Note(2, 17));
        notes.Add(new Note(0, 18));
        notes.Add(new Note(3, 19));
        notes.Add(new Note(2, 20)); 
        notes.Add(new Note(2, 22));
        notes.Add(new Note(1,22));
        notes.Add(new Note(3, 23));
        notes.Add(new Note(0, 24));
        notes.Add(new Note(2, 25));
        notes.Add(new Note(1, 26));

        //��� ��带 ������ �ð��� ����ϵ��� ����

        for (int i = 0; i < notes.Count; i++)
        {
            StartCoroutine(delayNote(notes[i]));
        }

        // ������ ��Ʈ�� �������� ���� ���� �Լ��� �ҷ��ɴϴ�.
        StartCoroutine(AwaitGameResult(notes[notes.Count - 1].order));

    }

    IEnumerator AwaitGameResult(int order)
    {
        yield return new WaitForSeconds( order * beatInterval + 3.0f);
        GameResult();
    }

    void GameResult()
    {
        ResultInfo.maxCombo = GameManager.instance.maxCombo;
        ResultInfo.score = GameManager.instance.score;
        EditorSceneManager.LoadScene("GameResult");
    }


    void Update()
    {

    }
}