 
using UnityEngine;
using UnityEngine.UI;
using System;

public class ZHP : MonoBehaviour
{
    private protected ZMoveBeh moveEnemy;

    private protected Image imageHP;
    private protected Rigidbody enemyRig;
    private protected Collider enemyCollider;
    [Header("HPEnemy")]
    [field: SerializeField] private protected float currentHP = 100;
    [field: Range(1, 10), SerializeField] private protected float ignoreDamage = 1;
    //field - ����������� ��� �������� SerializeField, ����������� ���������� ���������� � ����������, ������� �������� ���������, �.�. {get; private set;}
    private protected Animator anim;

    public event Action onPlayAudioZombieDeath;
    private void Awake()
    {
        moveEnemy = GetComponent<ZMoveBeh>();
        imageHP = GetComponentInChildren<Image>();
        enemyRig = GetComponent<Rigidbody>();
        enemyCollider = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        InactiveZombie(true);
        currentHP = 100;
    }
    private void Update()
    {
        imageHP.fillAmount = currentHP / 100;
    }
    public virtual void TakeDamageEnemy(float damage)
    {
        if (currentHP <= 0)
        {
            anim.SetTrigger("DeathTrigger");
            InactiveZombie(false);
            onPlayAudioZombieDeath?.Invoke();
        }
        else
        {
            currentHP -= damage / ignoreDamage;
        }
    }
    private protected void InactiveZombie(bool isActive)
    {
        enemyRig.isKinematic = !isActive;
        enemyCollider.enabled = isActive;
        moveEnemy.enabled = isActive;
    }
}
