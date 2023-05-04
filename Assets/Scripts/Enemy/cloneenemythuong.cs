using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class cloneenemythuong : MonoBehaviour
{
    // Start is called before the first frame update
    public static cloneenemythuong instance;
    public GameObject enemyThuong;
    public int sluong = 4;
    float getTime, midTime, timeBink, blinkDuration = 0.1f, timeBink1 = 1f;
    private void Awake()
    {
        instance = this; 
    }
    private void Start()
    {
        StartCoroutine(clone());
        sluong -= 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (sluong >0)//  số lượng quái vật trên màn hình 
        {

            midTime = Time.time - getTime;
            if (midTime >= 2f) // thời gian xuất hiện quái vật 
            {
                StartCoroutine(clone());
                getTime = Time.time;
                sluong--;
            }
        }
    }
    private IEnumerator clone()
    {
        GameObject clenemy;
        clenemy = Instantiate(enemyThuong);  // tạo ra một clone 
        clenemy.transform.position = new Vector2(-7.5f, -3.5f); // vị trí 
        clenemy.transform.rotation = Quaternion.identity; // không xoay
        while (timeBink>0) // thời gian nhấp nháy 
        {
            clenemy.GetComponent<Renderer>().enabled = true;  
            yield return new WaitForSeconds(blinkDuration); // blinkDuration là khoảng thời gian hiện 
            clenemy.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(blinkDuration); // blinkDuration là khoảng thời gian  ẩn
            timeBink -= 0.101f; // điều kiện vòng lặp 
        }
        clenemy.GetComponent<Renderer>().enabled = true; // đảm bảo elemey hiện khi thoát vòng lặp 
        timeBink = timeBink1; // gắn lại time lặp 
    }
}


