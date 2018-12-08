using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    Animator anim;
    public GameObject door;

	// Use this for initialization
	void Start () {
        anim = door.GetComponent<Animator>();
        
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("DoorOpen");
            Destroy(GetComponent<BoxCollider>());
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
