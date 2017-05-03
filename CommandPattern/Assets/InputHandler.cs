using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public Transform boxTrans;
        /// <summary>
        /// comandi dei bottoni
        /// </summary>
        private ICommand buttonW, buttonS, buttonA, buttonD, buttonB, buttonZ, buttonR;
        /// <summary>
        /// lista dei comandi digitati
        /// </summary>
        public static List<ICommand> oldCommands = new List<ICommand>();
        /// <summary>
        /// posizione iniziale
        /// </summary>
        private Vector3 boxStartPos;
        /// <summary>
        /// coroutine che si occupa del replay
        /// </summary>
        private Coroutine replayCoroutine;
        /// <summary>
        /// 
        /// </summary>
        public static bool shouldStartReplay;
        /// <summary>
        /// 
        /// </summary>
        private bool isReplaying;




        void Start()
        {
            boxTrans = gameObject.transform;
            buttonW = new DoNothing();
            buttonS = new MoveForward();
            buttonA = new MoveReverse();
            buttonD = new MoveLeft();
            buttonB = new MoveRight();
            buttonZ = new UndoCommand();
            buttonR = new ReplayCommand();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isReplaying)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    buttonA.Execute(boxTrans, buttonA);
                }
                else if (Input.GetKeyDown(KeyCode.B))
                {
                    buttonB.Execute(boxTrans, buttonB);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    buttonD.Execute(boxTrans, buttonD);
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    buttonR.Execute(boxTrans, buttonR);
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    buttonS.Execute(boxTrans, buttonS);
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    buttonW.Execute(boxTrans, buttonW);
                }
                else if (Input.GetKeyDown(KeyCode.Z))
                {
                    buttonZ.Execute(boxTrans, buttonZ);
                }
            }

            StartReplay();

        }
        void  StartReplay()
        {
            if(shouldStartReplay&&oldCommands.Count>0)
            {
                shouldStartReplay = false;
                if(replayCoroutine!=null)
                {
                    StopCoroutine(replayCoroutine);
                }
                replayCoroutine = StartCoroutine(ReplayCommands(boxTrans));

            }
        }
        IEnumerator ReplayCommands(Transform tranf)
        {
            isReplaying = true;
            tranf.position = boxStartPos;
            for (int i = 0; i < oldCommands.Count; i++)
            {
                oldCommands[i].Move(tranf);
                yield return new WaitForSeconds(0.3f);
            }
            isReplaying = false;
        }
    }
}
