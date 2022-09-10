using UnityEngine;

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
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        
        if (transform.position == target.position) {
            _currentPoint++;

            if (_currentPoint >= _wayPoints.Length) {
                _currentPoint = 0;
            }
        }
    }
}
