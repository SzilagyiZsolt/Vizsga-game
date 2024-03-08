using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherHealth : MonoBehaviour
{
    public Slider HP;
    public Slider Mana;
    public ArcherMovement archerMovement;
    public DamageExecutioner damageExecutioner;
    public GameObject skill;
    public SpriteRenderer skillSprite;
    public Color skillColor;
    public float timer;
    public float timer2;
    public float health;
    public float maxHealth;
    public float mana;
    public float maxMana;
    public float barrier;
    public float manaRegen;
    public float hpRegen;
    public bool skillActive=false;
    void Start()
    {
        archerMovement = GetComponent<ArcherMovement>();
    }
    private void Update()
    {
        timer2 += Time.deltaTime;
        if (timer2 < 1)
        {
            health=maxHealth;
            mana=maxMana;
        }
        HP.maxValue=maxHealth;
        HP.value=health;
        Mana.maxValue=maxMana;
        Mana.value=mana;
        timer += Time.deltaTime;
        if (skillActive && mana > 0 && health > 0)
        {
            skill.SetActive(true);
            mana-=barrier*Time.deltaTime;
            skillColor.a=mana/maxMana;
            skillSprite.color=skillColor;
        }
        else
        {
            skill.SetActive(false);
            skillActive = false;
        }
        ManaUsage();
    }

    public void TakeDamage(int damage)
    {
        if (!skillActive)
        {
            health -= damage;
            timer = 0;
        }
    }
    public void ManaUsage()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !skillActive)
        {
            skillActive=true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && skillActive)
        {
            skillActive = false;
        }
    }
}
