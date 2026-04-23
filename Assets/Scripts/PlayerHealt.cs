using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public float damageCooldown = 1f;
    private bool canTakeDamage = true;
    public TextMeshProUGUI healthText;
    private AudioSource audioSource;
    public AudioClip loseSound;
    public GameObject deathVFX;

    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        Debug.Log("Vida inicial: " + currentHealth);

        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        if (!canTakeDamage) return;

        StartCoroutine(DamageCoroutine(damage));
    }

    IEnumerator DamageCoroutine(int damage)
    {
        canTakeDamage = false;

        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        Debug.Log("Vida actual: " + currentHealth);

        UpdateUI();

        if (currentHealth <= 0)
        {
            if (audioSource != null && loseSound != null)
                audioSource.PlayOneShot(loseSound);

            Die();
        }

        yield return new WaitForSeconds(damageCooldown);

        canTakeDamage = true;
    }

    void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;
    }

    void Die()
    {
        PlayerController pc = GetComponent<PlayerController>();

        if (deathVFX != null)
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);

            ParticleSystem ps = vfx.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
        }

        if (pc != null && pc.winTextObject != null)
        {
            pc.winTextObject.SetActive(true);
            pc.winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        if (pc != null)
            pc.enabled = false;

        GetComponent<MeshRenderer>().enabled = false;
    }
}