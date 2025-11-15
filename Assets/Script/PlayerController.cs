using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // Mảng các checkpoint trên đường đua
    public Vector3[] checkPoints;

    private int current = 0; // checkpoint hiện tại

    // Update is called once per frame
    void Update()
    {
        if (checkPoints.Length == 0) return;

        // vị trí đích
        Vector3 target = checkPoints[current];

        // di chuyển xe về phía checkpoint
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        // tính khoảng cách đến target
        float distance = (transform.position - target).magnitude;

        // nếu đến nơi → chuyển sang checkpoint tiếp theo
        if (distance < 0.5f)
        {
            current++;

            // nếu vượt quá mảng → quay về 0
            if (current >= checkPoints.Length)
                current = 0;
        }
    }
}
