using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeBase : HyDBehaviour
{
    [SerializeField] protected Color hoverColor;
    [SerializeField] protected Renderer rend;
    [SerializeField] protected Color startColor;

    protected override void Start()
    {
        base.Start();
        this.rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (BuildManager.Instance.GetTurretToBuild() == null) return;
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
