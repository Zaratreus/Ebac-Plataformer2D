using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool DestroyOnKill = false;

    public float delayToKill = 0f;
    
    private int _currentLife;

    private bool _IsDead = false;

    private void Awake()
    {
        init();
    }

    private void init()
    {
        _IsDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_IsDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            kill();
        }
    }

    private void kill()
    {
        _IsDead = true;

        if(DestroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}
