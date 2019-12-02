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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
