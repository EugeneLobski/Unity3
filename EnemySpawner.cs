using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(WaypointMovement))]

public class EnemySpawner : MonoBehaviour {
    const float SpawnDelay = 2f;
    
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    
    private WaitForSeconds _timer = new WaitForSeconds(SpawnDelay);

    public void Start() {
        StartCoroutine(Spawn(_timer));
    }

    private IEnumerator Spawn (WaitForSeconds delay) {
        while (true) {
            foreach (Transform spawnPoint in _spawnPoints) {
                
                Enemy newEnemy = Instantiate(_prefab, spawnPoint.GetChild(0).position, Quaternion.identity);
                newEnemy.GetComponent<WaypointMovement>().Init(GetPoints(spawnPoint));
                yield return delay;
            }
            yield return null;
        }
    }

    private Transform[] GetPoints(Transform spawnPoint) {
        Transform[] wayPoints = new Transform[spawnPoint.childCount];

        for (int i = 0; i < spawnPoint.childCount; i++) {
            wayPoints[i] = spawnPoint.GetChild(i);
        }

        return wayPoints;
    }
}
