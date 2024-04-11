using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public EnemyDamage enemyDamage;
    public PlayerStats playerStats;
    public Animator anim;
    public Slider hpSlider;
    public bool alive = true;
    public float timer;

    private void Start()
    {
        GameObject logicManager = GameObject.FindGameObjectWithTag("LogicManager");
        enemyDamage = logicManager.GetComponent<EnemyDamage>();
        anim = GetComponentInChildren<Animator>();
        playerStats = GetComponent<PlayerStats>();
        hpSlider = GetComponentInChildren<Slider>();
        hpSlider.maxValue = playerStats.HP;
    }

    void Update()
    {
        hpSlider.value = playerStats.HP;
        timer += Time.deltaTime;
        if (playerStats.HP <= 0)
        {
            alive = false;
        }
        if (timer > 0.4)
        {
            anim.SetBool("Hurt", false);
        }
    }

    public void TakeDamage(int damage)
    {
        playerStats.HP -= damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            if (timer > 0.5)
            {
                anim.SetBool("Hurt", true);
                TakeDamage(enemyDamage.enemyDamage1);
                timer = 0;
            }
        }
    }
}
