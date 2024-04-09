using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    Outline outline;

    void Start()
    {
        outline = GetComponent<Outline>();
    }


    void Update()
    {

    }

    public void Select()
    {
        outline.OutlineWidth = 5;
        outline.OutlineColor = Color.yellow;
    }

    public void Deselect()
    {
        outline.OutlineWidth = 0;
        //outline.OutlineColor = Color.yellow;
    }
}
