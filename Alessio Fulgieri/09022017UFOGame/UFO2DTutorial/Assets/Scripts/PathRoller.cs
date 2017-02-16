using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//http://catlikecoding.com/unity/tutorials/curves-and-splines/
/*[CustomEditor(typeof(Line))]
public class LineInspector : Editor
{
}
public class Line : MonoBehaviour
{
    public Vector3 p0, p1;
}
public class PathRoller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnSceneGUI()
    {
        Line line = target as Line;
        Transform handleTransform = line.transform;
        Quaternion handleRotation = handleTransform.rotation;
        Vector3 p0 = handleTransform.TransformPoint(line.p0);
        Vector3 p1 = handleTransform.TransformPoint(line.p1);

        Handles.color = Color.white;
        Handles.DrawLine(p0, p1);
        Handles.DoPositionHandle(p0, handleRotation);
        Handles.DoPositionHandle(p1, handleRotation);
    }
}*/
