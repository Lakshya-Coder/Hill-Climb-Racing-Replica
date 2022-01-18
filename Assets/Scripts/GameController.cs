using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Rigidbody2D carRigidbody2D;
    public bool isGameRunning;

    public GameObject _3Text;
    public GameObject _2Text;
    public GameObject _1Text;
    public GameObject timerTextGo;
    
    public Text timerText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        isGameRunning = false;
        StartCoroutine(WaitForThreeSeconds());
    }

    private IEnumerator WaitForThreeSeconds()
    {
        timerTextGo.SetActive(true);
        carRigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        SetTimerText(3);

        yield return new WaitForSeconds(1f);
        SetTimerText(2);

        yield return new WaitForSeconds(1f);
        SetTimerText(1);
        
        yield return new WaitForSeconds(0.5f);
        
        isGameRunning = true;
        carRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        
        timerTextGo.SetActive(false);
    }

    private void SetTimerText(int time)
    {
        timerText.text = time.ToString();
    }
} // class
