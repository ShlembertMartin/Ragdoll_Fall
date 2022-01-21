using UnityEngine;

public class CollisionPiston : MonoBehaviour
{
    public bool col;
    private void OnCollisionEnter(Collision collision)
    {
        col = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        col = false;
    }
}
