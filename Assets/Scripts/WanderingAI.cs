using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    public float speed = 3.0f;
    public float obstacleRange = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        transform.Translate(0, 0, speed * Time.deltaTime);

        // create ray from the wandering game object, pointed in the same diretion as the game object
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit; // contains hit information

        // performs a raycast in every direction around us
        if(Physics.SphereCast(ray, 0.75f, out hit))
        {
            if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
