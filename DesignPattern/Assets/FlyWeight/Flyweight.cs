using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Alien
{
    public List<Vector3> eyePositions;
    public List<Vector3> legPositions;
    public List<Vector3> armPositions;
}


public class Flyweight : MonoBehaviour
{
    //list that stores all aliens
    List<Alien> allAliens = new List<Alien>();
    List<Vector3> eyePositions;
    List<Vector3> legPositions;
    List<Vector3> armPositions;


    void Start()
    {
        //list ussed when flyweight os enabled
        eyePositions = GetBodyPartPositions();
        legPositions = GetBodyPartPositions();
        armPositions = GetBodyPartPositions();
        for (int i = 0; i < 10000; i++)
        {
            Alien newAlien = new Alien();

            //addeyes and leg without flyweight
            /*newAlien.eyePositions = GetBodyPartPositions();
            newAlien.legPositions = GetBodyPartPositions();
            newAlien.armPositions = GetBodyPartPositions();*/

            
            newAlien.eyePositions = eyePositions;
            newAlien.armPositions = armPositions;
            newAlien.legPositions = legPositions;
            
            allAliens.Add(newAlien);
        }

    }

    void Update()
    {

    }

    //generates a list with body parts
    private List<Vector3> GetBodyPartPositions()
    {


        List<Vector3> bodyPartsPositions = new List<Vector3>();

        for (int i = 0; i < 1000; i++)
        {
            bodyPartsPositions.Add(new Vector3());
        }

        return bodyPartsPositions;
    }
}
