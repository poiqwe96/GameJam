using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSpot : MonoBehaviour {
    public float makeSpotCD = 1f;
    public bool MakeSpotYes = true;
	// Use this for initialization
	void Start () {
       if( MakeSpotYes)
        StartCoroutine(MakeSpotCD(makeSpotCD));
	}
	IEnumerator MakeSpotCD(float _delay)
    {
        while(!StageManager.instance.isLootAll)
        {
            yield return new WaitForSeconds(_delay);
            EndingManager.instance.AddSpot(transform.position);

        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
