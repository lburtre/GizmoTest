using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GizmoManager))]
public class GizmoManagerEditor : Editor
{
    public static GizmoManagerEditor Instance { get; private set; }

    private void OnValidate()
    {
        if (Instance)
        {
            DestroyImmediate(this);
            return;
        }

        Instance = this;
    }

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
                    if(hit.collider == GizmoManager.Instance.listGizmoMonoBehavior[i].gizmoCollider)
                    {
                        GizmoEditorTool.Instance.gizmoSelected = i + 1;
                    }
                }
            }
        }

        if (Event.current.type == EventType.Layout)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}
