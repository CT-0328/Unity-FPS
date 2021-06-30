using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public static float playerHealth = 100f;
    public Text deathText;
    public GameObject player;
    private float timer = 0;
    public float regenInterval;
    public Text retryText;

    void Update() {
      if (timer < regenInterval) {
        timer += Time.deltaTime;
      }
      if(Input.GetMouseButtonDown(1)) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerHealth = 100f;
      }
      if(playerHealth <= 90 && playerHealth < 0 && timer > regenInterval) {
        playerHealth += 10;
        timer = 0;
      }
    }

    public void takeDamage(float amount) {
      playerHealth -= amount;
      if (playerHealth <= 0f) {
        deathText.text = "You Died!";
        Die();
      }
    }

    void Die() {
      retryText.text = "Right click to retry!";
    }
}
