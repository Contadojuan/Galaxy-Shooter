using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyShip;
    [SerializeField]
    private GameObject[] _powerUps;
    private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void startMyGame()
    {  
        if (_gameManager != null)
        {
            StartCoroutine(spawnEnemy());
            StartCoroutine(spawnPowerUp());
        }
    }
    IEnumerator spawnEnemy()
    {
        while (_gameManager.gameOver == false)
        {
            Instantiate(_enemyShip, new Vector3(Random.Range(-8.05f, 8.05f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator spawnPowerUp()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(_powerUps[randomPowerUp], new Vector3(Random.Range(-7.05f, 7.05f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(8.0f);
        }
    }
}
