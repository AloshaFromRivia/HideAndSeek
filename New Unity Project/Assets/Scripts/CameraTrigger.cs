using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rgHero;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _rgHero.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(LoadScene());
       

    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
