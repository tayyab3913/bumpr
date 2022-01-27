using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 10;
    private GameObject playerReference;
    private Rigidbody enemyRb;
    public GameManager gameManagerReference;
    private GameObject closestParticipant;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        //Debug.Log("Tag to Check: " + gameManagerReference.tag.ToString());
        //Debug.Log("Tag to Check: " + GetClosestParticipant().GetComponent<Enemy>().DisplaySuccessReference());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerReference.participants.ToArray().Length > 1)
        {
            MoveTowardsParticipant(GetClosestParticipant());
        } 
    }

    public void InitializeEnemy(GameManager gameManager)
    {
        gameManagerReference = gameManager;
    }

    GameObject GetClosestParticipant()
    {
        closestParticipant = gameManagerReference.ClosestObject(transform);
        return closestParticipant;
    }

    void MoveTowardsParticipant(GameObject target)
    {
        Vector3 temp = target.transform.position - transform.position;
        //Debug.Log(temp.x + ", " + temp.y + ", " + temp.z);
        enemyRb.AddForce((target.transform.position - transform.position).normalized * movementSpeed);
    }

    public string DisplaySuccessReference()
    {
        Debug.Log("Success Reference");
        return "Success Reference";
    }
}
