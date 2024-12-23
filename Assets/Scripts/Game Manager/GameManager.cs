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
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;

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
        ActivateTitleScreen();
        // mapGenerator.GenerateMap();

        // SpawnPlayer();
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
            newPawn.controller = newController;

            newCameraObj.transform.parent = newPawnObj.transform;
        }
    }

    public void RespawnPlayer(Controller playerToRespawn)
    {
        if (playerToRespawn.lives > 0)
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
                GameObject newPawnObj = Instantiate(tankPawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

                Pawn newPawn = newPawnObj.GetComponent<Pawn>();

                playerToRespawn.pawn = newPawn;

                newPawn.controller = playerToRespawn;
            }
        }
    }

    // Helper function for deativating all game states
    private void DeactivateAllStates()
    {
        // Deactivate all your states
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }

    // Game state transition functions


    public void ActivateTitleScreen()
    {
        // Deactivate all states
        DeactivateAllStates();
        // Activate the title screen
        TitleScreenStateObject.SetActive(true);
    }

    public void ActivateOptionsScreen()
    {
        // Deacivate all states
        DeactivateAllStates();
        // Activate
        OptionsScreenStateObject.SetActive(true);
    }
    public void ActivateMainMenu()
    {
        // Deacivate all states
        DeactivateAllStates();
        // Activate
        MainMenuStateObject.SetActive(true);
    }
    public void ActivateCredits()
    {
        // Deacivate all states
        DeactivateAllStates();
        // Activate
        CreditsScreenStateObject.SetActive(true);
    }
    public void ActivateGamePlay()
    {
        // Deacivate all states
        DeactivateAllStates();
        // Activate
        GameplayStateObject.SetActive(true);
        // Start level
        mapGenerator.GenerateMap();

        SpawnPlayer();
    }
    public void ActivateGameOver()
    {
        // Deacivate all states
        DeactivateAllStates();
        // Activate
        GameOverScreenStateObject.SetActive(true);
    }

    // Stub helper function to Toggle Map Of Day
    public void ActivateMapOfTheDay()
    {
        if (mapGenerator != null)
        {
            // Activate map of the day
            mapGenerator.isMapOfTheDay = true;
            mapGenerator.isMapSeed = false;
            mapGenerator.isCurrentTime = false;
        }
    }

    // Stub helper function to Toggle Random Map
    public void ActivateRandomMap()
    {
        if (mapGenerator != null)
        {
            // Activate Random Map
            mapGenerator.isMapOfTheDay = false;
            mapGenerator.isMapSeed = false;
            mapGenerator.isCurrentTime = true;
        }
    }

    // Stub helper function to enble Random Map Seed
    public void ActivateRandomMapSeed()
    {
         if (mapGenerator != null)
        {
            // Activate Random Map Seed
            mapGenerator.isMapOfTheDay = false;
            mapGenerator.isMapSeed = true;
            mapGenerator.isCurrentTime = false;
        }
    }
}
