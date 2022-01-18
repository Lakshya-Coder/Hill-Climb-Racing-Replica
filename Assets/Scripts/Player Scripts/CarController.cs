using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public static CarController instance;

    [SerializeField] private Rigidbody2D leftTire;
    [SerializeField] private Rigidbody2D rightTire;
    [SerializeField] private Rigidbody2D car;
    [SerializeField] private float spped = 20f;
    
    private float movement;
    
    [SerializeField] private Slider fuelSlider;

    [SerializeField] private float maxFuel = 20;
    private float currentFuel;

    private void Start()
    {
        if (instance == null)
            instance = this;
        
        currentFuel = maxFuel;
        fuelSlider.maxValue = currentFuel;
        fuelSlider.minValue = 0f;
    }
    
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        currentFuel -= Time.deltaTime;
        fuelSlider.value = currentFuel;

        if (currentFuel <= 0f)
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        // Add torque to move the car
        rightTire.AddTorque(-movement * spped * Time.fixedDeltaTime);
        leftTire.AddTorque(-movement * spped * Time.fixedDeltaTime);
        
        car.AddTorque(movement * spped * Time.fixedDeltaTime);
    }

    public void OnGas()
    {
        rightTire.AddTorque(-1 * spped * Time.fixedDeltaTime);
        leftTire.AddTorque(-1 * spped * Time.fixedDeltaTime);
    }

    public void OnBrake()
    {
        rightTire.AddTorque(1 * spped * Time.fixedDeltaTime);
        leftTire.AddTorque(1 * spped * Time.fixedDeltaTime);
    }
    
    private void GameOver()
    {
        // Do something over here :)
        Debug.Log("GameOver");
    }

    public void OnFuelCollected()
    {
        currentFuel = maxFuel;
        fuelSlider.value = currentFuel;
    }
}
