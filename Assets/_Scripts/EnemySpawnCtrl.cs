using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCtrl : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject effectSpawn;
    [SerializeField] PlayerCtrl player;
    [SerializeField] float timeSpawn;
    [SerializeField] LevelScore levelScore;
    private float timeEffect = 0.5f;
    private float _timeSpawn;
    [SerializeField] float numSpawn;
    float _numSpawn;
    void Start()
    {

    }

    void Update()
    {
        if(!DataManager.canAttackPlayer) return;
       if(_timeSpawn <= 0)
       {
            if (_numSpawn >= 1)
            {
                StartCoroutine(Spawn());
                _numSpawn--;
            }
            else
            {
                _timeSpawn = timeSpawn;
                if(DataManager.statusDayNight == "day") numSpawn = levelScore.levelCurrentByScore;
                else if(DataManager.statusDayNight =="night") numSpawn = 1.5f*levelScore.levelCurrentByScore;
                _numSpawn = numSpawn;
            }
                
       }    
        _timeSpawn -= Time.deltaTime;
    }
    private IEnumerator Spawn()
    {
            Vector3 spawnPos = new Vector3(Random.Range(player.transform.position.x - 100, player.transform.position.x + 100),
                        Random.Range(player.transform.position.y - 100, player.transform.position.y + 100), player.transform.position.z);
            GameObject Effect = Instantiate(effectSpawn, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(timeEffect);
            GameObject Enemy1 = Instantiate(enemy1, spawnPos, Quaternion.identity);
    }
}
