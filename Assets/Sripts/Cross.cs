using UnityEngine;

public class Cross : MonoBehaviour
{
    [SerializeField] private Transform cross;
    [SerializeField] private float speed;
    [SerializeField] private float forceUp;
    [SerializeField] private float forceForward;
    [SerializeField] private Rigidbody[] playerRigidbody;
    [SerializeField] private PressPiston pressPiston;
    [SerializeField] private TriggerButton triggerButton;
    [SerializeField] private GameObject colPiston1;
    [SerializeField] private GameObject colPiston2;
    private Quaternion target = Quaternion.Euler(90, 0, 0);
    private Quaternion current;
    private bool press;
    private bool trigger;
    

    private void MoveRotation()
    {
        current = cross.rotation;
        if(press) cross.rotation = Quaternion.Lerp(current, target, Time.deltaTime * speed);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
           trigger = false;
        }
    }

    private void Kick()
    {
        Vector3 vector = Vector3.up * forceUp + Vector3.forward * forceForward;
        Vector3 stop = Vector3.zero;
        if (trigger && press)
        {
            colPiston1.GetComponent<BoxCollider>().enabled = false;
            colPiston2.GetComponent<BoxCollider>().enabled = false;
            Time.timeScale = 1.7f;

            for (int i = 0; i < playerRigidbody.Length; i++)
            {
                playerRigidbody[i].velocity = stop;
                playerRigidbody[i].AddForce(vector, ForceMode.Impulse);
            }
        }
    }

    void Update()
    {
        if (pressPiston.click && triggerButton.kick)
        {
            pressPiston.click = false;
            press = true;
        }

        MoveRotation();
    }

    private void FixedUpdate()
    {
        Kick();
    }
}

