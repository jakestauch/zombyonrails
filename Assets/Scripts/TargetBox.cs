using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetBox : MonoBehaviour
{
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 center = rend.bounds.center;
        float radius = rend.bounds.extents.magnitude;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, radius);
    }

}
