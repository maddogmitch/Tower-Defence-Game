using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoWindow : MonoBehaviour
{
    //Reference to the tower that can be upgraded
    public Tower tower;
    // Text Components for the button
    public Text txtInfo;
    public Text txtUpgradeCost;
    //The tpwer upgrade cost
    private int upgradePrice;
    //Reference to the Upgrade button
    private GameObject btnUpgrade;

    void Awake()
    {
        btnUpgrade = txtUpgradeCost.transform.parent.gameObject;
    }

    void OnEnable()
    {
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        upgradePrice = Mathf.CeilToInt(TowerManager.Instance.GetTowerPrice(tower.type) * 1.5f * tower.towerLevel);
        txtInfo.text = tower.type + " Tower Lv " + tower.towerLevel;

        if (tower.towerLevel < 3)
        {
            btnUpgrade.SetActive(true);
            txtUpgradeCost.text = "Upgrade\n" + upgradePrice + " Gold";
        }
        else
        {
            btnUpgrade.SetActive(false);
        }
    }

    public void UpgradeTower()
    {
        if (GameManager.Instance.gold >= upgradePrice)
        {
            GameManager.Instance.gold -= upgradePrice; tower.LevelUp();
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
