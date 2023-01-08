using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Myscript : MonoBehaviour
{
    public float move_X;
    public float jumpForce;
    public float speed;
    public bool isJumping;
    public Text scoreUI;
    public AudioClip coin;
    public AudioClip jump;
    public AudioSource audioSource;

    private Rigidbody2D rb;
    private int score;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ��˹��س���ѵԷҧ���ԡ������
        audioSource= rb.GetComponent<AudioSource>();
    }


    private void Update()
    {
        
        move_X = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move_X * speed,rb.velocity.y);
        

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce *100));
            audioSource.PlayOneShot(jump);
        }
    }

    // �礼����蹷��仪��Ѻ�ѵ�ط������ö���������
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    // �礼����蹷��仪��Ѻ�ѵ�ط������ö������
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Item"))
        {
            // ź�������� 
            Destroy(target.gameObject);
            score += 10;
            scoreUI.text = "��ṹ = " + score.ToString();
            audioSource.PlayOneShot(coin);
        }
        if (target.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (target.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene("Level02"); 
        }
    }

}
