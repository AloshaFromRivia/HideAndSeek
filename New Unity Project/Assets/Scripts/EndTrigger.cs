using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private float timeBeforeLoadNewScene = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Timer());
        }

    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeBeforeLoadNewScene);
        SceneManager.LoadScene(sceneName);
    }
}
