using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int numberAsteroidL;
    public int numberAsteroidB;

    public GameObject asteroidL;
    public GameObject asteroidB;

    int score;

    public float spawnDistance = 15.0f;

    public float trajectoryVariance = 15.0f;

    public List<Vector3> position = new List<Vector3>();

    public Sprite[] asteroidSprite;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score++;
            CheckScore();
        }
    }


    public int scoreDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        /*if (GameManager.instance.loop == 1)
        {
            scoreDifficulty = 3;
        }
        else if (GameManager.instance.loop > 1)
        {
            scoreDifficulty = 5;
        }*/

        InstantiateRandomAsteroid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InstantiateRandomAsteroid()
    {
        
        
        for (int i = 0; i < numberAsteroidL; i++)
        {
            int index = Random.Range(0, position.Count);
            
            Instantiate(asteroidL, position[index], Quaternion.Euler(90, 0, 0));
            asteroidL.GetComponent<Asteroid>().SetTrajectory();
            position.Remove(position[index]);          
        }
        for (int i = 0; i < numberAsteroidB; i++)
        {
            int index = Random.Range(0, position.Count);

            Instantiate(asteroidB, position[index], Quaternion.Euler(90, 0, 0));
            asteroidL.GetComponent<Asteroid>().SetTrajectory();
            position.Remove(position[index]);
        }



    }

    public void CheckScore()
    {
        if (score == scoreDifficulty)
        {
            Debug.Log("win");
        }
    }
}