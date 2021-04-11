using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : MonoBehaviour
{
    //[SerializeField]
    private float moveSpeed = 23.0f;
    private float destroyedTime = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyedTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();          
    }

    private void Move()
    {
        this.transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
    }
}
