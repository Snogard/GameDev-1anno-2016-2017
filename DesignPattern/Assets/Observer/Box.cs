using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObserverPattern
{
    public class Box : Observer
    {
        GameObject boxObj;

        BoxEvent boxEvent;

        public Box(GameObject obj, BoxEvent boxEvent)
        {
            boxObj = obj;
            this.boxEvent = boxEvent;
        }


        public override void OnNotify()
        {
            Jump(boxEvent.GetJumpForce());
        }

        void Jump(float jumpForce)
        {
            if(boxObj.transform.position.y<0.55f)
            {
                boxObj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }
    }
}
