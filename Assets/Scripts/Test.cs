using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject test;
    public GameObject target;
    public float rotateAmount = 90f;
    public int count = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ContextMenu("TestRotate")]
    public void TestRotate()
    {
        float rotate = 360f / count;
        for (int i = 0; i < count; i++)
        {
            transform.Rotate(Vector3.up, rotate * i);
            Debug.Log(rotate * i);

            Debug.DrawRay(transform.position, transform.forward, Color.green, 3f);
        }
    }

    void TransformRotate()
    {
        // 일반 회전 : Vector3
        transform.Rotate(Vector3.up * rotateAmount);
    }

    void LookRotation()
    {   
        // 방향 벡터를 구해서 대상을 바라보게하는 회전
        Vector3 directionToTarget = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionToTarget);
    }

    void CircularDrawing()
    {
        float rotate = 360f / count;
        for (int i = 0; i < count; i++)
        {
            Vector3 dir = Quaternion.Euler(0f, rotate * i, 0f) * transform.forward;
            Debug.DrawRay(transform.position, dir, Color.green, 3f);
            
            GameObject obj = Instantiate(test);
            obj.SetActive(true);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            
            rb.AddForce(dir, ForceMode.Impulse);
        }
    }
}
