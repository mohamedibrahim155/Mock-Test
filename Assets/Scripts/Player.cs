using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float horizontalAxis;
   public float moveSpeed;
    Transform raycastTransform;
    LayerMask obstacle;
    RaycastHit hitInfo;
    float temp;
   public Quaternion targetRotation;
    public enum rotate  {forward,backward };
    public rotate RotationDirection;
    Vector3 rotateDir;
    public Material red, blue, yellow,Green;
    public GameObject ParticlePrefab;
    public Transform particleSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward *moveSpeed*Time.deltaTime);

        switch (RotationDirection)
        {
            case rotate.forward:
              rotateDir=  Vector3.forward;
                break;
            case rotate.backward:
              rotateDir=  Vector3.back;
                break;
            default:
                break;
        }
       
        Inputs();

        // Checking angle and rotating the tile
        if (hitInfo.collider!=null)
        {
            if (Quaternion.Angle(hitInfo.transform.parent.rotation, targetRotation) > 0.5f)
            {

                hitInfo.transform.parent.Rotate(rotateDir * 6f, Space.World);

            }
        }

        if (transform.position.y<-4f)
        {
            SceneManager.LoadScene(2);
        }
                            
      

    }


    void Inputs()
    {
        //If mouse clicked 
        if (Input.GetMouseButtonDown(0))
        {
            // ray to identify which to rotate  and setting roation value in Z axis
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                temp = hitInfo.transform.parent.localEulerAngles.z + 90;   
                targetRotation = Quaternion.Euler(hitInfo.transform.parent.rotation.x, hitInfo.transform.parent.rotation.y, temp);
                RotationDirection = rotate.forward;
                

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            // ray to identify which to rotate  and setting roation value in Z axis
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                temp = hitInfo.transform.parent.localEulerAngles.z - 90;
                targetRotation = Quaternion.Euler(hitInfo.transform.parent.rotation.x, hitInfo.transform.parent.rotation.y, temp);
                RotationDirection = rotate.backward;


            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // checking if the player collides with wrong color and decreasing the score
        if (collision.transform.GetComponent<MeshRenderer>().material.color!= this.GetComponent<MeshRenderer>().material.color)
        {
           
            GameObject temp = Instantiate(ParticlePrefab, particleSpawn.position, Quaternion.identity);
            Destroy(temp, 1f);
            this.GetComponent<MeshRenderer>().material = collision.transform.GetComponent<MeshRenderer>().material;
            Scoremanager.instance.score -= 100f;
        }
        else
        {
            Scoremanager.instance.score += 5f;
        }
      
    }
    
}
