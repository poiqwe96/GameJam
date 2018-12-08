using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FirstPersonController : MonoBehaviour {
    Rigidbody rgd;
    public float Speed = 250f;//리지드바디 속도
    public UnityAction TriggerObj;//오브젝트 상호작용 델리게이트
    public UnityAction ClickedObj;

    [Header("Debug")]
    public bool isAuto = false;
    public bool isDebug = false;
    [HideInInspector]
    public GameObject FocusedTarget;//현재 클릭한 타겟
    float SpeedMultiple = 1.8f;
    //Mouse
    [Space]
    [Header("MouseVar")]
    public LayerMask RayMask;//클릭할 오브젝트 레이어마스크
    public float RayDistance = 10f;//클릭 사거리
    public float MouseSensitive = 1f;//마우스 속도
    float ClampY;//각 고정
    private void Awake()
    {
        rgd = GetComponent<Rigidbody>();
        ClampY = 0f;
        if (!isDebug)
            LockCursor();
    }


    private void Update()
    {
        CameraRot();


        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (isAuto)
        {
            movement.x = 0;
            movement.z = 1f;
        }
        Vector3 CoordFromCam = Camera.main.transform.TransformDirection(movement);

        CoordFromCam.y = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
            rgd.velocity = CoordFromCam * Time.deltaTime * Speed * SpeedMultiple;
        else
            rgd.velocity = CoordFromCam * Time.deltaTime * Speed;

       
        ClickObj();
    }

    public void ClickObj()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, RayDistance, RayMask))
            {
                //FocusedTarget
                FocusedTarget = hit.collider.gameObject;
                Debug.Log("Focused Target:" + FocusedTarget.name);
                Obj obj = FocusedTarget.GetComponent<Obj>();
                obj.OnGetThisObj();
                Destroy(obj.VFXinstance, 1f);
            }
        }
    }
  void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void CameraRot()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * MouseSensitive;// * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * MouseSensitive;// * Time.deltaTime;

        ClampY += mouseY;
        if(ClampY > 90f)
        {
            ClampY = 90.0f;
            mouseY = 0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (ClampY < -90f)
        {
            ClampY = -90.0f;
            mouseY = 0f;
            ClampXAxisRotationToValue(90.0f);
        }



        Camera.main.transform.Rotate(Vector3.left * mouseY);


        transform.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }//짐벌락방지
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, RayDistance);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Obj"))//클릭할 오브젝트 태그 설정 필요
    //    {
    //        if (TriggerObj != null)
    //            TriggerObj.Invoke();
    //        Obj obj = other.GetComponent<Obj>();

    //        if(obj.OBJTYPE == OBJTYPE.TRIGGER)
    //        {
    //            obj.OnGetThisObj();
    //        }
    //        //ShowThis.SetActive(true);
    //         other.gameObject.SetActive(false);
    //    }
    //}
}
