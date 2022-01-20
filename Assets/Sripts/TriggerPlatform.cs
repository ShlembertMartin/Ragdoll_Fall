using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private TabPlatform tab;
    [SerializeField] private GameObject platform;
    [SerializeField] private Rigidbody [] playerRb;
    [SerializeField] private float forceUp;
    [SerializeField] private float forceForward;
    [SerializeField] private float speedShoot;
    [SerializeField] private float speedCharging;
    [SerializeField] private float upPoint;
    [SerializeField] private float downPoint;
    private Vector3 vector;
    private Vector3 stop;
    private bool isCollider = false;
    private bool kick = false;
    private bool press = false;
    public float currentPoint;
   
    private void Start()
    {
        stop = Vector3.zero;
        vector = Vector3.up * forceUp + Vector3.forward * forceForward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>()) isCollider = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>()) isCollider = false;
    }

    void Update()
    {
        currentPoint = platform.transform.position.y;

        if (tab.isDown && !press)
        {
            kick = true;
            press = true;

            if (currentPoint <= upPoint)
            {
                platform.transform.Translate(0, speedShoot * Time.deltaTime, 0);
                press = false;
            }
            else press = true;
        }
        else
        {
            kick = false;
           
            if (currentPoint > downPoint)
            {
                platform.transform.Translate(0, -speedCharging * Time.deltaTime, 0);
            }
        }

        if (tab.start) press = false;
    }

    private void FixedUpdate()
    {
        if(kick && isCollider)
        {
            for (int i = 0; i < playerRb.Length; i++)
            {
                playerRb[i].velocity = stop;
                playerRb[i].AddForce(vector, ForceMode.Impulse);
            }
        }
    }
}
