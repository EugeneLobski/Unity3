using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class WaypointMovement : MonoBehaviour 
{
    [SerializeField] private float _speed;
    
    private Transform[] _wayPoints;
    private int _currentPoint = 0;

    public void Init (Transform[] wayPoints) {
        _wayPoints = wayPoints;
    }

    private void Update() {
        Transform target = _wayPoints[_currentPoint];
        var direction = (target.position - transform.position).normalized;
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        
        if (transform.position == target.position) {
            _currentPoint++;

            if (_currentPoint >= _wayPoints.Length) {
                _currentPoint = 0;
            }
        }
    }
}
