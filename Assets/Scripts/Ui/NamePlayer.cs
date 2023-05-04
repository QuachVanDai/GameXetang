using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class NamePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static NamePlayer instance;
    public Text txtNamePlayer_In, txtNamePlayer_G,txtNamePlayerTop_G;
    public TMP_InputField nameInputFile;
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        txtNamePlayer_In.text= PlayerPrefs.GetString("txtname");
        txtNamePlayer_G.text= PlayerPrefs.GetString("txtname_G");
        txtNamePlayerTop_G.text= PlayerPrefs.GetString("txtnameTop_G");
        nameInputFile.text= PlayerPrefs.GetString("Inputname");
    }
    public void setName()
    {
        
        string txt = nameInputFile.text;
        if (string.IsNullOrEmpty(txt))
        {
            Debug.Log("Input field is empty or contains only whitespace.");
        }
        else
        {
            txtNamePlayer_In.text = nameInputFile.text;
            txtNamePlayer_G.text = nameInputFile.text;
            PlayerPrefs.SetString("txtname", txtNamePlayer_In.text);
            PlayerPrefs.SetString("txtname_G", txtNamePlayer_G.text);
            PlayerPrefs.SetString("Inputname", txtNamePlayer_In.text);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
