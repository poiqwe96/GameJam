using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObj : Obj {
    Animator anim;
    //주기적으로 
    //3~5
    bool isOpen = false;
    float CD = 2.5f;
	// Use this for initialization
	void Start () {
        anim=GetComponent<Animator>();
       
        StartCoroutine(OpenLoop(CD));
	}

    IEnumerator OpenLoop(float _cd)
    {
        while (true)
        {
            isOpen = false;

            yield return new WaitForSeconds(_cd);
            isOpen = true;
            anim.SetTrigger("DoorOpen");
            yield return new WaitForSeconds(2f);
           
        }
    }


    public override void OnGetThisObj()
    {
        if (isOpen)
        {
            base.OnGetThisObj();
            gameObject.SetActive(false);
        }
    }
}
