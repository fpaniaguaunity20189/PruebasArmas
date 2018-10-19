using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrancotiradorScript : MonoBehaviour {
    [SerializeField] Transform puntoDisparo;
    [SerializeField] Camera miCamara;
    [SerializeField] GameObject mirilla;
    bool apuntando = false;
    float currentFOV;
    float minFOV = 25;
    float maxFOV; 

    private void Start() {
        maxFOV = miCamara.fieldOfView;
        currentFOV = miCamara.fieldOfView;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            apuntando = true;
        }
        if (Input.GetMouseButtonUp(1)) {
            apuntando = false;
            currentFOV = maxFOV;
            mirilla.SetActive(false);
        }
        if (apuntando == true) {
            currentFOV = currentFOV - 1;
            currentFOV = Mathf.Max(currentFOV, minFOV);
            if (currentFOV == minFOV) {
                mirilla.SetActive(true);
            }
        }
        miCamara.fieldOfView = currentFOV;
    }


    private void OnMouseDown() {
        Vector3 forward = puntoDisparo.forward;
        //Rayo de disparo
        Ray rayo = new Ray(puntoDisparo.position, forward);
        //Declaramos el objeto que recoge el impacto
        RaycastHit hitInfo;
        //Depuramos el rayo
        //Debug.DrawRay(puntoDisparo.position, puntoDisparo.forward, Color.red, 5);
        //Lanzamos el rayo
        bool impactoConseguido = Physics.Raycast(rayo, out hitInfo, 25);
        //Evaluamos el impacto
        if (impactoConseguido == true) {
            print(hitInfo.collider.gameObject.name);
            Debug.DrawLine(
                puntoDisparo.position,
                hitInfo.collider.transform.position, 
                Color.red, 
                5);
            if (hitInfo.collider.gameObject.name == "ElCilindro") {
                Destroy(hitInfo.collider.gameObject);
            }
        } else {
            print("AGUA");
        }
    }
}
