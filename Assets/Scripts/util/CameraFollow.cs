namespace util
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        Vector3 offset;
        public float speed = 1;
        Vector3 targetPos;
        bool _move = false;

        void Awake()
        {
            offset = target.position - transform.position;
        }

        void Update()
        {
            Move();
        }

        void OnGizmosSelectDraw()
        {

        }

        void Move()
        {
            targetPos = target.position - offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime*speed);
        }
    }
}