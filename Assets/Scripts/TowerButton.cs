using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public TowerType towerType;

    public void OnSelectTower()
    {
        BuildManager.Instance.SelectTower(towerType);
        Debug.Log("Torre seleccionada: " + towerType.name);
    }
}
