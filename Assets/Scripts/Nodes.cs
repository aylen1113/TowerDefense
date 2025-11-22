using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{

    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    private GameObject turret;

    public bool isPath;

    public GameObject currentTurret;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (isPath) return;

        if (turret != null)
        {
            Debug.Log("cant build there");
            return;
        }
        // GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        //turret = Instantiate(turretToBuild, transform.position, transform.rotation);


        BuildManager.Instance.BuildTowerOn(this);

    }
    private void OnMouseEnter()
    {
       rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

