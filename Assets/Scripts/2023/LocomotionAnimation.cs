﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class LocomotionAnimation : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    public float turnSmoothing = 15f;           // The amount of smoothing applied to the player's turning using spherical interpolation.
    public float speedDampTime = 0.1f;          // The approximate amount of time it takes for the speed parameter to reach its value upon being set.
    public float slowingSpeed = 0.175f;         // The speed the player moves as it reaches close to it's destination.
    public float turnSpeedThreshold = 0.5f;     // The speed beyond which the player can move and turn normally.    
    private const float stopDistanceProportion = 0.1f;    // The proportion of the nav mesh agent's stopping distance within which the player stops completely.

    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        // The player will be rotated by this script so the nav mesh agent should not rotate it.
        navMeshAgent.updateRotation = false;
    }


    private void OnAnimatorMove()
    {
        // Set the velocity of the nav mesh agent (which is moving the player) based on the speed that the animator would move the player.
        navMeshAgent.velocity = animator.deltaPosition / Time.deltaTime;
    }

    public void SetNavMeshDestination(Transform transform)
    {
        targetTransform = transform;
        navMeshAgent.SetDestination(targetTransform.position);
    }


    // Update is called once per frame
    private void Update()
    {
        navMeshAgent.isStopped = false;

        // If the nav mesh agent is currently waiting for a path, do nothing.
        if (navMeshAgent.pathPending)
            return;

        // Cache the speed that nav mesh agent wants to move at.
        float speed = navMeshAgent.desiredVelocity.magnitude;

        // If the nav mesh agent is very close to it's destination, call the Stopping function.
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance * stopDistanceProportion)
        {
            Stopping(out speed);
        }
        // Otherwise, if the nav mesh agent is close to it's destination, call the Slowing function.
        else if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            Slowing(out speed, navMeshAgent.remainingDistance);
        }
        // Otherwise, if the nav mesh agent wants to move fast enough, call the Moving function.
        else if (speed > turnSpeedThreshold)
        {
            Moving();
        }

        // Set the animator's Speed parameter based on the (possibly modified) speed that the nav mesh agent wants to move at.
        animator.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
    }


    // This is called when the player is moving normally.  In such cases the player is moved by the nav mesh agent, but rotated by this function.
    private void Moving()
    {
        // Create a rotation looking down the nav mesh agent's desired velocity.
        Quaternion targetRotation = Quaternion.LookRotation(navMeshAgent.desiredVelocity);

        // Interpolate the player's rotation towards the target rotation.
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
    }

    // This is called when the nav mesh agent is very close to it's destination.
    private void Stopping(out float speed)
    {
        // Stop the nav mesh agent from moving the player.
        navMeshAgent.isStopped = true;

        // Set the player's position to the destination.
        if (targetTransform != null)
            transform.position = targetTransform.position;

        // Set the speed (which is what the animator will use) to zero.
        speed = 0f;
    }

    // This is called when the nav mesh agent is close to its destination but not so close it's position should snap to it's destination.
    private void Slowing(out float speed, float distanceToDestination)
    {
        // Although the player will continue to move, it will be controlled manually so stop the nav mesh agent.
        navMeshAgent.isStopped = true;

        // Find the distance to the destination as a percentage of the stopping distance.
        float proportionalDistance = 1f - distanceToDestination / navMeshAgent.stoppingDistance;

        // The target rotation is the rotation of the target if the player is headed to a target, or the player's own rotation if not.        
        Quaternion targetRotation = targetTransform ? targetTransform.rotation : transform.rotation;

        // Interpolate the player's rotation between itself and the target rotation based on how close to the destination the player is.
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, proportionalDistance);

        // Move the player towards the destination by an amount based on the slowing speed.
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, slowingSpeed * Time.deltaTime);

        // Set the speed (for use by the animator) to a value between slowing speed and zero based on the proportional distance.
        speed = Mathf.Lerp(slowingSpeed, 0f, proportionalDistance);
    }
}