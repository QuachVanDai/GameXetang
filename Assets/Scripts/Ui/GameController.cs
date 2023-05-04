using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Slider SliderLoading;
    public GameObject btnPlay,btnOnOffAmThanhNen,btnPause,btnContinue,btnRestart,btnOkName,btnCanCelName;
    public GameObject PanelGameOver,panelPause, panalInputName;
    bool ckPlayGame;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      //  SliderLoading.maxValue= 1;
        //SliderLoading.value = 0;
        ckPlayGame = false;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        PanelGameOver.SetActive(true);
    }
    public void Ok_Name()
    {
        NamePlayer.instance.setName();
        panalInputName.SetActive(false);
        Time.timeScale = 1;
    }
    public void CanCel_Name()
    {
        Application.LoadLevel("manHinhChinh");
        Time.timeScale = 0;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
        timeGame.instance.CancelInvoke(nameof(timeGame.instance.timeGameOver));
    }
    public void restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel("manHinhChinh");

    }
    public void continues()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        timeGame.instance.InvokeRepeating(nameof(timeGame.instance.timeGameOver),0,1f);
    }
    public void btnPlayGame()
    {
        Time.timeScale = 0;
        ckPlayGame = true;
    }
    public void OnOffAmThanhNen()
    {
        amThanhManHinhChinh.instance.btnOffOnAmThanh();
    }
        // Update is called once per frame
  public void Update()
    {
        if(ckPlayGame == true && SliderLoading.value <= 1)
        {
            SliderLoading.value +=0.005f;
            if (SliderLoading.value >= 1)
            {
                Application.LoadLevel("man1");
            }

        }
        
    }
   
   
}
