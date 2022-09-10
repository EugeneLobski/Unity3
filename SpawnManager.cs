using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] const float _spawnDelay = 1f;

    private Spawner[] _spawners;
    private WaitForSeconds _timer = new WaitForSeconds(_spawnDelay);

    private void Awake() {
        _spawners = gameObject.GetComponentsInChildren<Spawner>();
        StartCoroutine(SpawnEnemy(_timer));
    }

    private IEnumerator SpawnEnemy(WaitForSeconds delay)
    {
        while (true) {
            foreach (Spawner spawner in _spawners) {
                spawner.CreateEnemy();
                yield return delay;
            }
            yield return null;
        }
    }
}
