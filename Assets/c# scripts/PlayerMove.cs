using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpspeed;
    static float CurrentSpeed =0;
    private HealthAndScore speedMultiplier;
    private Rigidbody2D body;

    private void Awake()
    {
        speedMultiplier = GameObject.Find("WetBall").GetComponent<HealthAndScore>();
        body = GetComponent<Rigidbody2D>();
        CurrentSpeed = -speed;
    }
    private void Update()
    {
        body.velocity = new Vector2(CurrentSpeed* ((float)speedMultiplier.score/20+1), body.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpspeed);
            JumpSound();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("wall")) return;
        CurrentSpeed *=-1;
    }
    void JumpSound()
    {
        this.gameObject.GetComponent<VolumeLevel>().SetVolumeForButtons();
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}