using UnityEngine;

public class ZAnimation : MonoBehaviour
{
    private protected ZAttackBeh attackEnemy;

    public Animator animZ;
    private protected ZMoveBeh moveZ;
    private void Awake()
    {
        animZ = GetComponent<Animator>();
        moveZ = GetComponent<ZMoveBeh>();
        attackEnemy = GetComponent<ZAttackBeh>();
    }
    private void OnEnable()
    {
        moveZ.onScream += ScrimerAnim;
        attackEnemy.onDefaultAttack += DefaultAttackAnim;
    }
    private void OnDisable()
    {
        moveZ.onScream -= ScrimerAnim;
        attackEnemy.onDefaultAttack -= DefaultAttackAnim;
    }
    public void MoveAnim(float moveSpeed)
    {
        animZ.SetFloat("velocityY", Mathf.Abs(moveSpeed), 0.2f, Time.deltaTime);
    }
    private protected void ScrimerAnim()
    {
        animZ.SetTrigger("ScreamTrigger");
    }
    private protected void JumpAnimAttack()
    {
        animZ.SetTrigger("JumpAttackTrigger");
    }
    private protected void PunchAnimAttack()
    {
        animZ.SetTrigger("PunchAttackTrigger");
    }
    private protected void DefaultAttackAnim()
    {
        animZ.SetTrigger("AttackTrigger");
    }
}
