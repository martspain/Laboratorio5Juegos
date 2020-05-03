using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    public GameObject reproducer;
    Rigidbody rb;
    private AudioSource WaterDropSFX;
    // Start is called before the first frame update
    void Start()
    {
        if (reproducer)
            WaterDropSFX = reproducer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo)) 
            {
                if (hitInfo.collider.CompareTag("Prop")) 
                {
                    rb = hitInfo.collider.GetComponent<Rigidbody>();

                    if (rb)
                        rb.AddForce(-hitInfo.normal * 5, ForceMode.Impulse);

                    if (reproducer) 
                    {
                        if (!WaterDropSFX.isPlaying)
                            WaterDropSFX.Play();
                    }
                        


                }
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
