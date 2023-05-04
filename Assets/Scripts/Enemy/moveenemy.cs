
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.code
{

    public class moveenemy : MonoBehaviour
    {
        public static moveenemy instance;
        public nodeController currNode2;
        public float speed = 4f;
        public string direction = "up";
        public string lastMoveDirection = "up";
       // public GameObject player;
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
         direction = "up";
        lastMoveDirection = "up";
        currNode2 = GameObject.Find("node").GetComponent<nodeController>();
            
        }
        public void Update()
        {
          
            transform.position = Vector2.MoveTowards(transform.position, currNode2.transform.position, speed * Time.deltaTime);
           
            if (transform.position.x == currNode2.transform.position.x && transform.position.y == currNode2.transform.position.y)
            {
                  GameObject newNode =currNode2.GetNodeFromDirection(direction);
                if (newNode != null)
                {
                    currNode2 = newNode.GetComponent<nodeController>();
                    lastMoveDirection = direction;
                }
                // we can nit move in desire direction try tokeep going in  the last 
                else
                {
                    direction = lastMoveDirection;
                    newNode = currNode2.GetNodeFromDirection(direction);
                    if (newNode != null)
                    {
                        currNode2 = newNode.GetComponent<nodeController>();
                    }
                }
            }
        }
        public void setDirection(string newdirection)
        {
            direction = newdirection;
        }

    }

}