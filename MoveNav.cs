using UnityEngine;
using System.Collections;

public class MoveNav : MonoBehaviour {

    void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 dest = GameObject.FindWithTag("Player").transform.position;
            Vector3 w = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<NavMeshAgent2D>().destination = dest;
        }
    }
}