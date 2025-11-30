using UnityEngine;
using UnityEngine.UI;


public class TowerButton : MonoBehaviour
{
    public TowerType towerType;
    public Image iconUI;

    public void OnSelectTower()
    {
        BuildManager.Instance.SelectTower(towerType);
        Debug.Log("Torre seleccionada: " + towerType.name);
    }
}
