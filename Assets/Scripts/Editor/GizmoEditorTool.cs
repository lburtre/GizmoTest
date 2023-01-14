using System.Collections.Generic;
using technical.test.editor;
using UnityEditor;
using UnityEngine;

public class ShowGizmos : EditorWindow
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

    [MenuItem("Window/Custom/Show Gizmos")] //Path to find the window
    public static void ShowGismosWindow()
    {
        EditorWindow.GetWindow<ShowGizmos>("Show Gizmos"); //Name of the window
    }

    private void OnGUI()
    {
        GUILayout.Label(TEXT_GIZMO_EDITOR, EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
            GUILayout.Label(TEXT_TEXT);
            GUILayout.Label(TEXT_POSITION);
        GUILayout.EndHorizontal();

        if(listGizmos != default)
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

        /*
        textText = EditorGUILayout.TextField("Testt2", textText);
        textPosition = EditorGUILayout.TextField("TText", textText);

        if (GUILayout.Button("TestButton"))
        {
            Debug.Log(22);
        }

        Selection.gameObjects => Return all the gameObjects selected in the scene
        */
    }

    public void UpdateGizmoList(Gizmo[] listNewGizmos)
    {
        listGizmos = listNewGizmos;
        OnGUI();
    }
}
