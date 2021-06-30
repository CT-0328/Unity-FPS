using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject player;
    private float timer = 0;
    public float shootInterval;
    public float speed = 2f;
    public Transform[] patrolSpots;
    private int patrolSpotIndex;
    private float spotDistance;

    void Start() {
      patrolSpotIndex = 0;
      transform.LookAt(patrolSpots[patrolSpotIndex].position);
    }

    void Update() {
      if(timer < shootInterval) {
        timer += Time.deltaTime;
      }

      float distance = Vector3.Distance(player.transform.position, transform.position);
      spotDistance = Vector3.Distance(transform.position, patrolSpots[patrolSpotIndex].position);

      if(spotDistance < 0.01f) {
        increaseIndex();
      }

    if(distance >= 20){
      patrol();
    }

    else if(distance < 20) {
      transform.position += transform.forward * speed * Time.deltaTime;
      Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
    }

    else if(distance <= 15 && timer > shootInterval) {
      FindObjectOfType<Enemy>().EnemyShoot();
      timer = 0;
    }
  }

    void patrol() {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void increaseIndex() {
      patrolSpotIndex++;
      if(patrolSpotIndex >= patrolSpots.Length) {
        patrolSpotIndex = 0;
      }
      transform.LookAt(patrolSpots[patrolSpotIndex].position);
    }
  }
