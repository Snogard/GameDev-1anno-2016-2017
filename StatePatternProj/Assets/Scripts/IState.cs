using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IState
{
    /// <summary>
    /// 
    /// </summary>
    void UpdateState(StateController controller);

    /// <summary>
    /// 
    /// </summary>
    void OnTriggerEnter(StateController controller);

    /// <summary>
    /// 
    /// </summary>
    void OnTriggerExit(StateController controller);



}
