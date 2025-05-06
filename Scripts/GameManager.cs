using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    private int maxTargets;
    private int targetCount;

    [SerializeField] private TextMeshProUGUI targetInformation;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Button restartButton;
    [SerializeField] private Button backToMenuButton;

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip shotSfx;
    [SerializeField] private AudioClip explosionSfx;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        maxTargets = targets.Length;
        targetCount = targets.Length;

        restartButton.onClick.AddListener(OnRestartGame);
        backToMenuButton.onClick.AddListener(BackToMenu);
    }

    private void Update()
    {
        OnUpdateTarget();
    }

    public void OnUpdateTarget()
    {
        List<GameObject> updatedTargets = new List<GameObject>();
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
            {
                updatedTargets.Add(targets[i]);
            }
        }
        targets = updatedTargets.ToArray();

        targetCount = targets.Length;

        targetInformation.text = targetCount + "/" + maxTargets;

        if (targetCount <= 0)
        {
            gameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }

        Debug.Log("Target Count: " + targetCount);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayShotSfx()
    {
        sfxSource.PlayOneShot(shotSfx);
    }

    public void PlayExplosionSfx()
    {
        sfxSource.PlayOneShot(explosionSfx);
    }
}
