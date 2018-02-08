using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugs : MonoBehaviour {
    public float movespeed;
    public float rotspeed;
    public enum BUGSTATE
        {
           IDLE,
           LEFT,
           RIGHT,
           FORWARD

        };
    public float senseLegth;
    public float turnCool;
    public float turnDelay;


    public BUGSTATE bugstate;
    
	void Update ()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit, senseLegth))
        {

            if(hit.transform.tag == "wall"&& bugstate != BUGSTATE.LEFT && bugstate !=BUGSTATE.RIGHT)
            {
                int ranState = Random.Range(0,2);
                switch (ranState)
                {
                    case 0:
                        bugstate = BUGSTATE.LEFT;
                        break;
                    case 1:
                        bugstate = BUGSTATE.RIGHT;
                        break;
                    
                }
            }
           
        }


        switch (bugstate)
        {
            case BUGSTATE.IDLE:
                break;
            case BUGSTATE.LEFT:
                transform.Rotate(0, -rotspeed * Time.deltaTime, 0);
                turnCool += Time.deltaTime;
                if (turnCool > turnDelay)
                {
                    bugstate = BUGSTATE.FORWARD;
                    turnCool = 0;
                }
                break;
            case BUGSTATE.RIGHT:
                transform.Rotate(0, rotspeed * Time.deltaTime, 0);
                turnCool += Time.deltaTime;
                if (turnCool > turnDelay)
                {
                    bugstate = BUGSTATE.FORWARD;
                    turnCool = 0;
                }
                break;
            case BUGSTATE.FORWARD:
                transform.Translate(0, 0, movespeed * Time.deltaTime);
                break;
            default:
                break;
        }





    }
}
