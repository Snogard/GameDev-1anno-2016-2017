using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    public void OnTriggerEnter(StateController controller)
    {
        
    }

    public void OnTriggerExit(StateController controller)
    {
        controller.ChangeState(new PatroState());
    }
    public void UpdateState(StateController controller)
    {
        controller.SetTarget(StateController.ETargetType.PLAYER);
    }
}
