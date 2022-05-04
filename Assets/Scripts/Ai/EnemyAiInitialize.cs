using UnityEngine.AI;
using UnityEngine;

public class EnemyAiInitialize : AiFiniteStateMachine
{

    public NavMeshAgent agent;

    public string tagNameofPatrolPoints;

    public FSMState currentState;

    public float currentSpeed;

    public float currentRotationSpeed;

    public GameObject enemyProjectile;

    public bool bDead;

    public bool RangedEnemy;

    public bool MeleeEnemy;

    public float meleeHitDelay;

    public float elapsedTimeRanged;

    public float elapsedTimeMelee;


    


    new private Rigidbody rigidbody;
    protected override void Initialize()
    {
        currentState = FSMState.Patrol;
        currentSpeed = 150.0f;
        currentRotationSpeed = 7.0f;
        bDead = false;
        elapsedTimeMelee = 0.0f;
        elapsedTimeRanged = 0.0f;
        shootRate = 2.0f;
        meleeHitDelay = 3.0f;


        pointList = GameObject.FindGameObjectsWithTag(tagNameofPatrolPoints);

        GetComponent<EnemyAiFindNextPoint>().FindNextPoint();

        GameObject objectPlayer = GameObject.FindGameObjectWithTag("Player");

        rigidbody = GetComponent<Rigidbody>();

        playerTransform = objectPlayer.transform;

        bulletSpawnPoint = gameObject.transform.GetChild(0).transform;
    }

    protected override void FSMUpdate()
    {
        switch (currentState)
        {
            case FSMState.Patrol: GetComponent<EnemyAiPatrolState>().UpdatePatrolState(); break;
            case FSMState.Chase: GetComponent<EnemyAiChaseState>().UpdateChaseState(); break;
            case FSMState.Attack: GetComponent<EnemyAiAttackState>().UpdateAttackState(); break;
            case FSMState.Dead: GetComponent<EnemyAiDeadState>().UpdateDeadState(); break;
        }
        elapsedTimeMelee += Time.deltaTime;
        elapsedTimeRanged += Time.deltaTime;


        if (bDead == true)
        {
            currentState = FSMState.Dead;
        }
    }

    private void Start()
    {
        Initialize();
    }
    void Update()
    {
        FSMUpdate();
    }
    private void FixedUpdate()
    {
        FSMFixedUpdate();
    }
}
