using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject winTextObject;

    void Start() {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount) {
        currentHealth -= amount;
        Debug.Log("Daño recibido: " + amount + " | Vida restante: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die() {
        Debug.Log("Jugador eliminado");
        winTextObject.SetActive(true);
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        Destroy(gameObject);
    }
}