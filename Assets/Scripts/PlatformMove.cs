using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] GameObject end;
    [SerializeField] float speed = 10f;
    [SerializeField] float delay = 1f;
    [SerializeField] GameObject platform;
    
    private Vector3 targetPosition;

    void Start()
    {
        platform.transform.position = start.transform.position;
        targetPosition = end.transform.position;
        StartCoroutine(PlatformMove());
    }
    // Update is called once per frame
    IEnumerator PlatformMove()
    {
        while (true)
        {
            while ((targetPosition - platform.transform.position).sqrMagnitude > 0.01f)
            {
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            targetPosition = targetPosition == start.transform.position ? end.transform.position : start.transform.position;
            yield return new WaitForSeconds(delay);
        }
    }
}
