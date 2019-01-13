using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    private float health;
    // The total health of this unit
    [SerializeField]
    float m_Health = 100;

    void Start()
    {
        health = m_Health;
    }

    public void DoDamage(int damage)
    {
        m_Health -= damage;        
        healthBar.fillAmount = m_Health / health;       
        if (m_Health <= 0 && gameObject.name != "Player")
        {            
            Destroy(gameObject);
        }else if (m_Health <= 0 && gameObject.name == "Player")
        {
            healthBar.fillAmount = 1f;
            m_Health = health;
            //THIS KEEPS LOOPING AND THE PLAYER DIES INTANTLY SOMEHOW
            //GetComponent<PlayerController>().Die();
        }
    }

    public bool IsAlive()
    {
        return m_Health > 0;
    }    
}
