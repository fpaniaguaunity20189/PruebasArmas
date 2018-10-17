using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaScript : MonoBehaviour {
    [SerializeField] int tiempoParaExplosion = 3;
    [SerializeField] int radioExplosion = 3;
    [SerializeField] int fuerzaExplosion = 100;
    [SerializeField] int alturaExplosion = 3;
	void Start () {
        Invoke("Explotar", tiempoParaExplosion);
	}
	
	private void Explotar() {
        Collider[] cosas = Physics.OverlapSphere(transform.position, radioExplosion);
        foreach (var cosa in cosas) {
            if (cosa.gameObject.CompareTag("Explosionables")) {
                cosa.gameObject.GetComponent<Rigidbody>().AddExplosionForce(
                    fuerzaExplosion,
                    this.transform.position,
                    radioExplosion,
                    alturaExplosion
                    );
            }
        }
    }
}
