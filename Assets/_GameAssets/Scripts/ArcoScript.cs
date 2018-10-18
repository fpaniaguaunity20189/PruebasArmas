﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoScript : MonoBehaviour {
    [SerializeField] Transform genPoint;
    [SerializeField] GameObject prefabFlecha;
    [SerializeField] int force = 100;

    private void OnMouseDown() {
        GameObject proyectil = Instantiate(
            prefabFlecha,
            genPoint.transform.position,
            genPoint.transform.rotation);
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
    }
}
