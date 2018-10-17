using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {
    [SerializeField] Transform target;
	void Update () {
        transform.LookAt(target);
	}
}
