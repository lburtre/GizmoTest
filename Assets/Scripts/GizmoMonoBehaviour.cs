using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GizmoMonoBehaviour : MonoBehaviour
{
    private const float RADIUS_GIZMO = 0.2f;
    private const float TEXT_HEIGHT = 0.6f;
    private const float OFFSET_DOWN_TEXT = -0.1f;

    public Vector3 positionGizmo;
    public string name = "";

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(positionGizmo, RADIUS_GIZMO);
        //Gizmos.DrawIcon(positionGizmo, "");

        Vector3 newPosition = positionGizmo + Vector3.up * TEXT_HEIGHT;

        GUIStyle blackStyle = new GUIStyle();
        blackStyle.normal.textColor = Color.black;

        Handles.color = Color.black;
        Handles.Label(newPosition, name, blackStyle);

        newPosition += Vector3.up * OFFSET_DOWN_TEXT;
        Handles.DrawLine(newPosition, positionGizmo);
    }

    private void OnGUI()
    {
        Debug.Log(Selection.gameObjects);
        
    }
}