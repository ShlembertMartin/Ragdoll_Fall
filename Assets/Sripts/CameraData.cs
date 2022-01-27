
[System.Serializable]

public class CameraData
{
    public int speed;
    public float[] position;
    public float targetPos;

    public CameraData(CameraController camera)
    {
        speed = camera.speed;
        position = new float[3];
        
        position[0] = camera.xPos;
        position[1] = camera.yPos;
        position[2] = camera.zPos;

        targetPos = camera.zPosTarget;
    }
}
