using UnityEngine;

[CreateAssetMenu(fileName = "TowerType", menuName = "TD/Tower Type")]
public class TowerType : ScriptableObject
{
    public string towerName;
    public GameObject turretPrefab;
    public int cost;
    public float fireRate;
    public float range;
    public int damage;
    public float turnSpeed;
    public Sprite icon;
}
