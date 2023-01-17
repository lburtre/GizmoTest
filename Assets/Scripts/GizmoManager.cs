using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GizmoManager : MonoBehaviour
{
    private GameObject gizmoManagerGameObject;
    public List<GizmoMonoBehaviour> listGizmoMonoBehavior = new List<GizmoMonoBehaviour>();

    public static GizmoManager Instance { get; private set; }

    private void OnValidate()
    {
        if (Instance)
        {
            DestroyImmediate(this);
            return;
        }

        Instance = this;

        gizmoManagerGameObject = gameObject;

        GizmoMonoBehaviour[] oldListGizmoMonoBehavior = gizmoManagerGameObject.GetComponents<GizmoMonoBehaviour>();

        UnityEditor.EditorApplication.delayCall += () =>
        {
            for (int i = 0; i < oldListGizmoMonoBehavior.Length; i++)
            {
                oldListGizmoMonoBehavior[i].OnDestroyGizmo(); 
            }
        };

        Tools.current = Tool.None;
    }

    public void ClearGizmoAndCollider()
    {
        for (int i = listGizmoMonoBehavior.Count - 1; i >= 0; i--)
        {
            listGizmoMonoBehavior[i].OnDestroyGizmo();
        }
    }

    public void CreateNewGizmo(Vector3 positionGizmo, string name)
    {
        GizmoMonoBehaviour gizmo = gizmoManagerGameObject.AddComponent<GizmoMonoBehaviour>();
        gizmo.gizmoPosition = positionGizmo;
        gizmo.gizmoName = name;
        listGizmoMonoBehavior.Add(gizmo);

        SphereCollider collider = gizmoManagerGameObject.AddComponent<SphereCollider>();
        collider.center = positionGizmo;
        collider.radius = gizmo.ReturnRadius();
        gizmo.gizmoCollider = collider;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}

