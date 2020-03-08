using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    public int moveSpeed;
    public int closeDist;
    public bool followOrder = false;
    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;    
        anim = GetComponent<Animator>();
    }
    void Update(){
        if (followOrder) {
            FollowPlayer();
        }  
        if (Input.GetKeyDown(KeyCode.J)) {
            followOrder = true;
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            followOrder = false;
            anim.SetBool("moving", false);
        }
    }
    void FollowPlayer() {
        if (Vector3.Distance(transform.position, target.position) > closeDist) {
            Vector3 dest;
            Vector3 creaturePos = transform.position;
            Vector3 playerPos = target.position;

            if (creaturePos.x > playerPos.x && creaturePos.y > playerPos.y) {
                dest = new Vector3(playerPos.x + closeDist, playerPos.y + closeDist); 
            } else if (creaturePos.x > playerPos.x && creaturePos.y < playerPos.y) {
                dest = new Vector3(playerPos.x + closeDist, playerPos.y + closeDist); 
            } else if (creaturePos.x > playerPos.x && creaturePos.y > playerPos.y) {
                dest = new Vector3(playerPos.x + closeDist, playerPos.y + closeDist); 
            }
            Debug.Log(dest);
            GetComponent<NavMeshAgent2D>().destination = dest;
            changeAnim(dest - transform.position);
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }
    }
    void changeAnim(Vector2 direction) {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            if (direction.x > 0) {
                SetAnimFloat(Vector2.right);
            } else if (direction.x < 0) {
                SetAnimFloat(Vector2.left);
            }
        } else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
            if (direction.y > 0) {
                SetAnimFloat(Vector2.up);
            } else if (direction.y < 0) {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    void SetAnimFloat(Vector2 setVector) {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
}
