using UnityEngine;

public class spawner : MonoBehaviour
{
    
    public Camera cam = Camera.main;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggerd");
        cameraposition();
        //if (other.CompareTag("Player"))
        //{
            Debug.Log("player");
            for (int i = 0; i <= 4; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

        //}
    }

    void cameraposition()
    {
        cam.transform.position = this.transform.position + new Vector3(0,0,-10);
    }
}
