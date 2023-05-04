using Assets.code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour
{
    public static bulletPlayer instance;
    AudioSource audioSource;
    public AudioClip amThanhBan;
    public  GameObject bullets;
    public Transform firePoint;
    public float speed;
    Vector2 lookDirection;
    public Transform huongBan;
    float lookAngle;
    float getTime, midTime;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
       // playerController1 = GameObject.Find("player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        midTime = Time.time - getTime;
        if(midTime >=0.5f)
        {
            cloneBullets();
            getTime=Time.time;
        }
    }
    public void cloneBullets()
    {
        lookDirection = huongBan.position;
        lookAngle = Mathf.Atan2(lookDirection.y - firePoint.position.y, lookDirection.x - firePoint.position.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        GameObject bulletClone = Instantiate(bullets);
        bulletClone.transform.position = firePoint.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle+270);
        bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * speed;
        audioSource.PlayOneShot(amThanhBan);
    }
   
}
