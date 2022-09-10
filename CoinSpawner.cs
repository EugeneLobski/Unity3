using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    const float SpawnInterval = 1f;
    
    [SerializeField] private Coin _prefab;

    private Transform[] _spawnPoints;
    private WaitForSeconds _spawnDelay = new WaitForSeconds(SpawnInterval);

    private void Awake () {
        _spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(Spawn(_spawnDelay));
    }

    private IEnumerator Spawn(WaitForSeconds delay) {
        while (true) {
            Coin newCoin = Instantiate(_prefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            yield return delay;
        }
    }
}
