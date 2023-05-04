using Assets.code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static score instance;
    public int diemso=0, diemcao=0;
    public Text txtDiemSo, txtDiemSoGameOver ,txtDiemCao;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        txtDiemCao.text = PlayerPrefs.GetInt("txtDiemCao").ToString();
        diemcao = PlayerPrefs.GetInt("txtDiemCao");

    }

    // Update is called once per frame
    void Update()
    {
        txtDiemSo.text = diemso.ToString();
        txtDiemSoGameOver.text = diemso.ToString();
        if (diemso > diemcao)
        {
            diemcao= diemso;
            txtDiemCao.text= diemcao.ToString();
            PlayerPrefs.SetInt("txtDiemCao", diemcao);
            PlayerPrefs.SetString("txtnameTop_G", NamePlayer.instance.txtNamePlayer_In.text);
            NamePlayer.instance.txtNamePlayerTop_G.text = NamePlayer.instance.txtNamePlayer_In.text;
        }
    }
}
