using UnityEngine;

public class Roof : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hallo");
            Destroy(this.gameObject);
        }

    }
}