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
        //OverlapSphere "normal"
        //Collider[] cosas = Physics.OverlapSphere(transform.position, radioExplosion);
        //OverlapSphere "por capa"
        int layerMask = 1 << LayerMask.NameToLayer("Explotables");
        Collider[] cajas = Physics.OverlapSphere(transform.position, radioExplosion, layerMask);
        foreach (var caja in cajas) {
            //if (cosa.gameObject.CompareTag("Explosionables")) {
                caja.gameObject.GetComponent<Rigidbody>().AddExplosionForce(
                    fuerzaExplosion,
                    this.transform.position,
                    radioExplosion,
                    alturaExplosion
                    );
            //}
        }
    }
}
