using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public TowerType towerToBuild;

    private GameObject turretToBuild;


    public GameObject GetTurretToBuild () { return turretToBuild; }

    public GameObject standardTurretPrefab;



    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    //void Start()
    //{
    //    //turretToBuild = standardTurretPrefab;
    //}

    public void SelectTower(TowerType tower)
    {
        towerToBuild = tower;
    }

    public void BuildTowerOn(Nodes node)
    {
        if (towerToBuild == null) return;

        if (!GameManager.Instance.CanAfford(towerToBuild.cost))
        {
            Debug.Log("Not enough money!");
            return;
        }

        GameManager.Instance.SpendMoney(towerToBuild.cost);

        GameObject turretObj = Instantiate(towerToBuild.turretPrefab, node.transform.position, Quaternion.identity);
        Turret turret = turretObj.GetComponent<Turret>();
        turret.towerData = towerToBuild;

        node.currentTurret = turretObj;
    }
}