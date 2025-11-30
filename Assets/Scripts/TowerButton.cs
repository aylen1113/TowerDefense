using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TowerButton : MonoBehaviour
{
    public TowerType towerType;
    public Image iconUI;




    private void Start()
    {
        iconUI.sprite = towerType.icon;


    }
    public void OnSelectTower()
    {
        BuildManager.Instance.SelectTower(towerType);
        Debug.Log("Torre seleccionada: " + towerType.name);
    }
}
