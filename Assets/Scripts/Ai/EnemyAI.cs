using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : AiFiniteStateMachine
{

    public enum FSMState
    {
        None,
        Patrol,
        Chase,
        Attack,
        Dead,
    }

    //private NavMeshAgent[] navAgent;

    public FSMState currentState;

    [SerializeField]
    private float currentSpeed;
    [SerializeField]
    private float currentRotationSpeed;
    [SerializeField]
    private GameObject Bullet;

    private bool bDead;
    [SerializeField]
    private int health;


    new private Rigidbody rigidbody;

    //Initialize the Finite State Machine for the NPC
    protected override void Initialize()
    {
        currentState = FSMState.Patrol;
        currentSpeed = 12.5f;
        currentRotationSpeed = 2.0f;
        bDead = false;
        elapsedTime = 0.0f;
        shootRate = 3.0f;
        health = 100;

        //navAgent = FindObjectsOfType(typeof(NavMeshAgent)) as NavMeshAgent[];

        pointList = GameObject.FindGameObjectsWithTag("PatrolPoint");

        FindNextPoint();

        GameObject objectPlayer = GameObject.FindGameObjectWithTag("Player");

        rigidbody = GetComponent<Rigidbody>();

        playerTransform = objectPlayer.transform;

        turret = gameObject.transform.GetChild(0).transform;
        bulletSpawnPoint = gameObject.transform.GetChild(1).transform;
    }

    //void UpdateTargets(Vector3 targetPosition)
    //{
    // foreach (NavMeshAgent agent in navAgent)
    // {
    // agent.destination = targetPosition;
    // }
    // }


    protected override void FSMUpdate()
    {
        switch (currentState)
        {
            case FSMState.Patrol: UpdatePatrolState(); break;
            case FSMState.Chase: UpdateChaseState(); break;
            case FSMState.Attack: UpdateAttackState(); break;
            case FSMState.Dead: UpdateDeadState(); break;
        }

        elapsedTime += Time.deltaTime;

        if (health <= 0)
        {
            currentState = FSMState.Dead;
        }
    }

    protected void UpdatePatrolState()
    {
        GameObject objectPlayer = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(transform.position, destinationPosition) <= 2.0f)
        {
            FindNextPoint();
        }

        else if (Vector3.Distance(transform.position, playerTransform.position) <= 12.0f) //|| GameObject.Find("Player").GetComponent<PlayerMovement>().beaconActive == true)
        {
            currentState = FSMState.Chase;
        }

        //Turret Rotation
        Quaternion targetRotation = Quaternion.LookRotation(destinationPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * currentRotationSpeed);

        // Forward March
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
    }

    protected void FindNextPoint()
    {
        int rndIndex = Random.Range(0, pointList.Length);
        float rndRadius = 5.0f;
        Vector3 rndPosition = Vector3.zero;
        destinationPosition = pointList[rndIndex].transform.position + rndPosition;

        if (IsInCurrentRange(destinationPosition))
        {
            rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f, Random.Range(-rndRadius, rndRadius));
            destinationPosition = pointList[rndIndex].transform.position + rndPosition;
            Vector3 targetPosition = destinationPosition;
            //UpdateTargets(targetPosition);

        }
    }

    protected bool IsInCurrentRange(Vector3 pos)
    {
        float xPos = Mathf.Abs(pos.x - transform.position.x);
        float zPos = Mathf.Abs(pos.z - transform.position.z);

        if (xPos <= 5 && zPos <= 5)

            return true;

        return false;

    }

    protected void UpdateChaseState()
    {
        currentSpeed = 15.0f;
        destinationPosition = playerTransform.position;

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= 7.0f)
        {
            currentState = FSMState.Attack;
        }
        else if (distance >= 15.0f )// && (GameObject.Find("Player").GetComponent<PlayerMovement>().beaconActive == false))
        {
            currentState = FSMState.Patrol;
        }
        //else if (GameObject.Find("Player").GetComponent<PlayerMovement>().beaconActive == true)
       // {
            //currentState = FSMState.Chase;
        //}

        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
    }

    protected void UpdateAttackState()
    {
        currentSpeed = 7.5f;
        destinationPosition = playerTransform.position;
        Vector3 targetPosition = destinationPosition + new Vector3(1, 0, 1);
        //UpdateTargets(targetPosition);

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance >= 0 && distance < 7)
        {
            Quaternion targetRotation = Quaternion.LookRotation(destinationPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * currentRotationSpeed);

            transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

            currentState = FSMState.Attack;
        }
        else if (distance >= 15)
        {
            currentState = FSMState.Patrol;
        }

        Quaternion turretRotation = Quaternion.LookRotation(destinationPosition - turret.position);

        ShootBullet();
    }

    private void ShootBullet()
    {
        if (elapsedTime >= shootRate)
        {
            Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            elapsedTime = 0.0f;
        }
    }

    protected void UpdateDeadState()
    {
        if (!bDead)
        {
            bDead = true;
            Explode();
        }
    }
    protected void Explode()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health -= collision.gameObject.GetComponent<EnemyProjectile>().damage;
            Debug.Log("Hit");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        FSMUpdate();
    }

    private void FixedUpdate()
    {
        FSMFixedUpdate();
    }
}