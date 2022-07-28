using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FlowController))]
public class FlowControllerEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (Application.isPlaying)
        {

            FlowController myScript = (FlowController)target;

            if (GUILayout.Button("OpenMenu"))
            {
                myScript.OpenMenu();
            }

            if (GUILayout.Button("OpenGame"))
            {
                myScript.OpenGame();
            }

            if (GUILayout.Button("OpenResults"))
            {
                myScript.OpenResults();
            }
        }
    }
}
