using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class FieldOfView : MonoBehaviour
{
    public PlayableDirector director;

    public List<Transform> visibleTargets = new List<Transform>();

    [Header("Public Structs")]
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [Header("Public Variables")]
    public float searchDelay;
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    bool started;

    void Start()
    {
        StartCoroutine("FindTargetWithDelay", searchDelay); 
    }

    void Update()
    {
        if (director.state != PlayState.Playing && started)
        {
            SceneManager.LoadScene(3);
        }
    }

    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    } 

    void FindVisibleTarget()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;

            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle/2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    Debug.Log("Target Found");
                    visibleTargets.Add(target);
                    director.Play();
                    started = true;
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDeg, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDeg += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
    }
}
