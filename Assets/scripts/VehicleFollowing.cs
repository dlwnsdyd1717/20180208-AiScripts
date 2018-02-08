using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFollowing : MonoBehaviour {

    public Path path;
    public float speed = 20.0f;
    public float mass = 5.0f;

    public bool isLooping = true;

    private float curSpeed;

    private int curPathIndex;
    private float pathLength;
    private Vector3 targetPoint;

    Vector3 velocity;

    void Start()
    {
        pathLength = path.Length;//==path.PointA.Length
        curPathIndex = 0;

        velocity = transform.forward; // 방향을 포워드(z)축으로 잡음

    }

    void Update()
    {
        
        curSpeed = speed * Time.deltaTime;

        targetPoint = path.GetPoint(curPathIndex);

        if(Vector3.Distance(transform.position, targetPoint)< path.Radius)
        {
            if(curPathIndex < pathLength - 1)
            {
                curPathIndex++;
            }
            else
            {
                if (isLooping)
                {
                    curPathIndex = 0;
                }
                else
                {
                    return;
                }
            }
        }

        if(curPathIndex >= pathLength)// 배열의 크기보다 커지지 않게 하기위해서 만들었음 
        {
            return;
        }
        if(curPathIndex >= pathLength-1 && !isLooping) 
        {
            velocity += Steer(targetPoint, true);
        }
        else
        {
            velocity += Steer(targetPoint);
        }
        transform.position += velocity;
        transform.rotation = Quaternion.LookRotation(velocity);
    }

    public Vector3 Steer(Vector3 target, bool dFinalPoint = false)
    {
        
        Vector3 desiredVelocity = (target - transform.position);
        float dist = desiredVelocity.magnitude;// == float에 Distance와 같다.

        desiredVelocity.Normalize();

        if (dFinalPoint && dist < 10.0f)
        {
            
            desiredVelocity *= (curSpeed * (dist / 10.0f));
        }
        else
        {
            desiredVelocity *= curSpeed;
        }

        Vector3 steeringForce = desiredVelocity - velocity;
        Vector3 acceleration = steeringForce / mass;

        return acceleration;

    }

}
