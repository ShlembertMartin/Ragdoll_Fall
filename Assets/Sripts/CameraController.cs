using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    public TargetCam targetCam;
    public float xPos;
    public float yPos;
    public float zPos;
    public float zPosTarget;
    public int speed;

    private Vector3 ofset;
    void Start()
    {
        LoadCamera();
        zPosTarget = targetCam.offset.z;
    }


    void Update()
    {
        ofset = new Vector3(xPos, yPos, zPos);
        targetCam.offset.z = zPosTarget;
       
        Vector3 pos = cameraTarget.position + ofset;
        transform.position = pos;
       
        speed = 15;
        var targetRotation = Quaternion.LookRotation(cameraTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    public void SaveCamera()
    {
        SavedSystem.SaveCamera(this);
    }

    public void LoadCamera()
    {
        CameraData data = SavedSystem.LoadCamera();
        speed = data.speed;
        xPos = data.position[0];
        yPos = data.position[1];
        zPos = data.position[2];
    }
}
