using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpin : MonoBehaviour {
    int RandomIndex = 0;
	// Use this for initialization
	void Start () {
        RandomIndex = Random.Range(0, 2);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rot = transform.eulerAngles;
       switch(RandomIndex)
        {
            case 0:
                rot.z++;
                rot.y--;
                break;


            case 1:
                rot.z--;
                rot.y++;
                break;
          

        }
       
        transform.eulerAngles = rot;
	}
}
