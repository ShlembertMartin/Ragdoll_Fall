using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salut : MonoBehaviour
{
    [SerializeField] private GameObject particle;

    private void Start()
    {
        particle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            particle.SetActive(true);
            StartCoroutine(Finish());
        }
    }

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        yield break;
    }
}
