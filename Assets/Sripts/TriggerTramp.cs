using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTramp : MonoBehaviour
{
    //public bool jump = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            SceneManager.LoadScene(0);
        }
    }
}
