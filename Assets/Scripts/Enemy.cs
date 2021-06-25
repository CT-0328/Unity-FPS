using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public float health = 50f;
    public GameObject player;
    public GameObject enemy;
    public ParticleSystem enemyMuzzleFlash;
    public float damage = 10f;
    public float range = 15f;
    private static float playerHealth;
    public Text winText;
    public Text replayText;

    public void damaged(float amount) {
      health -= amount;
      if (health <= 0f) {
        Die();
      }
    }

    void Update() {
      if(Input.GetMouseButtonDown(1)) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerHealth.playerHealth = 100f;
      }
    }

    void Die() {
      Destroy(gameObject);
      winText.text = "You Win!";
      replayText.text = "Right click to play again!";
    }

    public void EnemyShoot() {
      if(PlayerHealth.playerHealth > 0) {
        enemyMuzzleFlash.Play();
      }
      RaycastHit hit;
      if(Physics.Raycast(enemy.transform.position, enemy.transform.forward, out hit, range)) {
        PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();
        if(player != null) {
          player.takeDamage(damage);
        }
      }
    }
}
