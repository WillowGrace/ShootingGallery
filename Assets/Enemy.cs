using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    private Vector3 startingPosition;
    private Vector3 roamPosition;

    public UnityEngine.AI.NavMeshAgent _navMeshAgent;
    public Transform gotoPoint;
    private Transform raycastPoint;

    public RaycastHit cast;

    Rigidbody rb;

    public float health;
    public float streagnth;
    public float speed;

    public float allowedRange;
    public float targetDistance;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPositoon();

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;

    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.SetDestination(gotoPoint.position);
        RaycastHit hit;
        Vector3 shootRay = raycastPoint.TransformDirection(Vector3.down) * 100;
        if (Physics.Raycast(raycastPoint.position, shootRay, out hit, 100))
        {
            print(hit.point);
        }
        Vector3 moveTowrdsPosition = hit.point;
        moveTowrdsPosition.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, moveTowrdsPosition, _navMeshAgent.speed);

    }

    public static Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 GetRoamingPositoon()
    {
        return startingPosition + GetRandomDirection() * Random.Range(10f, 70f);
    }


    //has health
    public void TakeDamage()
    {
        health--;
    }
    void OnTriggerEnter(Collider collid)
    {
        if (collid.name == "Bullet")
        {
            TakeDamage();
        }
    }
        //has a gun
        //find player
        //shoot at player

        private void Attack()
    {

    }
}

   
