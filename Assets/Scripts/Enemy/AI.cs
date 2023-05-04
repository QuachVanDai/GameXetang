using Assets.code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    float midTime, getTime;
    moveenemy moveEnemy;
    string direction;
    void Start()
    {
        getTime = 1.5f;
        moveEnemy = GetComponent<moveenemy>();
    }
 
    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(run), 1.5f);// sau 1.5s sẽ gọi tới hàm run
    }
    void run()
    {
            moveEnemy.setDirection(direction);
            if (direction == "left")
            {
                transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (direction == "right")
            {
                transform.localRotation = Quaternion.Euler(0, 0, 270);

            }
            else if (direction == "down")
            {
                transform.localRotation = Quaternion.Euler(0, 0, 180);

            }
            else if (direction == "up")
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
    }
}
