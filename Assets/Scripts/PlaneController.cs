using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlaneController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public GameObject FailPanel;
    
   
    // rotasyon
   
    public float speed;
    public float maxHeight = 60f; // maksimimum yükseklik
    public float velocityY = 5;  // inip çýkýlacak hýz
    public float rotationSpeed;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed); // Z ekseninde ilerlemek için 

        if (Input.GetMouseButton(0))
        {
            rigidBody.velocity = transform.up * velocityY;
            //transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, rotationSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(330, 0, 0), rotationSpeed * Time.deltaTime);

        }
        else
        {

            rigidBody.velocity = -transform.up * velocityY;
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(30, 0, 0), rotationSpeed * Time.deltaTime);

        }


    }






    private void OnTriggerEnter(Collider other)
    {
        print("Alana Girdi" + other.name);
        Time.timeScale = 0;
        
        FailPanel.SetActive(true);

    }

    public void ReplayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
