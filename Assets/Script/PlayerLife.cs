using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigid;
    [SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        if(animator == null)
            animator = GetComponent<Animator>();
        if(rigid == null)
              rigid = GetComponent<Rigidbody2D>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("killzone") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rigid.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void RestartLevel()
    {
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
