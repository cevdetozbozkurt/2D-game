using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;

    private GameObject spawnedMonster;
    
    [SerializeField] private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                //if randomSide == 0 ise monster ı leftPosa taşı
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 20);
            }
            else
            {
                //if randomSide == 1 ise Monster ı rightPosa tasi
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 20);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }//while Loop
    }
} //class
