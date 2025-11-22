using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        UpdateMoney(GameManager.Instance.money);

        GameManager.Instance.onMoneyChanged += UpdateMoney;
    }

    private void UpdateMoney(int newAmount)
    {
        moneyText.text = "$" + newAmount.ToString();
    }
}
