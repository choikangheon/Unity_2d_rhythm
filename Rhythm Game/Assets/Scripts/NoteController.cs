using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    notes.Add(new Note(3, 3));
    notes.Add(new Note(4, 4));
    notes.Add(new Note(1, 5));
    notes.Add(new Note(2, 6));
    notes.Add(new Note(3, 7));
    notes.Add(new Note(4, 8));
    //��� ��带 ������ �ð��� ����ϵ��� ����
     
    for(int i=0; i < notes.Count; i++)
    {
        StartCoroutine(delayNote(notes[i]));
    }
}

    
    void Update()
    {
        
    }
}