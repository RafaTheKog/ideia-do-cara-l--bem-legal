using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [Header("Setup")]
    public int maxLife = 100;
    public Slider lifeSlider;

    [Header("Options")]
    public bool destroyAfterDeath = false;
    public float destroyTimer = 0;

    [Header("Feedbacks")]
    public UnityEvent OnDeath;

    // Use GetLife para verificar o valor de currentLife em outros Scripts
    public int GetLife { get => currentLife; }
    private int currentLife;

    void Start()
    {
        currentLife = maxLife;
        
        if (lifeSlider != null)
        {
            lifeSlider.maxValue = maxLife;
            lifeSlider.value = currentLife;
        }
    }

    private void SetLifeSlider(int value)
    {
        lifeSlider.value = value;
    }

    /// <summary> Usar para definir um novo valor para a vida </summary>
    public void SetLife(int newLife)
    {
        currentLife = newLife;
        SetLifeSlider(currentLife);

        if (currentLife > maxLife) currentLife = maxLife;
        if (currentLife <= 0) Death();
    }

    /// <summary> Usar para aplicar dano a este componente </summary>
    public void Damage(int damage)
    {
        currentLife -= damage;
        SetLifeSlider(currentLife);

        if (currentLife <= 0) Death();
    }

    /// <summary> Evento usado para aplicar feedbacks </summary>
    public void Death()
    {
        Debug.Log(gameObject.name + " Has Death");
        OnDeath?.Invoke();

        if (destroyAfterDeath)
        {
            Destroy(gameObject, destroyTimer);
        }
    }

    /// <summary> Chamar o revive daqui a um tempo especificado </summary>
    public void ReviveTimer(float time)
    {
        Invoke("Revive", time);
    }

    /// <summary> Usar caso precise reutilar o mesmo objeto </summary>
    public void Revive()
    {
        currentLife = maxLife;
        SetLifeSlider(currentLife);
        gameObject.SetActive(true);
    }
}
