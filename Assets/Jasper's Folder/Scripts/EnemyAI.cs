using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    // References
    [Header("References")]
    public Transform player;
    public Transform[] searchPoints;
    public LayerMask obstructEnemyVision;

    // Parameters
    [Header("Parameters")]
    public float moveSpeed = 3f;
    public float sightRange = 10f;
    Vector2 lastKnownPosition;

    float stateTimer;
    public enum State { Searching, SpottedPlayer, ChasingPlayer, LostPlayer, ReturnToSearch }
    State currentState = State.Searching;

    void Update()
    {
        // State machine
        switch (currentState)
        {
            // Searching for the player
            case State.Searching:
                SearchForPlayer();
                if (CanSeePlayer())
                {
                    currentState = State.SpottedPlayer;
                    stateTimer = 1f; // Time to react
                }
            break;

            // Player spotted, brief delay before chasing
            case State.SpottedPlayer:
                stateTimer -= Time.deltaTime;
                if (stateTimer <= 0)
                {
                    currentState = State.ChasingPlayer;
                }
            break;

            // Chasing the player
            case State.ChasingPlayer:
                lastKnownPosition = player.position;
                MoveTowards(lastKnownPosition);

                if (!CanSeePlayer())
                {
                    currentState = State.LostPlayer;
                    stateTimer = 2; // Time to "guess" the player's location
                }
                    
                break;

            // Lost sight of the player, moving to last known position
            case State.LostPlayer:
                lastKnownPosition = player.position;
                MoveTowards(lastKnownPosition);

                stateTimer -= Time.deltaTime;

                if (stateTimer <= 0)
                {
                    currentState = State.ReturnToSearch;
                    stateTimer = 2; // Time to return to searching
                }
            break;

            // Returning to search behavior
            case State.ReturnToSearch:
                stateTimer -= Time.deltaTime;

                if (stateTimer <= 0)
                {
                    currentState = State.Searching;
                }
            break;
        }

        /// <summary>
        /// Checks if the enemy can see the player
        /// </summary>
        bool CanSeePlayer()
        {
            Vector2 direction = player.position - transform.position;

            if (direction.magnitude > sightRange)
                return false;

            // Debug raycast to check for obstructions
            Debug.DrawRay(transform.position, direction.normalized * sightRange, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, sightRange, obstructEnemyVision);

            if (hit.collider != null && hit.collider.transform != player)
            {
                Debug.DrawRay(transform.position, direction.normalized * sightRange, Color.green);
                return false; // Obstructed
            }

            Debug.DrawRay(transform.position, direction.normalized * sightRange, Color.green);
            return true; // Clear line of sight
        }

        /// <summary>
        /// Search logic while not chasing the player
        /// </summary>
        void SearchForPlayer()
        {
            List<Transform> visiblePoints = new List<Transform>();
            float nearestDistance = float.MaxValue;
            Transform nearestPoint = null;

            foreach (Transform point in searchPoints)
            {
                Vector2 direction = point.position - transform.position;

                // Debug ray toward search point
                Debug.DrawRay(transform.position, direction.normalized * direction.magnitude, Color.blue);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, Mathf.Infinity, obstructEnemyVision);

                // If the ray hits the point without obstruction, it's visible
                if (hit.collider != null || hit.collider.transform == point)
                {
                    visiblePoints.Add(point);

                    float dist = direction.magnitude;
                    if (dist < nearestDistance)
                    {
                        nearestDistance = dist;
                        nearestPoint = point;
                    }

                    // Debug ray to visible point
                    Debug.DrawRay(transform.position, direction.normalized * direction.magnitude, Color.green);
                }
                else
                {
                    // Debug ray to obstructed point
                    Debug.DrawRay(transform.position, direction.normalized * direction.magnitude, Color.red);
                }
            }

            if (visiblePoints.Count == 0)
                return; // No visible points

            // If multiple points are visible, pick randomly
            Transform target = (visiblePoints.Count > 1) ? visiblePoints[Random.Range(0, visiblePoints.Count)] : nearestPoint;

            MoveTowards(target.position);
        }

        /// <summary>
        /// 
        /// </summary>
        void MoveTowards(Vector2 target)
        {
            // Desired direction toward target
            Vector2 direction = (target - (Vector2)transform.position).normalized;

            // Cast a short ray forward to detect obstacles
            float avoidDistance = 1f; // Distance to check for obstacles
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, avoidDistance, obstructEnemyVision);

            if (hit.collider != null)
            {
                // Debug ray showing obstacle detection
                Debug.DrawRay(transform.position, direction * avoidDistance, Color.red);

                // Possible detour directions (perpendicular to current direction)
                Vector2 left = new Vector2(-direction.y, direction.x);
                Vector2 right = new Vector2(direction.y, -direction.x);
                Vector2 up = Vector2.up;
                Vector2 down = Vector2.down;

                // Check which detour direction is clear
                List<Vector2> options = new List<Vector2>();

                if (!Physics2D.Raycast(transform.position, left, avoidDistance, obstructEnemyVision))
                {
                    options.Add(left);
                }
                else if (!Physics2D.Raycast(transform.position, right, avoidDistance, obstructEnemyVision))
                {
                    options.Add(right);
                }
                else if (!Physics2D.Raycast(transform.position, up, avoidDistance, obstructEnemyVision))
                {
                    options.Add(up);
                }
                else if (!Physics2D.Raycast(transform.position, down, avoidDistance, obstructEnemyVision))
                {
                    options.Add(down);
                }

                if (options.Count > 0)
                {
                    // Pick a random clear direction
                    direction = options[Random.Range(0, options.Count)];

                    // Debug ray showing chosen detour
                    Debug.DrawRay(transform.position, direction * avoidDistance, Color.green);
                }
                else
                {
                    // If no detours are clear, stop moving
                    direction = Vector2.zero;
                }
            }
            else
            {
                // Debug ray showing clear path
                Debug.DrawRay(transform.position, direction * avoidDistance, Color.green);
            }

            // Apply movement
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, moveSpeed * Time.deltaTime);

            // Debug line showing movement direction
            Debug.DrawLine(transform.position, (Vector2)transform.position + direction, Color.blue);
        }
    }
}
