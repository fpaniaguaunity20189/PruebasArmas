using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirachinasScript : MonoBehaviour {
    [SerializeField] Transform genPoint;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] int force=100;

    private void OnMouseDown() {
        GameObject proyectil = Instantiate(
            prefabProyectil,
            genPoint.transform.position,
            genPoint.transform.rotation);
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
    }

}
