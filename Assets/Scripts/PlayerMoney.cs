using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    private int money;

    [SerializeField] StackEnemies stackEnemies;
    [SerializeField] PlayerColor playerColor;
    [SerializeField] Text textMoneyUI;

    private int level = 0;

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }

    public void BuyUpgrade(int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            UpdateUI() ;
            stackEnemies.IncreseStackLimit(3);
            playerColor.UpgradeColor(level);
            level++;
        }
    }

    private void UpdateUI()
    {
        textMoneyUI.GetComponent<Text>().text = money.ToString();
    }
}
