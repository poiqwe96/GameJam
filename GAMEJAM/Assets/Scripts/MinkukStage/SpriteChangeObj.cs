using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeObj : Obj {
    public GameObject twodemension;
    public override void OnGetThisObj()
    {
        base.OnGetThisObj();
        Camera.main.GetComponent<GlitchEffect>().enabled = true;
        Invoke("OnMove", 3);

        gameObject.SetActive(false);
    }
    public void OnMove()
    {
        twodemension.SetActive(true);

        StageManager.instance.Player.SetActive(false);

    }
}
