using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private PlayerController player;
    private bool inactive = false;
    private bool hasDealtDamage = false;

    public AudioClip destroySound;
    public AudioClip hitSound;

    private AudioSource audioSource;
    private Collider2D enemyCollider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        enemyCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!inactive)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hole") && !inactive)
        {
            inactive = true;
            player.AddScore();
            PlaySound(destroySound);

            enemyCollider.enabled = false;
            speed = 0;

            spriteRenderer.enabled = false;

            Destroy(gameObject, destroySound.length);
        }
        else if (other.CompareTag("Player") && !inactive)
        {
            inactive = true;
            if (!hasDealtDamage)
            {
                player.TakeDamage();
                PlaySound(hitSound);
                hasDealtDamage = true;
            }
            speed = 0;
            transform.parent = player.transform;
        }
        else if (other.CompareTag("Enemy"))
        {
            EnemyController otherEnemy = other.GetComponent<EnemyController>();
            if (otherEnemy != null && otherEnemy.speed == 0 && !hasDealtDamage)
            {
                player.TakeDamage();
                PlaySound(hitSound);
                hasDealtDamage = true;
                speed = 0;
                transform.parent = player.transform;
            }
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
