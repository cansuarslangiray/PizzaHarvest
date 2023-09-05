using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalsPrefabs;
    private float _leftBound = -20f;
    private float _rightBound = 20f;
    private float _spawnInterval = 3f;
    private float _startDelay = 2;
    private float _topBound = 15f;
    private float _downBound = 0;
    public static float Score=0;



    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", _startDelay, _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score " + Score);
    }

    void SpawnRandomAnimal()
    {
        _index = Random.Range(0, animalsPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(_leftBound, _rightBound), 0, 20);
        Instantiate(animalsPrefabs[_index], spawnPos, Quaternion.Euler(0, 180, 0));
        int indexTwo = Random.Range(0, animalsPrefabs.Length);
        Vector3 spawnHor = new Vector3(20, 0, Random.Range(_downBound, _topBound));
        Instantiate(animalsPrefabs[indexTwo], spawnHor, Quaternion.Euler(0, 270, 0));
        int indexThree = Random.Range(0, animalsPrefabs.Length);
        Vector3 spawnHorTwo = new Vector3(-20, 0, Random.Range(_downBound, _topBound));
        Instantiate(animalsPrefabs[indexThree], spawnHorTwo, Quaternion.Euler(0, 90, 0));
    }
}