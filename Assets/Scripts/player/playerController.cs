using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.code
{
    public class playerController : MonoBehaviour

    {
        movePlayer movePlay;
        public void Start()
        {
            movePlay = GetComponent<movePlayer>();
        }
        public void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                movePlay.setDirection("left");
                transform.localRotation = Quaternion.Euler(0, 0, 90);
                movePlayer.Instance.ckspeed = 1;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                movePlay.setDirection("right");
                transform.localRotation = Quaternion.Euler(0, 0, 270);
                movePlayer.Instance.ckspeed = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movePlay.setDirection("down");
                transform.localRotation = Quaternion.Euler(0, 0, 180);
                movePlayer.Instance.ckspeed = 1;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                movePlay.setDirection("up");
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                movePlayer.Instance.ckspeed = 1;
            }
            else
            {
                movePlayer.Instance.ckspeed = 0;
            }

        }
    }
}
