using System.Collections;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float forceUp;
    [SerializeField] private float forceForward;
    [SerializeField] private float timeReflect;
    [SerializeField] private float dump;
    [SerializeField] private float wait;
    [SerializeField] private Rigidbody[] playerHips;
    [SerializeField] private Transform platform;
    private Vector3 vector;
    private Vector3 stop;
    private bool jump;
    private void Start()
    {
        vector = Vector3.up * forceUp + Vector3.forward * forceForward;
        stop = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        jump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        jump = false;
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            StartCoroutine(Bump());
            for (int i = 0; i < playerHips.Length; i++)
            {
                playerHips[i].velocity = stop;
                playerHips[i].AddForce(vector, ForceMode.Impulse);
            }
        }
    }

    private  IEnumerator Bump()
    {
        platform.transform.Translate(0, -dump * Time.deltaTime * timeReflect, 0);
        yield return new WaitForSeconds(wait);
        platform.transform.Translate(0, dump * Time.deltaTime * timeReflect* 0.5f, 0);
        yield break;
    }
}
