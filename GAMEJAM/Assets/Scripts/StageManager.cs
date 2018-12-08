using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StageManager : MonoBehaviour {
    public static StageManager instance;
    public GameObject Player;
    GameObject[] ObjArray;
    #region SingleToneAwake
    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Debug.LogError("싱글턴 이미 있음!!");
    }
    #endregion
    private void Start()
    {
        ObjArray = GameObject.FindGameObjectsWithTag("Obj");
        MaxCount=ObjArray.Length;
    }
    public UnityEvent ShowSomething;

    public int CountObj=0;//모은 오브젝트 개수
    public int MaxCount=10;//find로 개수맞춤

    [HideInInspector]
   public bool isLootAll = false;
    public void AddCountObj()//개수증가
    {
        CountObj++;

        if (CountObj >= MaxCount)
        {
            if (ShowSomething != null)
                ShowSomething.Invoke();//인스펙터에 등록한 이벤트를 발동,예를들면 아까본 핑크벽 보여주기
            isLootAll = true;
            Player.GetComponent<MakeSpot>().StopAllCoroutines();
        }
    }
    public void AddCountObj(int _objCount)//개수증가가 한개가아닐때 오버로드
    {
        CountObj+=_objCount;

        if (CountObj >= MaxCount)
        {
            if (ShowSomething != null)
                ShowSomething.Invoke();
            isLootAll = true;
            Player.GetComponent<MakeSpot>().StopAllCoroutines();
        }
    }
}
