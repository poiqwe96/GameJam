using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObj : Obj {
    Animator anim;
    //주기적으로 
    //3~5
    bool isOpen = false;
    float CD = 2f;
	// Use this for initialization
	void Start () {
        anim=GetComponent<Animator>();
        CD =Random.Range(3f, 5f);
        StartCoroutine(OpenLoop(CD));
	}

    IEnumerator OpenLoop(float _cd)
    {
        while (true)
        {
            isOpen = false;
            Debug.Log("래덤인자 cd :" + _cd);
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
