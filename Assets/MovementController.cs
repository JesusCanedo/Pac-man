using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour{
   
   
   // El nodo actual en el que se encuentra el personaje
   public GameObject currentNode;
   // La velocidad del personaje
   public float speed = 4f;

   // La dirección en la que el personaje se está moviendo actualmente
   public string direction = "";

   // La última dirección en la que el personaje se movió
   public string lastMovingDirection = "";
   
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update(){

        // Obtenemos el controlador de nodo del nodo actual
        NodeController currentNodeController = currentNode.GetComponent<NodeController>();

        // Movemos al personaje hacia el nodo actual
        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);
   
        // Determinarmos si la dirección actual es opuesta a la dirección anterior
        bool reverseDirection = false;
        if (
            (direction == "left" && lastMovingDirection == "right") 
            || (direction == "right" && lastMovingDirection == "left")
            || (direction == "up" && lastMovingDirection == "down")
            || (direction == "down" && lastMovingDirection == "up")){
            reverseDirection = true;
         }

        // Determinamos si el personaje ha llegado al centro del nodo actual
        // Figure out if we're at the center of our current node 
        if ((transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y) || reverseDirection){
             // Obtenemos el siguiente nodo del controlador de nodo usando la dirección actual
            // Get the next node from our node controller using our current direction
            GameObject newNode = currentNodeController.GetNodeFromDirection(direction);
            
            // Si podemos mover en la dirección deseada
            // If we can move in the desired direction
            if (newNode != null){
                currentNode = newNode;
                lastMovingDirection = direction;

            // Si no podemos mover en la dirección deseada, intentamos seguir moviéndonos en la última dirección de movimiento
            // We can't move in desired direction, try to keep going in the last moving direction
            }else{
                direction = lastMovingDirection;
                newNode = currentNodeController.GetNodeFromDirection(direction);
                if (newNode != null){
                    currentNode = newNode;
                }
            }
        }
    }

    // Establecemos la dirección de movimiento del personaje
    public void SetDirection(string newDirection){
        direction = newDirection;

    }
}
