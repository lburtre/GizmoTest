using System.Collections.Generic;
using technical.test.editor;
using UnityEditor;
using UnityEngine;

public class GizmoEditorTool : EditorWindow
{
    private const string TEXT_TEXT = "Text";
    private const string TEXT_GIZMO_EDITOR = "Gizmo Editor";
    private const string TEXT_POSITION = "Position";
    private const string TEXT_EDIT = "Edit";

    private const string TEXT_X = "x";
    private const string TEXT_Y = "y";
    private const string TEXT_Z = "z";

    private const float SIZE_TEXTFIELD = 100;
    private Color initialGUIColor;

    private static Gizmo[] listGizmos = default;

    public static int gizmoSelected = 0; //None gizmo selected if this value is at 0

    [MenuItem("Window/Custom/Show Gizmos")]
    public static void ShowGismosWindow()
    {
        EditorWindow.GetWindow<GizmoEditorTool>("Show Gizmos");
    }

    private void OnGUI()
    {
        initialGUIColor = GUI.color;

        GUILayout.Label(TEXT_GIZMO_EDITOR, EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label(TEXT_TEXT);
        GUILayout.Label(TEXT_POSITION);
        GUILayout.EndHorizontal();

        if (listGizmos != default)
        {
            for (int i = 0; i < listGizmos.Length; i++)
            {
                if (gizmoSelected == i + 1)
                {
                    GUI.color = Color.red;
                    
                    GUILayout.BeginHorizontal();
                    listGizmos[i].Name = GUILayout.TextField(listGizmos[i].Name, GUILayout.Width(SIZE_TEXTFIELD));
                    
                    GUILayout.Label(TEXT_X);
                    listGizmos[i].Position.x = EditorGUILayout.FloatField(listGizmos[i].Position.x, GUILayout.Width(SIZE_TEXTFIELD));
                    GUILayout.Label(TEXT_Y);
                    listGizmos[i].Position.y = EditorGUILayout.FloatField(listGizmos[i].Position.y, GUILayout.Width(SIZE_TEXTFIELD));
                    GUILayout.Label(TEXT_Z);
                    listGizmos[i].Position.z = EditorGUILayout.FloatField(listGizmos[i].Position.z, GUILayout.Width(SIZE_TEXTFIELD));
                    
                    if (GUILayout.Button(TEXT_EDIT))
                    {
                        UpdateGizmo();
                    }

                    GUILayout.EndHorizontal();

                    GUI.color = initialGUIColor;
                }
                else
                {
                    GUILayout.BeginHorizontal();

                    GUILayout.TextField(listGizmos[i].Name, GUILayout.Width(SIZE_TEXTFIELD));
                    GUILayout.Label(TEXT_X);
                    EditorGUILayout.FloatField(listGizmos[i].Position.x, GUILayout.Width(SIZE_TEXTFIELD));
                    GUILayout.Label(TEXT_Y);
                    EditorGUILayout.FloatField(listGizmos[i].Position.y, GUILayout.Width(SIZE_TEXTFIELD));
                    GUILayout.Label(TEXT_Z);
                    EditorGUILayout.FloatField(listGizmos[i].Position.z, GUILayout.Width(SIZE_TEXTFIELD));
                    
                    if (GUILayout.Button(TEXT_EDIT))
                    {
                        gizmoSelected = i + 1;
                    }

                    GUILayout.EndHorizontal();
                }
            }
        }
    }

    private void UpdateGizmo()
    {
        GizmoManager.Instance.ClearGizmoAndCollider();

        for (int i = 0; i < listGizmos.Length; i++)
        {
            GizmoManager.Instance.CreateNewGizmo(listGizmos[i].Position, listGizmos[i].Name);
        }
    }

    public static void UpdateGizmoList(Gizmo[] listNewGizmos)
    {
        listGizmos = listNewGizmos;

        GizmoManager.Instance.ClearGizmoAndCollider();

        for (int i = 0; i < listGizmos.Length; i++)
        {
            GizmoManager.Instance.CreateNewGizmo(listGizmos[i].Position, listGizmos[i].Name);
        }
    }
}
