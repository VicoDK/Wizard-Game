using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    
    public Camera cam;
    public GameObject[] children;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetActive(false);
        }
        for (int i = 0; i <= 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("check");
        Debug.Log("triggerd");
        if (other.CompareTag("Player"))
        {
            Invoke("spawn", 0.2f);
            cameraposition();

        }
        
        if (other.CompareTag("roomspawn"))
        {
            Debug.Log(other);
            Destroy(other.gameObject);
        }


    }
    void spawn()
    {
        
        Debug.Log("player");
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetActive(true);
        }
        
    }

    void cameraposition()
    {
        cam = Camera.main;
        Debug.Log(cam);
        cam.transform.position = this.transform.position + new Vector3(0,0,-10);
    }
}
