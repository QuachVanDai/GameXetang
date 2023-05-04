using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class timeGame : MonoBehaviour
{
    public static timeGame instance;
    public float timePhut = 3f;
     public Text timegame;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timePhut *= 60;
        InvokeRepeating(nameof(timeGameOver), 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(timePhut <0f)
        {
            GameController.instance.GameOver();
        }
        
    }
   public void timeGameOver()
    {
        int hour = Mathf.FloorToInt(timePhut / 3600f);
        int minutes = Mathf.FloorToInt(timePhut / 60f);
        int seconds = Mathf.FloorToInt(timePhut - minutes * 60f);
        string timerString = string.Format("{0:00}:{1:00}:{2:00}",hour, minutes, seconds);
        timegame.text = timerString;
        timePhut -= 1;
    }
    public void gameOver()
    {

    }
}
