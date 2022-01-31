using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;
    [SerializeField] public int speed;
    [SerializeField] public int damage;

    private void Start()
    {
        health = maxHealth;
    }
}
