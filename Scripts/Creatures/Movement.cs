using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    public int moveSpeed;
    public bool followOrder;
    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;    
        anim = GetComponent<Animator>();
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.J)) {
            followOrder = true;
        }
        if (followOrder) {
            FollowPlayer();
        }       
    }
    void FixedUpdate()
    {
        // if (Input.GetKeyDown(KeyCode.J)) {
        //     Debug.Log("pressed button");
        //     FollowPlayer();
        // }
    }
    void FollowPlayer() {
        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
        myRigidbody.MovePosition(temp);
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
