using Assets.code;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class destroysBullet : MonoBehaviour
{

    public GameObject hieuUngNo;
    public GameObject hieuUngChamTuong;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(destroy),1.5f);
    }
    private void destroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
         if(col.gameObject.tag == "enemythuong" ) 
         {
             score.instance.diemso++;
             cloneenemythuong.instance.sluong++;
             Instantiate(hieuUngNo, transform.position, Quaternion.identity);
             Destroy(col.gameObject);
             Destroy(gameObject);
        }
        if (col.gameObject.tag == "tuong")
        {
            Instantiate(hieuUngChamTuong, new Vector2(transform.position.x,transform.position.y+0.5f), Quaternion.identity);
            Destroy(gameObject);
        }

    }
}

