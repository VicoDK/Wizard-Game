using UnityEngine;

public class yell : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<spawner>().triggered(collision);
        
    }

}
