using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _path;
   
    public void CreateEnemy() {
        Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
    }

    public Transform[] GetPoints() {
        Transform[] points = new Transform[_path.childCount];
        
        for (int i = 0; i < _path.childCount; i++) {
            points[i] = _path.GetChild(i);
        }

        return points;
    }
}
