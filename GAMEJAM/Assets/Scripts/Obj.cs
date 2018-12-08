using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour {

    public GameObject twodemension;
    public GameObject Player;
    public GameObject VFX;
    [HideInInspector]
   public GameObject VFXinstance;
    public OBJTYPE OBJTYPE;

	private void Start()
	{
        Player = GameObject.Find("Player");
	}
	public  virtual void OnGetThisObj()//클릭시
    {
        StageManager.instance.AddCountObj();
        VFXinstance= Instantiate(VFX, transform.position, transform.rotation);
        Player.gameObject.transform.Find("Main Camera").GetComponent<GlitchEffect>().enabled = true;
        gameObject.SetActive(false);
        Invoke("OnMove", 3);
    }

	public void OnMove()
    {
        twodemension.SetActive(true);
        Player.SetActive(false);

    }


}
public enum OBJTYPE { CLICK,TRIGGER}