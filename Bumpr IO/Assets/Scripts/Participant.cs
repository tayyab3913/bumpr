using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participant : MonoBehaviour
{
    public Texture[] textures;
    public string participantName;
    public float attackForce = 10;
    public int totalKills;
    private Renderer rendererReference;
    private GameObject lastHitBy = null;
    private Rigidbody participantRb;
    // Start is called before the first frame update
    void Start()
    {
        participantRb = GetComponent<Rigidbody>();
        rendererReference = GetComponent<Renderer>();
        totalKills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Participant"))
        {
            Rigidbody collidedRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = (collision.gameObject.transform.position - transform.position).normalized;
            collidedRb.AddForce(forceDirection * attackForce, ForceMode.Impulse);
            lastHitBy = collision.gameObject;
        }
    }

    void CheckDeath()
    {
        if (transform.position.y < -3)
        {
            HelpWhomKilledYou();
            RemovePlayerFromGame();
            Destroy(gameObject);
        }
    }

    void HelpWhomKilledYou()
    {
        if (lastHitBy != null)
        {
            Participant tempPart = lastHitBy.GetComponent<Participant>();
            tempPart.IncreaseStrength();
        }
    }

    public void IncrementAttackForce()
    {
        attackForce += 5;
    }

    public void IncreaseScaleMass()
    {
        transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        participantRb.mass += 0.5f;


    }

    public void UpdateTexture()
    {
        int temp = Random.Range(0, textures.Length);
        rendererReference.material.SetTexture("_MainTex", textures[temp]);
    }

    public void IncreaseKillCount()
    {
        totalKills++;
    }

    public void IncreaseStrength()
    {
        IncrementAttackForce();
        IncreaseScaleMass();
        UpdateTexture();
        IncreaseKillCount();
    }

    void RemovePlayerFromGame()
    {
        if(GetComponent<Enemy>() != null)
        {
            GetComponent<Enemy>().gameManagerReference.RemoveFromParticipants(gameObject);
        } else if(GetComponent<PlayerController>() != null)
        {
            GetComponent<PlayerController>().gameManagerReference.RemoveFromParticipants(gameObject);
        }
    }
}
