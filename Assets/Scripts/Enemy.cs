using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 50f;
    public GameObject player;
    public GameObject enemy;
    public ParticleSystem enemyMuzzleFlash;
    public float damage = 10f;
    public float range = 15f;

    public void damaged (float amount) {
      health -= amount;
      if (health <= 0f) {
        Die();
      }
    }

    void Die() {
      Destroy(gameObject);
    }

    public void EnemyShoot() {
      enemyMuzzleFlash.Play();
      RaycastHit hit;
      if (Physics.Raycast(enemy.transform.position, enemy.transform.forward, out hit, range)) {
        PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();
        if (player != null) {
          player.takeDamage(damage);
          //Debug.Log(playerHealth);
        }
      }
      Debug.Log("Enemy shot");
    }
}
