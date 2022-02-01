using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAController : Entity
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Stats stats;
    [SerializeField] private Animator anim;

    [SerializeField] private Transform offsetPosition;
    [SerializeField] private Transform target;

    private bool canFollow;
    private bool canHit;
    private bool isDead;
    public int animationToDo;

    private void Update()
    {
        if(!isDead)
        {
            if (canFollow)
            {
                anim.SetBool("OnIdle", false);
                anim.SetBool("canRun", true);
                transform.LookAt(target);
                agent.SetDestination(target.position);

                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            if (canHit)
                            {
                                return;
                            }
                            anim.SetBool("canHit", true);
                            anim.SetBool("canRun", false);

                            StartCoroutine(Hit());

                            animationToDo = Random.Range(0, 3);

                            if (animationToDo == 0)
                            {
                                anim.SetInteger("animationToDo", animationToDo);
                            }
                            else if (animationToDo == 1)
                            {
                                anim.SetInteger("animationToDo", animationToDo);
                            }
                            else
                            {
                                anim.SetInteger("animationToDo", animationToDo);
                            }

                            stats.TakeDamage(damage);
                        }
                    }
                }
                else
                {
                    anim.SetBool("canHit", false);
                    anim.SetBool("canRun", true);
                }
            }
            else
            {
                anim.SetBool("OnIdle", false);
                anim.SetBool("canRun", true);
                transform.LookAt(offsetPosition);
                agent.SetDestination(offsetPosition.position);

                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            anim.SetBool("OnIdle", true);
                            anim.SetBool("canRun", false);
                        }
                    }
                }
            }
        }

    }

    public void GetHit(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        anim.SetBool("OnIdle", false);
        anim.SetBool("canRun", false);
        anim.SetBool("canHit", false);
        anim.SetBool("isDead", true);
        /*yield return new WaitForSeconds(10f);
        Destroy(gameObject);*/
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canFollow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canFollow = false;
        }
    }

    IEnumerator Hit()
    {
        
        canHit = true;
        yield return new WaitForSeconds(1.5f);
        canHit = false;
    }
}
