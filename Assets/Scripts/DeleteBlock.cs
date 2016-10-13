using UnityEngine;
using System.Collections;

public class DeleteBlock : MonoBehaviour
{
    
    public GameObject DeleteWall;
    public GameObject OtherDeleteWall;
    public GameObject MoveWall;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(DeleteWall);
            Destroy(OtherDeleteWall);
            MoveWall.transform.position = new Vector3(27, -3, 0);
           
        }
        
    }
    
    
}
   

