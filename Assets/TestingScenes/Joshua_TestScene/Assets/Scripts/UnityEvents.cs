using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class UnityEvents : MonoBehaviour
{
    // ON ENABLED SECTION
    public UnityEvent onStart;
    private bool Toggle = true;
    private void OnEnable()
    {
        if (Toggle)
        {
            onStart.Invoke();
            Toggle = false;
        }
    }
    private void OnDisable()
    {
        Toggle = true;
    }
    
    
    // ON TRIGGER ENTER SECTION (COLLIDERS)
    public string tagToActivate = "Player";
    public UnityEvent onTriggerEnter, OnTriggerExit;

    private void Awake()
    {
        if (GetComponent<Collider2D>() == null)
        {
            Debug.Log($"{gameObject} is missing a collider.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate))
        {
            onTriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate))
        {
            OnTriggerExit.Invoke();
        }
    }
    
    
    // EVENTONTIMER SECTION
    
    
    [SerializeField] private float Timer = 30f;
    public UnityEvent onTimeEnd;
    private bool timerRunning = false;
    private float defaultTime;
    
    public TextMeshProUGUI timerValueUI;
    private bool displayText = false;

    private void Start()
    {
        defaultTime = Timer;
        if (timerValueUI != null)
        {
            displayText = true;
        }
    }

    private void Update() //called once per frame
    {
        if (timerRunning)
        {
            Timer -= Time.deltaTime;
            if (displayText)
            {
                timerValueUI.SetText($"{(int)Timer}");
            }

            if (Timer <= 0)
            {
                onTimeEnd.Invoke();
                timerRunning = false;
                Timer = defaultTime;
            }
        }
    }
}
