using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour {

    public GameObject VFX;
    [HideInInspector]
   public GameObject VFXinstance;
    public OBJTYPE OBJTYPE;
    public  virtual void OnGetThisObj()//클릭시
    {
        StageManager.instance.AddCountObj();
        VFXinstance= Instantiate(VFX, transform.position, transform.rotation);
        gameObject.SetActive(false);
      
    }
  
	
}
public enum OBJTYPE { CLICK,TRIGGER}