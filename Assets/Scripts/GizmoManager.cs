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

        for (int i = 0; i < oldListGizmoMonoBehavior.Length; i++) //To recover the GizmoMonoBehaviour Scripts after modifications in script
        {
            listGizmoMonoBehavior.Add(oldListGizmoMonoBehavior[i]);
        }

        Tools.current = Tool.None;
    }

    public void ClearScriptsGizmoBehaviour()
    {
        for (int i = 0; i < listGizmoMonoBehavior.Count; i++)
        {
            listGizmoMonoBehavior[i].OnDestroyGizmo();
        }

        listGizmoMonoBehavior.Clear();
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

