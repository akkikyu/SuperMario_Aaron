using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public int direction = 1;
    private float inputHorizontal;
    private Rigidbody2D rigidBody;
    public float jumpForce = 12;
    public GroundSensor groundSensor;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip jumpSFX;

    public AudioClip deadSFX;

    private BoxCollider2D boxCollider;
    private GameManager gameManager;

    private SoundManager soundManager;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public AudioClip shootSFX;
    public float powerUpDuration = 5;
    public float powerUpTimer;
    public bool canShoot = false;
    public AudioClip powerUpSFX;
    private SpriteRenderer renderer;
    public Image PowerUpImage;

    void Awake()
    { 
        rigidBody = GetComponent<Rigidbody2D>();
        groundSensor = GetComponentInChildren<GroundSensor>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //tp al goomba
        //transform.position = new Vector3 (0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if(!gameManager.isPlaying)
        {
            return;
        }
        if(gameManager.isPaused)
        {
            return;
        }
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.Translate(new Vector3 (direction * playerSpeed * Time.deltaTime, 0, 0));
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && groundSensor.IsGrounded)
        {
            Jump();
        }
        Movement();
        animator.SetBool("IsJumping", !groundSensor.IsGrounded);
        /*if(groundSensor.IsGrounded)
        {
            animator.SetBool("IsJumping", false);
        else
        {
            animator.SetBool("IsJumping", true)
        }*/
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }
        if(canShoot)
        {
            PowerUp();
        }
    }
    
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(inputHorizontal * playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(inputHorizontal, 0));
        //rigidBody.MovePosition(new Vector2(100, 0));
    }

    void Movement()
    {
        if(inputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("IsRunning", true);
        }
        else if(inputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("IsRunning", true);  
        }
        else
            animator.SetBool("IsRunning", false);
        
    }
    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
        audioSource.PlayOneShot(jumpSFX);
    }

    public void Death()
    {
        
        animator.SetTrigger("IsDead");
        audioSource.PlayOneShot(deadSFX);
        boxCollider.enabled = false;
        Destroy(groundSensor.gameObject);
        inputHorizontal = 0;
        rigidBody.velocity = Vector2.zero;
        soundManager.audioSource.volume = 0;
        soundManager.Invoke("DeathBGM", 6);
        //StartCoroutine(soundManager.DeathBGM());
        rigidBody.AddForce(Vector2.up * jumpForce/1.5f, ForceMode2D.Impulse);
        gameManager.isPlaying = false;
        Destroy(gameObject, 2);

        SceneManager.LoadScene(2);        
    
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        audioSource.PlayOneShot(shootSFX);
    }
    void PowerUp()
    {
        powerUpTimer += Time.deltaTime;
        PowerUpImage.fillAmount = Mathf.InverseLerp(powerUpDuration, 0, powerUpTimer);
        if(powerUpTimer >= powerUpDuration)
        {
            canShoot = false;
            powerUpTimer = 0;
        }
    }
    
}
