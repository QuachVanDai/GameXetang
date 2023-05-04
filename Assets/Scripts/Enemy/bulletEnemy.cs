using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    public static bulletEnemy instance;
    public GameObject bullets;
    public Transform firePoint;
    public float speed;
    Vector2 lookDirection;
    public Transform huongBan;
    float lookAngle;
    float getTime, midTime;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        midTime = Time.time - getTime; 
        if (midTime >= 0.5f) // sau 0.5s sẽ gọi cloneBullets
        {
            cloneBullets();
            getTime = Time.time;
        }
    }
    public void cloneBullets()
    {
        
        lookDirection = huongBan.position; 
        lookAngle = Mathf.Atan2(lookDirection.y - firePoint.position.y
            , lookDirection.x - firePoint.position.x) * Mathf.Rad2Deg; // tính tooán  hướng bắn 
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle); // gắn hướng bắn vào mũi súng 
        GameObject bulletClone = Instantiate(bullets);  // tạo clone 
        bulletClone.transform.position = firePoint.position; // vị trí bắn 
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle + 270); // gắn hướng bắn cho clonee
        bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * speed; // tốc độ 
    }

}
