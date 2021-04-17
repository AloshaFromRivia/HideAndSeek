using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private GameObject go;


    private void Update()
    {
        this.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, -10);
    }
}
