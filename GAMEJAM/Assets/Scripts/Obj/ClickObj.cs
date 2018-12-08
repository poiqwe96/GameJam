using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj : Obj {



    public override void OnGetThisObj()
    {
        base.OnGetThisObj();

        gameObject.SetActive(false);
    }




}
