using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private int _coin = 0;

    private void OnTriggerEnter2D (Collider2D other) {
                
        if (other.TryGetComponent(out Coin coin)) {
            _coin++;
            Destroy(other.gameObject);
        }
    }
}
