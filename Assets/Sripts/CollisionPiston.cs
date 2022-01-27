using UnityEngine;

public class CollisionPiston : MonoBehaviour
{
    public bool col;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>()) col = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>()) col = false;
    }
}
