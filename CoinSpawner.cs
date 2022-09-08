using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    
    const float _spawnInterval = 1f;

    private Transform[] _spawnPoints;
    private WaitForSeconds _spawnDelay = new WaitForSeconds(_spawnInterval);

    private void Awake () {
        _spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnCoin(_spawnDelay));
    }

    private IEnumerator SpawnCoin(WaitForSeconds delay) {
        while (true) {
            Coin newCoin = Instantiate(_coinPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            yield return delay;
        }
    }
}
