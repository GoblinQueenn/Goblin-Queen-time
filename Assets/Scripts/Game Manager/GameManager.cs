using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject cameraPrefab;

    // Player camra offsets
    public float cameraOffsetBack;
    public float cameraOffsetUp;

    //public Transform playerSpawnTransform;

    // Reference to our Map Generator
    public MapGenerator mapGenerator;

    // List of player Controllers
    public List<PlayerController> players = new List<PlayerController>();

    // List of AI Controllers
    public List<AIController> enemies = new List<AIController>();

    // List of Pawn SpawnPoints
    public PawnSpawnPoint[] pawnSpawnPoints;

    // Game States
    public GameObject TitleScreenStateObject;


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
        mapGenerator.GenerateMap();

        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        Transform spawnPoint = null;
       
       // Find PawnSpawnPoints by type
       pawnSpawnPoints = FindObjectsByType<PawnSpawnPoint>(FindObjectsSortMode.None);
       

        if (pawnSpawnPoints.Length > 0)
        {
            // Randomly select a spawnPoint
            spawnPoint = pawnSpawnPoints[Random.Range(0, pawnSpawnPoints.Length)].transform;
        }

        if (spawnPoint != null)
        {
            // Spawn the Player Controller at (o, o, o) with no rotation
            GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            // Spawn our Pawn and connect it to our Controller
            GameObject newPawnObj = Instantiate(tankPawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

            // Spawn our camera behind the tank (UPDATE TO REMOVE MAGIC NUMBERS)
            GameObject newCameraObj = Instantiate(cameraPrefab, spawnPoint.position + (Vector3.back * cameraOffsetBack) + (Vector3.up * cameraOffsetUp), spawnPoint.rotation) as GameObject;

            // Get the Player Controller compont and pawn
            Controller newController = newPlayerObj.GetComponent<Controller>();
            Pawn newPawn = newPawnObj.GetComponent<Pawn>();

            newPawnObj.AddComponent<NoiseMaker>();
            newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
            newPawn.noiseMakerVolume = 3;

            // hook them up
            newController.pawn = newPawn;

            newCameraObj.transform.parent = newPlayerObj.transform;
        }
    }
}
