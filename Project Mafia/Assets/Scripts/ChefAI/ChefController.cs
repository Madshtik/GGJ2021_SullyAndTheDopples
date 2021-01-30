using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefController : MonoBehaviour
{
    public List<Transform> rotationPoints = new List<Transform>();
    public Transform rotObj;

    public float rotationSmoothTime;

    float delayTime;

    void Start()
    {
        delayTime = Random.Range(5, 15);
        StartCoroutine("RotateWithDelay", delayTime);
    }

    void Update()
    {
        Debug.Log(delayTime);

        RotateToRotObj();
    }

    IEnumerator RotateWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            MoveToPoint();
            delayTime = Random.Range(3, 9);
        }
    }

    void MoveToPoint()
    {
        int ranPoint;

        for (int i = 0; i < rotationPoints.Count; i++)
        {
            ranPoint = Random.Range(0, rotationPoints.Count - 1);

            rotObj.position = rotationPoints[ranPoint].position;
        }
    }

    void RotateToRotObj()
    {
        Quaternion lookRotation = Quaternion.LookRotation((rotObj.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSmoothTime * Time.deltaTime);
    }
}
