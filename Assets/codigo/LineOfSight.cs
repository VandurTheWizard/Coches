using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class LineOfSight : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float detection_delay = 0.5f;
    [Range(0, 360)]
    [SerializeField] private int visionAngle;

    private Collider player_collider;
    [HideInInspector] public SphereCollider detection_collider; // Make public for Gizmos, but hide from general Inspector
    private Coroutine detect_player;
    private bool playerVisible = false; // Add a boolean to track player visibility

    private void Awake()
    {
        detection_collider = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered detection range");
            target = other.gameObject;
            detect_player = StartCoroutine(DetectPlayer());
            player_collider = other;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
            StopCoroutine(detect_player);
            playerVisible = false; // Player is no longer visible when exiting trigger
            Debug.Log("Player exited detection range");
        }
    }

    IEnumerator DetectPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(detection_delay);
            if (target == null || player_collider == null) // Check if target or collider is unexpectedly null
            {
                playerVisible = false; // Player not visible if target is lost
                continue; // Skip visibility check if no target
            }

            Vector3[] points = GetBoundingPoints(player_collider.bounds);
            int points_hidden = 0;

            foreach (Vector3 point in points)
            {
                Vector3 target_direction = point - transform.position;
                float target_distance = Vector3.Distance(transform.position, point);
                float target_angle = Vector3.Angle(target_direction, transform.forward);

                if (IsPointCovered(target_direction, target_distance) || target_angle > visionAngle)
                    ++points_hidden;
            }

            if (points_hidden >= points.Length)
            {
                playerVisible = false; // Player is hidden
                Debug.Log("Player is hidden");
            }
            else
            {
                playerVisible = true; // Player is visible
                Debug.Log("Player is visible");
            }
        }
    }

    private bool IsPointCovered(Vector3 target_direction, float target_distance)
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, target_direction, detection_collider.radius);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Cover"))
            {
                float cover_distance = Vector3.Distance(transform.position, hit.point);
                if (cover_distance < target_distance)
                    return true;
            }
        }
        return false;
    }

    private Vector3[] GetBoundingPoints(Bounds bounds)
    {
        Vector3[] bounding_points =
        {
            bounds.min,
            bounds.max,
            new Vector3( bounds.min.x, bounds.min.y, bounds.max.z ),
            new Vector3( bounds.min.x, bounds.max.y, bounds.min.z ),
            new Vector3( bounds.max.x, bounds.min.y, bounds.min.z ),
            new Vector3( bounds.min.x, bounds.max.y, bounds.max.z ),
            new Vector3( bounds.max.x, bounds.min.y, bounds.max.z ),
            new Vector3( bounds.max.x, bounds.max.y, bounds.min.z )
        };
        return bounding_points;
    }

    // **Public function to check if the player is currently visible**
    public bool IsPlayerVisible()
    {
        return playerVisible;
    }
}