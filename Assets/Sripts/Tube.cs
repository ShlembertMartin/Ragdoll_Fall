using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] private float forceUp;
    [SerializeField] private float forceForward;
    [SerializeField] private Rigidbody[] playerRigidbody;
    private bool start;

    private void OnTriggerEnter( Collider other)
    {
        if (other.GetComponent<Rigidbody>()) start = true;
    }

    private void FixedUpdate()
    {
        if (start)
        {
            Vector3 vector = Vector3.up * forceUp + Vector3.forward * forceForward;
            Vector3 stop = Vector3.zero;


            for (int i = 0; i < playerRigidbody.Length; i++)
            {
                playerRigidbody[i].velocity = stop;
                playerRigidbody[i].AddForce(vector, ForceMode.Impulse);
            }
            start = false;
        }
    }
}
