using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDeleter : MonoBehaviour{
    /*
    Esta clase se usa para eliminar los demas node ademas de coloar colliders
    */
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    // Función que se llama cuando el objeto entra en contacto con un collider
    private void OnTriggerEnter2D(Collider2D collision) {
        // Si el objeto que entra en contacto tiene el tag "Node", se destruye
        if (collision.tag == "Node"){
            Destroy(collision.gameObject);
        }
    }
}
