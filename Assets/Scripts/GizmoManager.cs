using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoManager : MonoBehaviour
{
    private static GameObject gameObjectGizmo;
    public static List<GizmoMonoBehaviour> listGizmoMonoBehavior = new List<GizmoMonoBehaviour>();

    private void OnValidate()
    {
        gameObjectGizmo = gameObject;

        GizmoMonoBehaviour[] oldListGizmoMonoBehavior = gameObjectGizmo.GetComponents<GizmoMonoBehaviour>();

        for (int i = 0; i < oldListGizmoMonoBehavior.Length; i++) //To recover the GizmoMonoBehaviour Scripts after modifications in script
        {
            listGizmoMonoBehavior.Add(oldListGizmoMonoBehavior[i]);
        } 
    }

    public static void ClearScriptsGizmoBehaviour()
    {
        for (int i = 0; i < listGizmoMonoBehavior.Count; i++)
        {
            listGizmoMonoBehavior[i].OnDestroy();
        }

        listGizmoMonoBehavior.Clear();
    }

    public static void CreateNewGizmo(Vector3 positionGizmo, string name)
    {
        GizmoMonoBehaviour gizmo = gameObjectGizmo.AddComponent<GizmoMonoBehaviour>();
        gizmo.positionGizmo = positionGizmo;
        gizmo.name = name;
        listGizmoMonoBehavior.Add(gizmo);

        SphereCollider collider = gameObjectGizmo.AddComponent<SphereCollider>();
        collider.center = positionGizmo;
        collider.radius = gizmo.ReturnRadius() * 2;
        gizmo.sphereCollider = collider;
    }

    private void OnGUI()
    {
        Ray ray = Camera.current.ScreenPointToRay(Event.current.mousePosition);
        RaycastHit hit = new RaycastHit();

        Debug.Log(Event.current.mousePosition);
        Debug.Log(Camera.current);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit);
        }
    }
}
