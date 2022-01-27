using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class StartPlatform : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDown;
    private bool start;
    [SerializeField] private float speedCharging;
    [SerializeField] private float speedShooting;
    [SerializeField] private float impulse;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject katapult;
    [SerializeField] private GameObject deception;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody[] playerRb;
    [SerializeField] private Transform target;
    [SerializeField] private Transform shoot;
    
    private Transform current;
    private float shootForce;
    private float force;
    private bool a = true;

    private void Start()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        start = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        start = true;
    }

    private void Update()
    {
        current = katapult.transform;

        if (isDown)
        {
            if(current.position.z > target.position.z) katapult.transform.Translate(0, 0, Time.deltaTime * -speedCharging);

            shootForce = shoot.position.z - current.position.z;
        }

        if (start)
        {
            if (current.position.z < shoot.position.z) katapult.transform.Translate(0, 0, Time.deltaTime * speedShooting);

            if (current.position.z >= shoot.position.z && a)
            {
                force = impulse;

                a = false;
                deception.SetActive(false);
                player.GetComponent<Renderer>().enabled = true;

                for (int i = 0; i < playerRb.Length; i++)
                {
                    playerRb[i].isKinematic = false;
                    playerRb[i].AddForce(Vector3.forward * force, ForceMode.Impulse);
                    playerRb[i].AddForce(Vector3.up * force, ForceMode.Impulse);
                }
                startButton.SetActive(false);
                return;
            }
        }
    }
}
