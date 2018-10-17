using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaScript : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    
}
