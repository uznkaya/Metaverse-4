using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
    [SerializeField] float horizontalBoundry;
    private void Update()
    {
        if(transform.position.x < -horizontalBoundry)
        {
            transform.position = new Vector3(-horizontalBoundry,transform.position.y,transform.position.z);
        }
        if (transform.position.x > horizontalBoundry)
        {
            transform.position = new Vector3(horizontalBoundry, transform.position.y, transform.position.z);
        }
    }
}
