using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FOVEditor : Editor
{
    void OnSceneGUI()
    {
        FieldOfView fOV = (FieldOfView)target;
        Handles.color = Color.blue;
        Handles.DrawWireArc(fOV.transform.position, Vector3.up, Vector3.forward, 360, fOV.viewRadius);

        Vector3 viewAngleA = fOV.DirFromAngle(-fOV.viewAngle / 2, false);
        Vector3 viewAngleB = fOV.DirFromAngle(fOV.viewAngle / 2, false);

        Handles.DrawLine(fOV.transform.position, fOV.transform.position + viewAngleA * fOV.viewRadius);
        Handles.DrawLine(fOV.transform.position, fOV.transform.position + viewAngleB * fOV.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTargets in fOV.visibleTargets)
        {
            Handles.DrawLine(fOV.transform.position, visibleTargets.position);
        }
    }
}
