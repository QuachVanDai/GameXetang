using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class desbulletenemy : MonoBehaviour
{
    public GameObject hieuUngNo;
    public GameObject hieuUngChamTuong;
    void Update()
    {
        Invoke(nameof(destroy), 1.5f);
    }
    private void destroy()
    {
        Destroy(gameObject);
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            // khi đạn của địch  chạm vào xe tăng người chơi
            Destroy(gameObject); // phá hủy đạn 
            Instantiate(hieuUngNo, transform.position, Quaternion.identity); // tạo ra hiệu ứng nổ 
            hpPlayer.Instance.soluongBlood--; // hp của xe tăng địch giảm đỉ 1
            hpPlayer.Instance.hienBlood(); // gọi hàm hienBlood trong class hpPlayer
            if (hpPlayer.Instance.soluongBlood<=0)
            {
                GameController.instance.GameOver(); // gọi penal GameOver
                Destroy(col.gameObject); // phá hủy xe tăng 
            }
            
        }
        if (col.gameObject.tag == "bulletvang")    // khi đạn của địch  chạm vào đạn của địch 
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "bulletdo")  // khi đạn của địch  chạm vào đạn của xe tang người chơi 
        {
             Destroy(col.gameObject); // phá hủy đạn xe tăng người chơi
            Destroy(gameObject); // phá hủy đạn địch
        }
        if (col.gameObject.tag == "enemythuong")  // khi đạn của địch  chạm vào xe tăng địch 
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "tuong") // khi đạn của địch  chạm vào tường
        {
            Instantiate(hieuUngChamTuong, 
                new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity); //hiệu ứng nổ khi chạm tường
            Destroy(gameObject);// phá hủy đạn
        }

    }
}
