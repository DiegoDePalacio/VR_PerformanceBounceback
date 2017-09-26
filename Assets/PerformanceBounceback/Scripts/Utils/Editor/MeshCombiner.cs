using UnityEngine;
using System.Collections;
using UnityEditor;

[RequireComponent( typeof( MeshFilter ) )]
[RequireComponent( typeof( MeshRenderer ) )]
public class MeshCombiner : MonoBehaviour
{
    [MenuItem( "Utils/Combine children mesh", true )]
    private static bool IsGameObjectSelected()
    {
        return Selection.activeGameObject != null;
    }

    [MenuItem("Utils/Combine children mesh")]
    private static void MergeChildren()
    {
        GameObject target = Selection.activeGameObject;

        MeshRenderer targetRenderer = target.GetComponent<MeshRenderer>();
        if ( targetRenderer == null )
        {
            targetRenderer = target.AddComponent<MeshRenderer>();
        }

        MeshFilter targetMeshFilter = target.GetComponent<MeshFilter>();
        if ( targetMeshFilter == null )
        {
            targetMeshFilter = target.AddComponent<MeshFilter>();
        }

        MeshFilter[] meshFilters = target.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while ( i < meshFilters.Length )
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive( false );
            i++;
        }
        targetMeshFilter.mesh = new Mesh();
        targetMeshFilter.mesh.CombineMeshes( combine );
        target.SetActive( true );
    }
}