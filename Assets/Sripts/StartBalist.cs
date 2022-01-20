using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class StartBalist : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDown;
    private bool start;
    [SerializeField] private float speedCharging;
    [SerializeField] private float speedShooting;
    [SerializeField] private float impulse;
    [SerializeField] private Slider power;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject katapult;
    [SerializeField] private GameObject deception;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody[] playerRb;
    private Quaternion target = Quaternion.Euler(15, 0, 0);
    private Quaternion shoot;
    private Quaternion current;
    private float shootForce;
    private float force;
    private bool a = true;

    private void Start()
    {
        shoot = katapult.transform.rotation;
        power.maxValue = 74;
        power.value = shootForce;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        this.isDown = true;
        start = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.isDown = false;
        start = true;
    }

    private void Update()
    {
        current = katapult.transform.rotation;
        power.value = shootForce;

        if (isDown)
        {
            katapult.transform.rotation = Quaternion.Slerp(current, target, Time.deltaTime * speedCharging);
            shootForce = Quaternion.Angle(shoot, current);
        }

        if (start)
        {
            katapult.transform.rotation = Quaternion.Slerp(current, shoot, Time.deltaTime * speedShooting);
         
            if(current == shoot && a)
            {
                force = shootForce * impulse;
                a = false;
                deception.SetActive(false);
                player.GetComponent<Renderer>().enabled = true;
                
                for (int i = 0; i < playerRb.Length; i++)
                {
                    playerRb[i].isKinematic = false;
                    playerRb[i].AddForce(Vector3.forward * force, ForceMode.Impulse);
                    playerRb[i].AddForce(Vector3.up * shootForce, ForceMode.Impulse);
                }
                Destroy(startButton);
                return;
            }
        }
    }

}
