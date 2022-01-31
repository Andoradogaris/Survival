using System.Collections;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Stats Générales")]
    [SerializeField] public int health;
    [SerializeField] private int maxHealth;
    [SerializeField] public int speed;
    [SerializeField] private int maxSpeed;
    [SerializeField] private int armor;
    [SerializeField] private int minDamage;
    [SerializeField] private int maxDamage;
    [SerializeField] private int criticalChance;

    [Header("Stats Vitales")]
    [SerializeField] private int food;
    [SerializeField] private int maxFood;
    [SerializeField] private int thirst;
    [SerializeField] private int maxThirst;

    private bool isDead;


    private void Awake()
    {
        health = maxHealth;
        speed = maxSpeed;

        food = maxFood;
        thirst = maxThirst;

        isDead = false;

        StartCoroutine(LoseAttributes());
    }

    private void Update()
    {
        if (isDead)
        {
            Die();
        }
    }

    public int HitDamage()
    {
        int damageToDeal = Random.Range(minDamage, maxDamage);

        if(Random.Range(0, 100) <= criticalChance)
        {
            damageToDeal *= 2;
            Debug.Log("Critical Strike !");
        }

        return damageToDeal;
    }

    public int ReduceDamage(int damageToDeal)
    {
        if(armor != 0)
        {
            damageToDeal *= armor;
            damageToDeal /= 100;
            damageToDeal = 100 - damageToDeal;
        }
        return damageToDeal;
    }

    public void TakeDamage(int damage)
    {
        int finalDamage = ReduceDamage(damage);
        health -= finalDamage;

        if (health <= 0)
        {
            isDead = true;
        }
    }

    public void Heal(int heal)
    {
        health += heal;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Drink(int drink)
    {
        thirst += drink;

        if (thirst >= maxThirst)
        {
            thirst = maxThirst;
        }
    }

    public void Eat(int eat)
    {
        food += eat;

        if (food >= maxFood)
        {
            food = maxFood;
        }
    }


    public void Die()
    {
        Debug.Log("You Are Dead");
    }

    IEnumerator LoseAttributes()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);
            food--;
            thirst--;
        }
    }
}
