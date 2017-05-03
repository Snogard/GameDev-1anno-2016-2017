using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatroState : IState
{

   

    /// <summary>
    /// in  pattuglia
    /// </summary>
    public void OnTriggerEnter(StateController controller)
    {
        controller.ChangeState(new ChaseState());
    }

    /// <summary>
    /// esci pattuglia
    /// </summary>
    public void OnTriggerExit(StateController controller)
    {
        controller.SetTarget(StateController.ETargetType.WAYPOINT);
    }

    public void UpdateState(StateController controller)
    {
        if (Vector3.Distance( controller.transform.position, controller.GetCurrentWayPoint().position)<1f)
        {
            controller.SetTarget(StateController.ETargetType.WAYPOINT);
        }
    }
}
