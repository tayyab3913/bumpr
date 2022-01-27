using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int participantCount;
    public GameObject enemyParticipantPrefab;
    public GameObject playerParticipantPrefab;
    public List<GameObject> participants;
    private GameObject playerReference;
    private float spawnRange = 11;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < participantCount; i++)
        {
            GameObject tempParticipantReference;
            tempParticipantReference = Instantiate(enemyParticipantPrefab, GeneratreSpawnPosition(), enemyParticipantPrefab.transform.rotation);
            tempParticipantReference.GetComponent<Enemy>().InitializeEnemy(this);
            participants.Add(tempParticipantReference);
        }
        playerReference = Instantiate(playerParticipantPrefab, GeneratreSpawnPosition(), playerParticipantPrefab.transform.rotation);
        playerReference.GetComponent<PlayerController>().InitializePlayer(this);
        participants.Add(playerReference);
    }

    Vector3 GeneratreSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0f, spawnPosZ);
        return spawnPosition;
    }

    void InstantiateEnemyParticipant()
    {
        GameObject enemy = Instantiate(enemyParticipantPrefab, GeneratreSpawnPosition(), enemyParticipantPrefab.transform.rotation);
        enemy.GetComponent<Enemy>().InitializeEnemy(this);
    }

    public GameObject ClosestObject(Transform location)
    {
        float closestDistance = 9999;
        GameObject closestObject = null;
        foreach (GameObject participatedMember in participants)
        {
            float distanceToCheck = Vector3.Distance(participatedMember.transform.position, location.transform.position);
            if (distanceToCheck < closestDistance && distanceToCheck != 0)
            {
                closestDistance = distanceToCheck;
                closestObject = participatedMember;
            }
        }
        return closestObject;
    }

    public void RemoveFromParticipants(GameObject participantToRemove)
    {
        GameObject tempParticipant = null;
        foreach (GameObject participatedMember in participants)
        {
            if(participantToRemove == participatedMember)
            {
                tempParticipant = participatedMember;
            }
        }
        if(tempParticipant != null)
        {
            participants.Remove(tempParticipant);
        }  
    }
}
