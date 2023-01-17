using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GizmoMonoBehaviour : MonoBehaviour
{
    private const float GIZMO_RADIUS = 0.2f;
    private const float GIZMO_NAME_TEXT_HEIGHT = 0.6f;
    private const float GIZMO_OFFSET_DOWN_NAME_TEXT = -0.1f;

    public SphereCollider gizmoCollider = default;
    public Vector3 gizmoPosition;
    public string gizmoName = "";

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(gizmoPosition, GIZMO_RADIUS);

        Vector3 newPosition = gizmoPosition + Vector3.up * GIZMO_NAME_TEXT_HEIGHT;

        GUIStyle blackStyle = new GUIStyle();
        blackStyle.normal.textColor = Color.black;

        Handles.color = Color.black;
        Handles.Label(newPosition, gizmoName, blackStyle);

        newPosition += Vector3.up * GIZMO_OFFSET_DOWN_NAME_TEXT;
        Handles.DrawLine(newPosition, gizmoPosition);
    }

    public float ReturnRadius()
    {
        return GIZMO_RADIUS;
    }

    public void DestroyCollider()
    {
        DestroyImmediate(gizmoCollider);
    }

    public void OnDestroyGizmo()
    {
        GizmoManager.Instance.listGizmoMonoBehavior.Remove(this);
        DestroyImmediate(gizmoCollider);
        DestroyImmediate(this); 
    }
}
