using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GizmoManager))]
public class GizmoManagerEditor : Editor
{
    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < GizmoManager.Instance.listGizmoMonoBehavior.Count; i++)
                {
                    if (hit.collider == GizmoManager.Instance.listGizmoMonoBehavior[i].gizmoCollider)
                    {
                        GizmoEditorTool.gizmoSelected = i + 1;
                    }
                }
            }
        }

        if (Event.current.type == EventType.Layout)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
        }
    }
}
