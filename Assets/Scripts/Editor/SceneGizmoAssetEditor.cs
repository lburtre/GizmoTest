using technical.test.editor;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SceneGizmoAsset))]
public class SceneGizmoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Show Gizmos"))
        {
            GizmoEditorTool window = EditorWindow.CreateWindow<GizmoEditorTool>();
            SceneGizmoAsset currentGizmoAsset = (SceneGizmoAsset)target;
            window.UpdateGizmoList(currentGizmoAsset.Gizmos);
        }

        //we can use target to made modification of the object whose being inspected
    }

}
