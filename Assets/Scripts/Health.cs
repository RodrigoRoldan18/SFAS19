using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    Image healthBar;

    float health;
    // The total health of this unit
    [SerializeField]
    float m_Health = 100;    

    void Start()
    {        
        health = m_Health;
    }

    public void DoDamage(int damage)
    {
        health -= damage;        
        healthBar.fillAmount = health / m_Health;       
        if (health <= 0 && gameObject.name != "Player")
        {            
            Destroy(gameObject);
            FindObjectOfType<GameControl>().PointsForEnemy();
            FindObjectOfType<GameControl>().UpdateScoreUI();
        }
        else if (health <= 0 && gameObject.name == "Player")
        {
            healthBar.fillAmount = 1f;
            health = m_Health;
            //THIS KEEPS LOOPING AND THE PLAYER DIES INTANTLY SOMEHOW.
            //GetComponent<PlayerController>().Die();
        }
    }

    public bool IsAlive()
    {
        return health > 0;
    }    
}
