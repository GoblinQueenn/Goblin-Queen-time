using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;

    public Transform playerSpawnTransform;

    // List of player Controllers
    public List<PlayerController> players = new List<PlayerController>();

    //awake is called when the object is first created - before even start can run!
    private void Awake()
    {
        // If intance doesn't exist yet
        if (Instance == null)
        {
            Instance = this;
            // Don't destroy this object if a new scene is loaded
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If instance does already have a Game Manager
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        // Spawn the Player Controller at (o, o, o) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        // Spawn our Pawn and connect it to our Controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        // Get the Player Controller compont and pawn
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        // hook them up
        newController.pawn = newPawn;
    }
}
