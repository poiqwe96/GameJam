using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour {
    public static EndingManager instance;//싱글턴+돈디스트로이
    public List<Vector3> SpotPointList =new List<Vector3>();
    public LineRenderer lineRenderer;//발자취 그려줄 랜더러
    #region SingleToneAwake
    private void Awake()
    {if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("싱글턴 이미 있음!!");
            Destroy(gameObject);
        }
    }
    #endregion
 
    public void TestAdd()
    {
        AddSpot(transform.position);
        Debug.Log("현재 좌표 개수:" + SpotPointList.ToArray().Length);
    }


    public void AddSpot(Vector3 _spot)
    {
        SpotPointList.Add(_spot);
    }

    public void MakeLine()
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = SpotPointList.ToArray().Length;
        lineRenderer.SetPositions(SpotPointList.ToArray());
        Debug.Log("현재 라인렌더러 좌표 개수:" + lineRenderer.positionCount);
    }

}
