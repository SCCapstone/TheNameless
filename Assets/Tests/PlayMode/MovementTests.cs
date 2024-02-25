using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MovementTests
{
    // REMOVE COMMENTS TO RUN TESTS

    // [UnityTest]
    // public IEnumerator MoveLeft()
    // {
    //     // Open the 'Testing' scene
    //     SceneManager.LoadScene("Testing");
    //     yield return null;

    //     // Get the player object and make sure it's not null
    //     var playerObject = GameObject.FindGameObjectWithTag("Player");
    //     Assert.IsNotNull(playerObject);
        
    //     // Get the instance of PlayerMovement that's applied to the player
    //     // object and make sure it's not null
    //     var player = playerObject.GetComponent<PlayerMovement>();
    //     Assert.IsNotNull(player);
        
    //     // Allow the player half a second to land on the ground in the scene
    //     yield return new WaitForSeconds(0.5f);

    //     // Get the user's initial position for comparison
    //     var initialPosition = player.GetPosition();

    //     // In the period of half a second, simulate a '<-' button press
    //     for (float t = 0f; t < 0.5f; t += Time.deltaTime) {
    //         yield return null;
    //         player.Move(-1, false);
    //     }

    //     // Check that the player's position is to the left of their initial position
    //     Assert.IsTrue(player.GetPosition().x < initialPosition.x);

    // }

    
    // [UnityTest]
    // public IEnumerator MoveRight()
    // {
    //     // Open the 'Testing' scene
    //     SceneManager.LoadScene("Testing");
    //     yield return null;

    //     // Get the player object and make sure it's not null
    //     var playerObject = GameObject.FindGameObjectWithTag("Player");
    //     Assert.IsNotNull(playerObject);
        
    //     // Get the instance of PlayerMovement that's applied to the player
    //     // object and make sure it's not null
    //     var player = playerObject.GetComponent<PlayerMovement>();
    //     Assert.IsNotNull(player);

    //     // Allow the player half a second to land on the ground in the scene
    //     yield return new WaitForSeconds(0.5f);

    //     // Get the user's initial position for comparison
    //     var initialPosition = player.GetPosition();

    //     // In the period of half a second, simulate a '->' button press
    //     for (float t = 0f; t < 0.5f; t += Time.deltaTime) {
    //         yield return null;
    //         player.Move(1, false);
    //     }

    //     // Check that the player's position is to the right of their initial position
    //     Assert.IsTrue(player.GetPosition().x > initialPosition.x);
    // }
}
