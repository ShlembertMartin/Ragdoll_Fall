using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Colovrat : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Vector3 pos = other.transform.position;
            player.GetComponent<Renderer>().enabled = false;
            Instantiate(particle, pos, Quaternion.identity);
            StartCoroutine(Restart());
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
        yield break;
    }
}
