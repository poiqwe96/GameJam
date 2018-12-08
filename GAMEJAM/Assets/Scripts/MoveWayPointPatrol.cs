using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWayPointPatrol : MonoBehaviour {

    public Transform[] waypoints;//찍고 갈 지점 트랜스폼 배열 등록 
    public float Speed;//속도 
    int index;//배열 인덱스 
    public float MinDist = 0.5f;//웨이포인트에 도달할 거리 
    private void Update()
    {
        Move();
    }

    private void Move()
    {


        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, Speed * Time.deltaTime);
        //무브투월드가 해당좌표로 이동시킴,벡터반환값을 해당 객체 트랜스폼에 대입


        Vector3 dir = waypoints[index].position - transform.position;//방향전환 
                                                                     //a벡터-b벡터 = b벡터가 a벡터를 바라보는 방향벡터 

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Speed * Time.deltaTime);
        //쿼터니온 러프로 자연스럽게 회전,각도 대입 

        if (Vector3.Distance(transform.position, waypoints[index].position) < MinDist)
        {//index는 처음에 0이므로 첫번째 웨이포인트와 거리가 가까워지면 
            if (index < waypoints.Length - 1)
            {
                index++;
                //index값을 올려서 다음 웨이포인트로 자동 변경 
            }
            else
            {
                index = 0;
                //웨이포인트 끝까지 도달시,0번으로 되돌림 
            }
        }

    }
}
