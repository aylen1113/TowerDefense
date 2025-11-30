using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //public TMP_Text selectedTowerText;
    public Image selectedTowerIcon;

    public TextMeshProUGUI noMoneyText;
    public TextMeshProUGUI selectedTowerText;

    private void Start()
    {
      
        if (selectedTowerText != null) selectedTowerText.gameObject.SetActive(false);
        if (selectedTowerIcon != null) selectedTowerIcon.gameObject.SetActive(false);
        if (noMoneyText != null) noMoneyText.gameObject.SetActive(false);
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpdateSelectedTowerUI(TowerType tower)
    {
        //selectedTowerText.text = "Torre seleccionada: " + tower.towerName;

        if (tower.icon != null)
        {
            selectedTowerIcon.sprite = tower.icon;
            selectedTowerIcon.enabled = true;


            selectedTowerIcon.gameObject.SetActive(true);
            selectedTowerText.gameObject.SetActive(true);
        }
        else
        {
            selectedTowerIcon.enabled = false; 
        }
    }
    public void ShowNoMoneyMessage()
    {
        StopAllCoroutines();
        StartCoroutine(NoMoneyRoutine());
    }

    private IEnumerator NoMoneyRoutine()
    {
        noMoneyText.text = "Dinero insuficiente!!";
        noMoneyText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        noMoneyText.gameObject.SetActive(false);
    }
}

