using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPressurePlateScript : MonoBehaviour
{
    public PlayerMovement player;
    public FloorRobotEnemyScript[] enemies;
    public MetalCrateScript crate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        enemies[0] = GameObject.FindGameObjectWithTag("Enemy").GetComponent<FloorRobotEnemyScript>();
        enemies[1] = GameObject.FindGameObjectWithTag("Enemy").GetComponent<FloorRobotEnemyScript>();
        crate = GameObject.FindGameObjectWithTag("Crate").GetComponent<MetalCrateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.PlayerGravityButtonFlip();
        enemies[0].EnemyGravityButtonFlip();
        enemies[1].EnemyGravityButtonFlip();
        crate.CrateGravityButtonFlip();
    }

 //private void OnTriggerExit2D(Collider2D collision)
 // {
 //     player.PlayerGravityButtonFlip();
//      enemies[0].EnemyGravityButtonFlip();
//      enemies[1].EnemyGravityButtonFlip();
//      crate.CrateGravityButtonFlip();
//  }
}
