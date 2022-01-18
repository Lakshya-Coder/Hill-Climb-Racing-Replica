using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarControllerByMouse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite defaultSprite;
    public Sprite pressedSprite;

    public Image image;

    private bool isPressed;

    public bool isRotateOnPressed;
    
    public UnityEvent unityEvent;

    private void Update()
    {
        if (isPressed)
        {
            unityEvent.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        image.sprite = pressedSprite;

        if (isRotateOnPressed)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        else 
            transform.rotation = Quaternion.Euler(0, 0, 0);

        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.sprite = defaultSprite;
        
        transform.rotation = Quaternion.Euler(0, 0, 0);
        
        isPressed = false;
    }
} // class
