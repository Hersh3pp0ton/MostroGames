using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public void OnPointerDown(PointerEventData eventData) {
        if (gameObject.name == "Right") {
            PlayerController.isMovingRight = true;
            Debug.Log("Right!");
        } else if (gameObject.name == "Left") {
            PlayerController.isMovingLeft = true;
            Debug.Log("Left");
        } else if(gameObject.name == "Up") {
            PlayerController.isFiring = true;
            Debug.Log("Up!");
        } 
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (gameObject.name == "Right") {
            PlayerController.isMovingRight = false;
        }
        else if (gameObject.name == "Left") {
            PlayerController.isMovingLeft = false;
        }
        else if (gameObject.name == "Up") {
            PlayerController.isFiring = false;
        }
    }
}
