using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;

    public int health;
    int score;
    public TMP_Text healthDisplay;
    public TMP_Text scoreDisplay;

    private SpriteRenderer spriteRenderer;

    public Sprite fullHealthSprite;
    public Sprite mediumHealthSprite;
    public Sprite lowHealthSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthDisplay.text = "Vidas: " + health;
        scoreDisplay.text = "Puntos: " + score;

        spriteRenderer.sprite = fullHealthSprite;
    }

    void Update()
    {
        // Rotar ao xogador
        transform.Rotate(Vector3.forward * turnSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);

        // Pausar o xogo
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TakeDamage()
    {
        health--;
        healthDisplay.text = "Vidas: " + health;


        // Cambiar sprite según vida
        // if (health <= 7 && health > 3)
        // {
        //     spriteRenderer.sprite = mediumHealthSprite;
        // }
        // else if (health <= 3 && health > 0)
        // {
        //     spriteRenderer.sprite = lowHealthSprite;
        // }

        if (health <= 0)
        {
            SceneManager.LoadScene("LostGameScene");
        }
    }

    // Puntuar
    public void AddScore()
    {
        score++;
        scoreDisplay.text = "Puntos: " + score;
    }

    void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
        }
    }

}
