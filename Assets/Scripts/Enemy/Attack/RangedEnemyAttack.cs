using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyAttack : EnemyAttack
{
    [SerializeField] private float attackDistance;
    
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private PlayerInventory _playerInventory;
    private Spell _spell;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        _spell = gameObject.GetComponent<EnemySpell>();
    }

    public override void DoAttack()
    {
        _spell.Cast(_navMeshAgent, _animator, _playerInventory);
    }

    public override bool IsAttacking()
    {
        var currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        bool isSpellCastAnim = currentAnimatorStateInfo.IsName(_spell.data.animationName);
        return _spell.IsCastingSpell || isSpellCastAnim;
    }

    public override float AttackDistance()
    {
        return attackDistance;
    }
}
