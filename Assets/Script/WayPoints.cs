using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Color cor = Color.red;

    [SerializeField]
    protected float debugDrawRadius = 1f;
    public virtual void OnDrawGizmos()
    {
        Gizmos.color = cor;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
}
