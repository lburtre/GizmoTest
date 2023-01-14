using technical.test.editor;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SceneGizmoAsset))]
public class SceneGizmoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("ButtonTest"))
        {
            EditorWindow.CreateWindow<ShowGizmos>();
        }
    }

}
