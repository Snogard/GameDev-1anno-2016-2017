using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObserverPattern
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        GameObject sphere;

        [SerializeField]
        GameObject box1Obj;
        [SerializeField]
        GameObject box2Obj;
        [SerializeField]
        GameObject box3Obj;

        Subject subject;

        // Use this for initialization
        void Start()
        {
            subject = new Subject();


            Box box1 = new Box(box1Obj, new JumpLittle());
            Box box2 = new Box(box2Obj, new JumpMedium());
            Box box3 = new Box(box3Obj, new JumpHigh());

            subject.AddObserver(box1);
            subject.AddObserver(box2);
            subject.AddObserver(box3);
        }

        // Update is called once per frame
        void Update()
        {
            if(sphere.transform.position.magnitude<0.5f)
            {
                subject.Notify();
            }
        }
    }
}