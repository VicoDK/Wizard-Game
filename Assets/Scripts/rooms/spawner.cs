using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    
    public Camera cam;
    public GameObject[] children;
    public bool check = false;

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

        Debug.Log("triggerd");
        if (other.CompareTag("Player")&&check == false)
        {
            Invoke("spawn", 0.2f);

        }
        


    }

    void spawn()
    {
        check = true;
        Debug.Log("player");
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetActive(true);
        }
        cameraposition();
    }

    void cameraposition()
    {
        cam = Camera.main;
        Debug.Log(cam);
        cam.transform.position = this.transform.position + new Vector3(0,0,-10);
    }
}
