
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.code
{

    public class movePlayer : MonoBehaviour
    {
        public static movePlayer Instance; // dùng đẻ các class khác có thể gọi tới các phương thức, biến dangj public 
        public GameObject currNode;
        public float speed=4f;
        public string direction = "";  // hướng của xe tăng 
        public string lastMoveDirection = ""; 
        public int ckspeed;
        private void Awake()
        {
              Instance= this;
              ckspeed = 0; // 
         }
        public void setDirection(string newdirection)
        {
            direction = newdirection;
        }
        public void Update()
        {
                nodeController currNodeController = currNode.GetComponent<nodeController>(); // 
            transform.position = Vector2.MoveTowards(transform.position,
                currNode.transform.position,ckspeed* speed * Time.deltaTime);  // tốc độ của xe 

            if (transform.position.x == currNode.transform.position.x && transform.position.y == currNode.transform.position.y
                )
            {
              
                 GameObject newNode = currNodeController.GetNodeFromDirection(direction);
                // gắn currNodeController.GetNodeFromDirection(direction) cho  newNode  để  
                if (newNode != null)
                {
                    currNode = newNode;
                    lastMoveDirection = direction;
                }
                // we can nit move in desire direction try tokeep going in  the last 
                else
                {
                    direction = lastMoveDirection;
                    newNode = currNodeController.GetNodeFromDirection(direction);
                    if (newNode != null)
                    {
                        currNode = newNode;
                    }
                }
            }
        }
      
    }

}