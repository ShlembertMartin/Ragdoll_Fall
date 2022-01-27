using UnityEngine;

public class TargetCam : MonoBehaviour
{
    [SerializeField] private Transform player;
   
    public Vector3 offset;

    private void Start()
    {
        LoadTarget(); 
    }
    void Update()
    {
        var pos = player.position + offset;
        transform.position = pos;
    }

    public void LoadTarget()
    {
        CameraData data = SavedSystem.LoadCamera();
        offset.z = data.targetPos;
    }
}
