using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TECH_GetTriangle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<MeshFilter>().mesh.triangles.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
