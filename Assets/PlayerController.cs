using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
   
   MovementController movementController;
   public Animator animator;
   public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Awake(){

        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        // Obtenemos el componente MovementController del objeto actual
        movementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update(){

        animator.SetBool("moving", true);
         // Verifica si se está presionando la tecla de dirección izquierda
        if (Input.GetKey(KeyCode.LeftArrow)){
            // Establece la dirección de movimiento del personaje a la izquierda
            movementController.SetDirection("left");
        }
        // Verifica si se está presionando la tecla de dirección derecha
        if (Input.GetKey(KeyCode.RightArrow)){
            // Establece la dirección de movimiento del personaje a la derecha
            movementController.SetDirection("right");
        }
        // Verifica si se está presionando la tecla de dirección arriba
        if (Input.GetKey(KeyCode.UpArrow)){
            // Establece la dirección de movimiento del personaje hacia arriba
            movementController.SetDirection("up");
        }
        // Verifica si se está presionando la tecla de dirección abajo
        if (Input.GetKey(KeyCode.DownArrow)){
            // Establece la dirección de movimiento del personaje hacia abajo
            movementController.SetDirection("down");
        }

        bool flipX = false;
        bool flipY = false;
        if (movementController.lastMovingDirection == "left"){
            animator.SetInteger("direction", 0);
        }else if (movementController.lastMovingDirection == "right"){
            animator.SetInteger("direction", 0);
            flipX = true;
        }else if (movementController.lastMovingDirection == "up"){
            animator.SetInteger("direction", 1);
        }else if (movementController.lastMovingDirection == "down"){
            animator.SetInteger("direction", 1);
            flipY = true;
        }

        sprite.flipY = flipY;
        sprite.flipX = flipX;

    }
}
