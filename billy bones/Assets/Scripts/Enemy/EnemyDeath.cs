using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject Enemy;
    public Transform PlaceHead;
    public Transform PlaceBody;
    public Transform PlaceLegs;
    public Transform PlaceArms;


    public GameObject EnemyHeadPrefab;
    public GameObject EnemyBodyPrefab;
    public GameObject EnemyLegsPrefab;
    public GameObject EnemyRightArmPrefab;
    public GameObject EnemyLeftArmPrefab;

    public bool dead = false;
    public int count = 0;

    void Update()
    {
        if(dead ==  true)
        {
            EnemyDie();
        }
    }

    public void EnemyDie()
    {
        if ( count == 0)
        {
            PlaceHead.gameObject.transform.parent = null;
            PlaceBody.gameObject.transform.parent = null;
            PlaceLegs.gameObject.transform.parent = null;
            PlaceArms.gameObject.transform.parent = null;
        
            Instantiate(EnemyHeadPrefab, PlaceHead);
            Instantiate(EnemyBodyPrefab, PlaceBody);
            Instantiate(EnemyLegsPrefab, PlaceLegs);
            Instantiate(EnemyRightArmPrefab, PlaceArms);
            Instantiate(EnemyLeftArmPrefab, PlaceArms);
            count += 1;
        }
        else
        {
            Destroy(Enemy);
        }
    }
}
