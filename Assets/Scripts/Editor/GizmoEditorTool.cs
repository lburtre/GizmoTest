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

    private Gizmo[] listGizmos = default;

    public int gizmoSelected = 0; //None gizmo selected if this value is at 0

    [MenuItem("Window/Custom/Show Gizmos")]
    public static void ShowGismosWindow()
    {
        EditorWindow.GetWindow<GizmoEditorTool>("Show Gizmos");
    }

    public static GizmoEditorTool Instance { get; private set; }

    private void OnValidate()
    {
        if (Instance)
        {
            DestroyImmediate(this);
            return;
        }

        Instance = this;
    }

    private void OnGUI()
    {
        GUILayout.Label(TEXT_GIZMO_EDITOR, EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        GUILayout.Label(TEXT_TEXT);
        GUILayout.Label(TEXT_POSITION);
        GUILayout.EndHorizontal();

        if (listGizmos != default)
        {
            for (int i = 0; i < listGizmos.Length; i++)
            {
                GUILayout.BeginHorizontal();
                name = GUILayout.TextField(listGizmos[i].Name, GUILayout.Width(SIZE_TEXTFIELD));
                GUILayout.Label(TEXT_X);
                EditorGUILayout.TextField(listGizmos[i].Position.x.ToString(), GUILayout.Width(SIZE_TEXTFIELD));
                GUILayout.Label(TEXT_Y);
                EditorGUILayout.TextField(listGizmos[i].Position.y.ToString(), GUILayout.Width(SIZE_TEXTFIELD));
                GUILayout.Label(TEXT_Z);
                EditorGUILayout.TextField(listGizmos[i].Position.z.ToString(), GUILayout.Width(SIZE_TEXTFIELD));
                GUILayout.Button(TEXT_EDIT);
                GUILayout.EndHorizontal();
            }
        }
    }

    public void UpdateGizmoList(Gizmo[] listNewGizmos)
    {
        listGizmos = listNewGizmos;

        GizmoManager.Instance.ClearScriptsGizmoBehaviour();

        for (int i = 0; i < listGizmos.Length; i++)
        {
            GizmoManager.Instance.CreateNewGizmo(listGizmos[i].Position, listGizmos[i].Name);
        }

        OnGUI();
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}
