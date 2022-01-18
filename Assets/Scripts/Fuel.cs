using UnityEngine;

public class Fuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Head") || col.CompareTag("Car Body"))
        {
            gameObject.SetActive(false);
            CarController.instance.OnFuelCollected();
        }
    }
}
