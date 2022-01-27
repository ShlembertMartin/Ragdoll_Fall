using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public bool kick;

    private void Start()
    {
        Time.timeScale = 1.7f;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
          kick = true;
        }
        Time.timeScale = 0.8f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
           kick = false;
        }
        Time.timeScale = 1.7f;
    }
}
