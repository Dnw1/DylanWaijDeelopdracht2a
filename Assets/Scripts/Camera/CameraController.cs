using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private float speed;
    private float velocity;

    [SerializeField] private GameObject target;
    private Vector3 targetPosition;

    void Awake()
    {
        targetPosition = transform.position;
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 direction = (target.transform.position - posNoZ);

            velocity = direction.magnitude * 5f;

            targetPosition = transform.position + (direction.normalized * velocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
    }
}
