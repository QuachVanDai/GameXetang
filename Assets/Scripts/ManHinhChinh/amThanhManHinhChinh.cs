using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amThanhManHinhChinh : MonoBehaviour
{
    // Start is called before the first frame update
    public static amThanhManHinhChinh instance;
    AudioSource[] m_AudioSource;
    public GameObject batTatAmThanh; // dấu gạch chéo 
    private void Awake()
    {
        instance= this;
    }
    void Start()
    {
        m_AudioSource= GetComponents<AudioSource>();
       
        if (PlayerPrefs.GetInt("OnOffAmThanhNen") == 1)
        {
            m_AudioSource[0].Play();
            batTatAmThanh.SetActive(false);
            Debug.Log(1);
        }
        else if (PlayerPrefs.GetInt("OnOffAmThanhNen") == 0)

        {
            m_AudioSource[0].Stop();
            batTatAmThanh.SetActive(true);
        }
    }
    public void btnOffOnAmThanh()
    {
        if (m_AudioSource[0].isPlaying)
        {
            m_AudioSource[0].Pause();
            PlayerPrefs.SetInt("OnOffAmThanhNen", 0);
            batTatAmThanh.SetActive(true);
        }
        else
        {
            m_AudioSource[0].Play();
            PlayerPrefs.SetInt("OnOffAmThanhNen", 1);
            batTatAmThanh.SetActive(false);
        }
    }
}
