using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelRequirement
{
    public string levelName;
    public bool levelCompleted;
    public bool allEnemiesKilled;
    public int requiredPoints;
    public bool requiredPointsPassed;
    

    public LevelRequirement(string LevelName, bool AllEnemiesKilled, int RequiredPoints, bool LevelCompleted)
    {
        this.levelName = LevelName;
        this.allEnemiesKilled = AllEnemiesKilled;
        this.requiredPoints = RequiredPoints;
        this.levelCompleted = LevelCompleted;
    }
}

public class Scene1LevelsRequirementManager : MonoBehaviour
{
    public static Scene1LevelsRequirementManager instance { get; set; }
    public LevelRequirement[] LR_Array;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
