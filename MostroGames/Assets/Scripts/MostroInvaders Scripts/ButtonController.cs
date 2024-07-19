using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public void OnPointerDown(PointerEventData eventData) {
        if (gameObject.name == "Right") {
            PlayerController.isMovingRight = true;
        } else if (gameObject.name == "Left") {
            PlayerController.isMovingLeft = true;
        } else if(gameObject.name == "Up") {
            PlayerController.isFiring = true;
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
