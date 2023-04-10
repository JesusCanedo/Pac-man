using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour{
    
    // Declaramos variables públicas para indicar si se puede mover en cada dirección
    public bool canMoveLeft = false;
    public bool canMoveRight = false;
    public bool canMoveUp = false;
    public bool canMoveDown = false;

    // Declaramos variables públicas para guardar los nodos de cada dirección
    public GameObject nodeLeft;
    public GameObject nodeRight;
    public GameObject nodeUp;
    public GameObject nodeDown;
    
    public bool isWarpRightNode = false;
    public bool isWarpLeftNode = false;

    /*RaycastHit2D es una estructura en Unity 
    que representa un resultado de un rayo lanzado en un plano 2D. 
    Esta estructura almacena información sobre el objeto golpeado por el rayo, 
    como su posición, la normal de la superficie en el punto de impacto y la distancia 
    desde el origen del rayo hasta el punto de impacto.

    Es útil para realizar detecciones de colisión precisas
    en juegos 2D, ya que permite detectar colisiones en un plano 2D 
    sin tener que considerar la profundidad como en un juego 3D. Por ejemplo,
    se puede usar RaycastHit2D para detectar colisiones con plataformas, obstáculos 
    y otros objetos en un juego de plataformas 2D.
    */




    // Start is called before the first frame update
    void Awake(){
     // Disparamos un raycast hacia abajo para detectar si hay un nodo en esa dirección
        RaycastHit2D[] hitsDown;
        // Shot raycast(line) going down
        // Raycast hacia abajo
        hitsDown = Physics2D.RaycastAll(transform.position, -Vector2.up);
        // Loop a través de cada objeto que golpeó el raycast
        // Loop through all of the gameObjects that the raycast hits
        for (int i = 0; i < hitsDown.Length; i++){
         // Calculamos la distancia entre el punto de impacto del raycast y la posición actual del objeto
            float distance = Mathf.Abs(hitsDown[i].point.y - transform.position.y);
         // Si la distancia es menor a 0.4f, significa que el objeto está lo suficientemente cerca para ser considerado un nodo
            if (distance < 0.4f){
         // Indicamos que se puede mover hacia abajo y guardamos el objeto que golpeó el raycast como nodoDown
                canMoveDown = true;
                nodeDown = hitsDown[i].collider.gameObject;
            }
        }

         // Repetimos el proceso anterior para las otras tres direcciones
        RaycastHit2D[] hitsUp;
        // Shot raycast(line) going up
        // Raycast hacia arriba
        hitsUp = Physics2D.RaycastAll(transform.position, Vector2.up);

        // Loop through all of the gameObjects that the raycast hits
        for (int i = 0; i < hitsUp.Length; i++){
            float distance = Mathf.Abs(hitsUp[i].point.y - transform.position.y);
            if (distance < 0.4f){
                canMoveUp = true;
                nodeUp = hitsUp[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsRight;
        // Shot raycast(line) going right
        // Raycast hacia la derecha
        hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right);

        // Loop through all of the gameObjects that the raycast hits
        for (int i = 0; i < hitsRight.Length; i++){
            float distance = Mathf.Abs(hitsRight[i].point.x - transform.position.x);
            if (distance < 0.4f){
                canMoveRight = true;
                nodeRight = hitsRight[i].collider.gameObject;
            }
        }

        
        RaycastHit2D[] hitsLeft;
        // Shot raycast(line) going right
        // Raycast hacia la izquierda
        hitsLeft = Physics2D.RaycastAll(transform.position, -Vector2.right);

        // Loop through all of the gameObjects that the raycast hits
        for (int i = 0; i < hitsLeft.Length; i++){
            float distance = Mathf.Abs(hitsLeft[i].point.x - transform.position.x);
            if (distance < 0.4f){
                canMoveLeft = true;
                nodeLeft = hitsLeft[i].collider.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update(){
     // No hacemos nada en Update, ya que toda la lógica de movimiento se maneja en el script del jugador
    }

  // Función que devuelve el nodo correspondiente a la dirección indicada
    public GameObject GetNodeFromDirection(string direction){
        // Verifica la dirección y si el objeto puede moverse en esa dirección
        if (direction == "left" && canMoveLeft){
            // Retorna el objeto correspondiente a la dirección izquierda
            return nodeLeft;
        }else if (direction == "right" && canMoveRight) {
            // Retorna el objeto correspondiente a la dirección derecha
            return nodeRight;
        }else if (direction == "up" && canMoveUp){
            // Retorna el objeto correspondiente a la dirección hacia arriba
            return nodeUp;
        }else if (direction == "down" && canMoveDown){
            // Retorna el objeto correspondiente a la dirección hacia abajo
            return nodeDown;
        }else {
            // Si no puede moverse en esa dirección, retorna nulo
            return null;
        }
    }

}
