using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject settingsPanel;
    public GameObject instructionsPanel;

    public PlayerController playerController;
    public MouseCameraController mouseCameraController;
    public PlayerInput playerInput;
    public EnemyMovement enemyMovement;

    public AudioSource musicSource;

    public Slider volumeSlider;
    public Slider enemySpeedSlider;
    public Animator enemyAnimator;

    void Start()
    {
        titleScreen.SetActive(true);
        settingsPanel.SetActive(false);
        instructionsPanel.SetActive(false);

        if (playerController != null)
            playerController.enabled = false;

        if (mouseCameraController != null)
            mouseCameraController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerInput != null)
            playerInput.enabled = false;

        if (enemyMovement != null)
            enemyMovement.enabled = false;

        if (musicSource != null)
            musicSource.Stop();

        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        if (enemySpeedSlider != null && enemyMovement != null)
        {
            NavMeshAgent agent = enemyMovement.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                enemySpeedSlider.value = agent.speed;
            }
            enemySpeedSlider.onValueChanged.AddListener(SetEnemySpeed);
        }

        if (enemyAnimator != null)
        {
            enemyAnimator.enabled = false;
        }
    }

    public void PlayGame()
    {
        titleScreen.SetActive(false);

        if (playerController != null)
            playerController.enabled = true;

        if (mouseCameraController != null)
            mouseCameraController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerInput != null)
            playerInput.enabled = true;

        if (enemyMovement != null)
            enemyMovement.enabled = true;

        if (musicSource != null)
            musicSource.Play();

        if (enemyAnimator != null)
        {
            enemyAnimator.enabled = true;
        }
    }

    public void OpenSettings()
    {
        titleScreen.SetActive(false);
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void OpenInstructions()
    {
        titleScreen.SetActive(false);
        settingsPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void ToggleMusic(bool isOn)
    {
        if (musicSource == null) return;

        if (isOn)
        {
            if (!musicSource.isPlaying)
                musicSource.Play();
        }
        else
        {
            musicSource.Pause();
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetEnemySpeed(float speed)
    {
        if (enemyMovement != null)
        {
            NavMeshAgent agent = enemyMovement.GetComponent<NavMeshAgent>();

            if (agent != null)
            {
                agent.speed = speed;
            }
        }
    }

    public void SetEnemySlow()
    {
        SetEnemySpeed(5f);
    }

    public void SetEnemyMedium()
    {
        SetEnemySpeed(10f);
    }

    public void SetEnemyFast()
    {
        SetEnemySpeed(15f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}