using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Color hoverColor;
    public GameObject turret;
    private Renderer rend;
    private Color startColor;
    public Vector3 positionOffset;
    BuiltManager builtManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color; 

        builtManager = BuiltManager.instance;
    }
    public Vector3 GetBuiltPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        if(!builtManager.CanBuild)
            return;
        if(turret != null)
        {
           print("MESTO ZANATO!"); 
           return;
        }

        builtManager.BuiltTurretOn(this);
    }
    void OnMouseEnter()
    {
        if(!builtManager.CanBuild)
            return;
        rend.material.color = hoverColor;    
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
