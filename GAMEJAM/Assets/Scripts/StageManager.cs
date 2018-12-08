using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StageManager : MonoBehaviour {
    public static StageManager instance;
    public GameObject Player;
   public GameObject[] ObjArray;//렌덤배치할 오브젝트
    public GameObject[] PosArray;
    public bool isGenerate;//오브젝트 생성할것인지?
    //transform array

    #region SingleToneAwake
    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Debug.LogError("싱글턴 이미 있음!!");
    }
    #endregion
  
    public UnityEvent ShowSomething;

    public int CountObj=0;//모은 오브젝트 개수
    public int MaxCount=10;//find로 개수맞춤

    [HideInInspector]
   public bool isLootAll = false;

    public void GenerateObj()
    {   
      foreach (GameObject pos in PosArray)
        { int _Random = Random.Range(0, ObjArray.Length );
            Vector3 RandomOffset = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), Random.Range(-3f, 3f));
           GameObject obj= Instantiate(ObjArray[_Random],pos.transform.position+RandomOffset,transform.rotation);
            obj.transform.SetParent(pos.transform);
        }
    }


    private void Start()
    {
        CountObj = 0;
        PosArray = GameObject.FindGameObjectsWithTag("Position");
        Debug.Log("포지션들 찾은 개수:" + PosArray.Length);
        if (isGenerate)
            GenerateObj();

    }
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
   
}
