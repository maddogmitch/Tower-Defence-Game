using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTower : Tower
{
    //Projectile the tower will shoot
    public GameObject stonePrefab;
    //makes sure the parents base code is called
    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        //spawn a new projectile
        GameObject stone = (GameObject)Instantiate(stonePrefab,
            towerPieceToAim.position, Quaternion.identity);
        stone.GetComponent<Stone>().enemyToFollow = targetEnemy;
        stone.GetComponent<Stone>().damage = attackPower;
    }
}
