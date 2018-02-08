using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public bool dDebug = true;
    public float Radius = 2.0f;
    public Vector3[] PointA;

    public float Length
    {
        get
        {
            return PointA.Length;
        }
    }

    public Vector3 GetPoint(int index)
    {
        return PointA[index];
    }

    void OnDrawGizmos()
    {
        if (!dDebug)
        {
            return;
        }

        for (int i = 0; i <PointA.Length; i++)
        {
            if(i+1 < PointA.Length) //포인트 범위가 i+1한 값보다 작아질때까지
            {
                Debug.DrawLine(PointA[i], PointA[i + 1], Color.red);// 기즈모 라인을 그린다 포인트 A에서 A+1포인트(다음 포인트)까지 붉은색으로
            }
        }
    }
}
