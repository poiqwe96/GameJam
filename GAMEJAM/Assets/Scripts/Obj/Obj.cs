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
        if (VFX != null)
            VFXinstance = Instantiate(VFX, transform.position, transform.rotation);

      

       // gameObject.SetActive(false);
        
    }

    private void OnDrawGizmos()
    { SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider!=null)
        {Gizmos.color =Color.red;
            Gizmos.DrawWireSphere(transform.position, sphereCollider.radius);
        }
    }


}
public enum OBJTYPE { CLICK,TRIGGER}