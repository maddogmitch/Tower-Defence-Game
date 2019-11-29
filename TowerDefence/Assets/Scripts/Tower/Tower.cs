using UnityEngine;
using System.Collections.Generic;

public enum TowerType
{
    Stone, Fire, Ice
}

public class Tower : MonoBehaviour
{
    //Damage it can do
    public float attackPower = 3f;
    //Cooldown between shots
    public float timeBetweenAttacksInSeconds = 1f;
    //minimum distance
    public float aggroRadius = 15f;
    //level of the tower
    public int towerLevel = 1;
    //type of tower
    public TowerType type;
    //sound effect
    public AudioClip shootSound;
    //aiming at enemies head
    public Transform towerPieceToAim;
    //targeting the enemy
    public Enemy targetEnemy = null;
    //counter to allow the tower to shoot
    public float attackCounter;

    private void SmoothlyLookAtTarget(Vector3 target)
    {
        towerPieceToAim.localRotation = AutoScaler.
            SmoothlyLook(towerPieceToAim, target);
    }

    protected virtual void AttackEnemy()
    {
        GetComponent<AudioSource>().PlayOneShot(shootSound, .15f);
    }

    //Gets a list of all enemies
    public List<Enemy> GetEnemiesInAggroRange()
    {
        List<Enemy> enemiesInRange = new List<Enemy>();
        //Iterate through all anemies and adds them to the inRange list
        foreach(Enemy enemy in EnemyManager.Instance.Enemies)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) 
                <= aggroRadius)
            {
                enemiesInRange.Add(enemy);
            }
        }
        //returns the list
        return enemiesInRange;
    }

    //Returns the enemy closest to the tower
    public Enemy GetNearestEnemyInRange()
    {
        Enemy nearestEnemy = null;
        float smallestDistance = float.PositiveInfinity;
        //Iterates through all enemies within range and keeps them stored
        foreach(Enemy enemy in GetEnemiesInAggroRange())
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) <
                smallestDistance)
            {
                smallestDistance = Vector3.Distance(transform.position,
                    enemy.transform.position);
                nearestEnemy = enemy;
            }
        }
        //returns the nearest enemy
        return nearestEnemy;
    }

    public virtual void Update()
    {
        attackCounter -= Time.deltaTime;
        //Check if there is an enemy targeted
        if(targetEnemy == null)
        {
            //if there is a transform to rotate
            if(towerPieceToAim)
            {
                SmoothlyLookAtTarget(towerPieceToAim.transform.position - new Vector3(0, 0, 1));
            }
            //attempt to find a new target
            if(GetNearestEnemyInRange() != null
                && Vector3.Distance(transform.position,
                GetNearestEnemyInRange().transform.position)
                <= aggroRadius)
            {
                targetEnemy = GetNearestEnemyInRange();
            }
        }
        else
        {//check if there a target enemy assigned
            //look at target enemy
            if(towerPieceToAim)
            {
                SmoothlyLookAtTarget(targetEnemy.transform.position);
            }
            //if the counter is equal or below zero to to call the attack command
            if(attackCounter <= 0f)
            {
                //Attack
                AttackEnemy();
                // Reset attack counter
                attackCounter = timeBetweenAttacksInSeconds;
            }
            //if the target moves out of range
            if(Vector3.Distance(transform.position, 
                targetEnemy.transform.position) > aggroRadius)
            {
                targetEnemy = null;
            }


        }
    }

    public void LevelUp()
    {
        towerLevel++;

        attackPower *= 2;
        timeBetweenAttacksInSeconds *= 0.7f;
        aggroRadius *= 1.20f;
    }
}
