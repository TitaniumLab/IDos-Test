using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IInput
{
    [field: SerializeField] public IDamagable.Fraction TargetFraction { get; private set; }
    [SerializeField] private Transform RouteParent;
    [field: SerializeField] public List<Transform> RoutePoints { get; private set; }
    [field: SerializeField] public int CurrentPointIndex { get; private set; }
    [field: SerializeField] public float IdolTime { get; private set; }
    [field: SerializeField] public bool IsAttacking { get; private set; }
    [field: SerializeField] public Transform CurrentTargetTransform { get; private set; }
    public Rigidbody2D _enemyRb { get; private set; }
    public Transform _enemyTransform { get; private set; }


    public StateMachine EnemyStateMachine { get; private set; }
    public IdolState EnemyIdolState { get; private set; }
    public PatrolState EnemyPatrolState { get; private set; }
    public ChaseState EnemyChaseState { get; private set; }
    public AttackState EnemyAttackState { get; private set; }

    //public StateMachine EnemyStateMachine { get; private set; }
    //public StateMachine EnemyStateMachine { get; private set; }

    public event Action OnMove;
    public event Action<Vector3> OnRotation;
    public event Action OnFire;


    #region MonoBeh
    private void Awake()
    {
        int childrenNum = RouteParent.childCount;
        for (int i = 0; i < childrenNum; i++)
        {
            RoutePoints.Add(RouteParent.GetChild(i).transform);
        }

        _enemyRb = GetComponent<Rigidbody2D>();
        _enemyTransform = GetComponent<Transform>();

        ChaseTriggerArea chaseTriggerArea = GetComponentInChildren<ChaseTriggerArea>();
        chaseTriggerArea.OnTriggetEnter += TriggetEnemyChase;
        chaseTriggerArea.OnTriggetExit += DisableEnemyChase;

        AttackTriggerArea attackTriggerArea = GetComponentInChildren<AttackTriggerArea>();
        attackTriggerArea.OnTriggetEnter += EnableAttack;
        attackTriggerArea.OnTriggetExit += DisableAttack;

        EnemyStateMachine = new StateMachine();
        EnemyIdolState = new IdolState(this, EnemyStateMachine);
        EnemyPatrolState = new PatrolState(this, EnemyStateMachine);
        EnemyChaseState = new ChaseState(this, EnemyStateMachine);
        EnemyAttackState = new AttackState(this, EnemyStateMachine);

        EnemyStateMachine.Initialize(EnemyIdolState);
    }


    private void FixedUpdate()
    {
        EnemyStateMachine.CurrentState.LogicUpdate();
        EnemyStateMachine.CurrentState.BehaviorUpdate();
    }
    #endregion


    #region methods
    public void Move()
    {
        OnMove?.Invoke();
    }

    public void Rotate(Vector3 direction)
    {
        OnRotation?.Invoke(direction);
    }

    public void Fire()
    {
        OnFire.Invoke();
    }

    private void TriggetEnemyChase(IDamagable damagable, Transform transform)
    {
        if (damagable.UnitFraction == TargetFraction)
        {
            CurrentTargetTransform = transform;
        }
    }

    private void DisableEnemyChase(Transform targetTransform)
    {
        if (targetTransform = CurrentTargetTransform)
        {
            CurrentTargetTransform = null;
        }
    }

    private void EnableAttack(Transform targetTransform)
    {
        IsAttacking = true;
    }

    private void DisableAttack(Transform targetTransform)
    {
        IsAttacking = false;
    }
    #endregion
}

