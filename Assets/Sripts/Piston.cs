using UnityEngine;

public class Piston : MonoBehaviour
{ 
    enum Type {Auto, Manual}
    [SerializeField] private Type type;
    [SerializeField] private Transform piston;
    [SerializeField] private Transform upPoint;
    [SerializeField] private Transform downPoint;
    [SerializeField] private float forceUp;
    [SerializeField] private float forceForward;
    [SerializeField] private Rigidbody[] playerRigidbody;
    [SerializeField] private PressPiston pressPiston;
    [SerializeField] private CollisionPiston collisionPiston;
    [SerializeField] private TriggerButton triggerButton;
    private float speedShoot = 4;
    private float speedCharging = 2;
    private float distance;
    private float downDistance;
    private bool press;
    private bool trigger;
    
   
    private void MoveShoot()
    {
         distance = Vector3.Distance(piston.position, upPoint.position);
         downDistance = Vector3.Distance(downPoint.position, piston.position);

        if (press || trigger)
        {
            if (distance > 0.1f)
            {
                piston.Translate(Vector3.up * Time.deltaTime * speedShoot, Space.Self);
                if (collisionPiston.col) return;
            }
            else
            {
                press = false;
                trigger = false;
            }
        }
        else
        {
            if (downDistance >= 0.1f || collisionPiston.col)
            {
               piston.Translate(Vector3.up * Time.deltaTime * -speedCharging, Space.Self);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            if (type == Type.Auto) trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            if (type == Type.Auto) trigger = false;
        }
    }

    private void Kick()
    {
        Vector3 vector = Vector3.up * forceUp + Vector3.forward * forceForward;
        Vector3 stop = Vector3.zero;
        if (collisionPiston.col && press || collisionPiston.col && trigger)
        {
            for (int i = 0; i < playerRigidbody.Length; i++)
            {
                playerRigidbody[i].velocity = stop;
                playerRigidbody[i].AddForce(vector, ForceMode.Impulse);
            }
        }
    }

    void Update()
    {
        if(pressPiston.click && type == Type.Manual && triggerButton.kick)
        {
            pressPiston.click = false;
            press = true;
        }

        MoveShoot();
    }

    private void FixedUpdate()
    {
        Kick();
    }
}
