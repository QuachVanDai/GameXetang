
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.code
{
    public class nodeController : MonoBehaviour
    {
        public bool canMoveLeft = false;
        public bool canMoveRight = false;
        public bool canMoveUp = false;
        public bool canMoveDown = false;
        public GameObject nodeLeft;
        public GameObject nodeRight;
        public GameObject nodeUp;
        public GameObject nodeDown;

        
        public void Awake()
        {

        }
      
        public void Start()
        {
            
  
           
            RaycastHit2D[] hitDown;
            hitDown = Physics2D.RaycastAll(transform.position, -Vector2.up);
            for (int i = 0; i < hitDown.Length; i++)
            {
                float distance = Mathf.Abs(hitDown[i].point.y - transform.position.y);
               
                if (distance < 0.9f && hitDown[i].collider.tag=="node")
                {
                    canMoveDown = true;
                    nodeDown = hitDown[i].collider.gameObject;
                }
            }
            RaycastHit2D[] hitUp;
            hitUp = Physics2D.RaycastAll(transform.position,Vector2.up);
            for (int i = 0; i < hitUp.Length; i++)
            {
              
                float distance = Mathf.Abs(hitUp[i].point.y - transform.position.y);
        
                if (distance < 0.9f && hitUp[i].collider.tag == "node")
                {
                    canMoveUp = true;
                    nodeUp = hitUp[i].collider.gameObject;
                }
            }
            RaycastHit2D[] hitRight;
            hitRight = Physics2D.RaycastAll(transform.position, Vector2.right);
            for (int i = 0; i < hitRight.Length; i++)
            {
                float distance = Mathf.Abs(hitRight[i].point.x - transform.position.x);
            
                if (distance < 0.9f && hitRight[i].collider.tag == "node")
                {
                    canMoveRight = true;
                    nodeRight = hitRight[i].collider.gameObject;
                 //  GhostAI.instance.waypoints.Add(hitRight[i].transform);

                }
            }
            RaycastHit2D[] hitLeft;
            hitLeft = Physics2D.RaycastAll(transform.position,-Vector2.right);
            for (int i = 0; i < hitLeft.Length; i++)
            {
                float distance = Mathf.Abs(hitLeft[i].point.x - transform.position.x);
               
                if (distance < 0.9f && hitLeft[i].collider.tag == "node")
                {
                    canMoveLeft = true;
                    nodeLeft = hitLeft[i].collider.gameObject;
                 //   GhostAI.instance.waypoints.Add(hitLeft[i].transform);

                }
            }

        }
        public void Update()
        {

        }
        public GameObject GetNodeFromDirection(string direction)
        {
            if (direction == "left" && canMoveLeft)
            {
                return nodeLeft;
            }
            else if (direction == "right" && canMoveRight)
            {
                return nodeRight;
            }
            else if (direction == "up" && canMoveUp)
            {
                return nodeUp;
            }
            else if (direction == "down" && canMoveDown)
            {
                return nodeDown;
            }
            else { return null; }
        }
    }

}
