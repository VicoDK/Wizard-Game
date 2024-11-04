using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float speed;
    public float dist;

    bool stunned;
    public float StunTime;

    public void Stun()
    {
        stunned = true;
        Invoke("StopStun", StunTime);

    }

    void StopStun()
    {
        stunned = false;

    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Player.position) > dist && !stunned)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed);
        }
        
        
    }

}
