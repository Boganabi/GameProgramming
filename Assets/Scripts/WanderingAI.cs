using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    public float speed = 3.0f;
    public float obstacleRange = 1.5f;

    // current state
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // check if alive first before moving
        if (isAlive)
        {
            // move forward
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        // create ray from the wandering game object, pointed in the same diretion as the game object
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit; // contains hit information

        // performs a raycast in every direction around us
        if(Physics.SphereCast(ray, 0.75f, out hit))
        {
            // reference to game object in our spherecast
            GameObject hitObject = hit.transform.gameObject;

            // if object hit was a player character, shoot a fireball
            // else, wander as normal
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if(fireball == null)
                {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }
            else if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    // function for other classes to set dead or alive when hit
    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }
}
