using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocator : MonoBehaviour
{
    public static EnemyLocator Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public Enemy[] GetEnemies()
    {
        return FindObjectsOfType<Enemy>();        
    }


}
