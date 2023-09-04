using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalsPrefabs;
    private float _leftBound = -20f;
    private float _rightBound = 20f;
    private float _spawnInterval = 1.5f;
    private float _startDelay = 2;
    


    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",_startDelay,_spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        _index = Random.Range(0, animalsPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(_leftBound, _rightBound), 0, 20);
        Instantiate(animalsPrefabs[_index], spawnPos, animalsPrefabs[_index].transform.rotation);
    }
}