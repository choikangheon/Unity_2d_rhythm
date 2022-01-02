using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    //GameManager¸¦ ½Ì±Û Åæ Ã³¸®ÇÕ´Ï´Ù.
    public static GameManager instance { get; set; } // GameManger °´Ã¼
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

    }
    public float noteSpeed;  // GameMangerÀÇ noteSpeed °ª 
      
         
 public enum judges { NONE = 0 , BAD, GOOD, PERFECT , MISS};
  
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
