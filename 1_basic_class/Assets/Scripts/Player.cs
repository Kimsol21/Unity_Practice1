using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text chickText;
    private Rigidbody rigid;
    public GameObject chickPrefab;
    public GameObject treePrefab;
    private Vector3 myFirstPosition;
    private Vector3 moveVector;

    private float moveSpeed = 15.0f;
    private float chickMakingTime = 1.0f;
    private float treeMakingTime = 3.0f;
    private bool isMakingChick = false;
    private bool isMakingTree = false;
    public int chickCount = 0;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        myFirstPosition = this.gameObject.transform.position;
    }

    private void Update()
    {
        Move();
        if(isMakingChick == false)
            StartCoroutine("CreateNewChicks");
        if (isMakingTree == false)
            StartCoroutine("CreateNewTree");
    }

    private void Move()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector = moveVector.x * Vector3.right;
        this.transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }

    IEnumerator CreateNewChicks()
    {
        isMakingChick = true;
        Instantiate(chickPrefab, new Vector3(myFirstPosition.x + Random.Range(-9f, 9f), 0, -100), Quaternion.identity);
        yield return new WaitForSeconds(chickMakingTime);    
        isMakingChick = false;
    }

    IEnumerator CreateNewTree()
    {
        isMakingTree = true;
        Instantiate(treePrefab, new Vector3(0,0,-100), Quaternion.identity);
        yield return new WaitForSeconds(treeMakingTime);
        isMakingTree = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chick"))
        {            
            chickCount += 1;         
            this.chickText.text = chickCount.ToString();
            Destroy(collision.gameObject, 0);
        }
    }
}

