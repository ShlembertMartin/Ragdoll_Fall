using UnityEngine;

public class TargetCam : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    void Update()
    {
       var pos = player.position + offset;
        transform.position = pos;
    }
}
