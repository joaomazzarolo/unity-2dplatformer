using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 2;
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";
    public float timeToDestroy = 2f;    

    public HealthBase healthbase;

    private void Awake()
    {
        if(healthbase != null)
        {
            healthbase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthbase.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
        Destroy(gameObject, timeToDestroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }
    public void Damage(int amount)
    {
        healthbase.Damage(amount);
    }
}
