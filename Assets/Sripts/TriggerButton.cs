using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public bool kick;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
          kick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
           kick = false;
        }
    }
}
