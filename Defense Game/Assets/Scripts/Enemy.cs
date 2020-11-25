using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float maxSpeed = 4.0f;
    public Transform waypoint;
    public float maxHealth = 100.0f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private float dividedSpeed = 0.0f;
    private bool isDead = false;
    private WaypointManager.Path _path;
    private int _currentWaypoint = 0;
    private float _currentHealth = 0.0f;

    private float deathClipLength;

    private float Enemyspeed;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        if (_agent != null)
        {
            _agent.SetDestination(waypoint.position);
            _agent.speed = maxSpeed;
        }
        dividedSpeed = 1 / maxSpeed;

        AnimationClip[] animations = _animator.runtimeAnimatorController.animationClips;
        if (animations == null || animations.Length <= 0)
        {
            Debug.Log("animations Error");
            return;
        }

        for (int i = 0; i < animations.Length; ++i)
        {
            if (animations[i].name == "Mutant Dying")
            {
                deathClipLength = animations[i].length;
                break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

        if (_path == null || _path.Waypoints == null || _path.Waypoints.Count <= _currentWaypoint)
        {
            return;
        }

        Transform destination = _path.Waypoints[_currentWaypoint];
        _agent.SetDestination(destination.position);

        if ((transform.position - destination.position).sqrMagnitude < 15.0f * 15.0f)
        {
            _currentWaypoint++;
        }
    }



    private void UpdateAnimation()
    {
        Enemyspeed = _agent.velocity.magnitude * dividedSpeed;
        _animator.SetFloat("EnemySpeed", Enemyspeed);
        _animator.SetBool("IsDead", isDead);
    }

    public void Initialize(WaypointManager.Path path)
    {
        _path = path;
    }

    public float GetHealth()
    {
        return _currentHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0.0f)
        {
            StartCoroutine("Kill");
        }
    }

    public IEnumerator Kill()
    {
        isDead = true;

        _agent.speed = 0;
        yield return new WaitForSeconds(deathClipLength);
        Destroy(gameObject);
    }

}
