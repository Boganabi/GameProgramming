using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    // private variable assigned in the inspector window with what needs to spawn
    [SerializeField] GameObject enemyPrefab; // the [SerializeField] tag makes this private variable show in the inspector, as a normal private variable wont show

    // private variable containing reference to enemy instance in the scene
    // could make this an array to spawn multiple, but need a number to keep track of how many there are
    // consider using object pooling!
    private GameObject enemy;

    private float cooldownForSpawning = 3f;
    private float timeSinceLastSpawn = 0;

    // Start is called before the first frame update
    void Start() {
        // spawn one at start of game
        enemy = Instantiate(enemyPrefab) as GameObject;
        enemy.transform.position = new Vector3(0, 1, 0);
        float angle = Random.Range(0, 360);
        enemy.transform.Rotate(0, angle, 0);
        timeSinceLastSpawn = 0;
    }

    // Update is called once per frame
    void Update() {
        // if there isn't an enemy, spawn one
        if (enemy == null) {
            if (timeSinceLastSpawn >= cooldownForSpawning) // delay 3 seconds before spawning new one
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(0, 1, 0);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
                timeSinceLastSpawn = 0;
            }
            timeSinceLastSpawn += Time.deltaTime;
        }
    }
}
