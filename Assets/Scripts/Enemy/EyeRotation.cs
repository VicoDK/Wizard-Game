using System.IO;
using UnityEngine;
using Pathfinding;

public class EyeRotation : MonoBehaviour
{
    void Update()
    {

        Vector2 fireDir = (GetComponentInParent<AIPath>().destination - this.transform.position).normalized;

        float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
