using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BehavioralTests
{
    // REMOVE COMMENTS TO RUN TESTS

    [UnityTest]
    public IEnumerator MoveLeft()
    {
        // Open the 'Testing' scene
        SceneManager.LoadScene("Testing");
        yield return null;

        // Get the player object and make sure it's not null
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);
        
        // Get the instance of PlayerMovement that's applied to the player
        // object and make sure it's not null
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);
        
        // Allow the player half a second to land on the ground in the scene
        yield return new WaitForSeconds(0.5f);

        // Get the user's initial position for comparison
        var initialPosition = player.GetPosition();

        // In the period of half a second, simulate a '<-' button press
        for (float t = 0f; t < 0.5f; t += Time.deltaTime) {
            yield return null;
            player.Move(-1, false);
        }

        // Check that the player's position is to the left of their initial position
        Assert.IsTrue(player.GetPosition().x < initialPosition.x);

    }

    
    [UnityTest]
    public IEnumerator MoveRight()
    {
        // Open the 'Testing' scene
        SceneManager.LoadScene("Testing");
        yield return null;

        // Get the player object and make sure it's not null
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);
        
        // Get the instance of PlayerMovement that's applied to the player
        // object and make sure it's not null
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);

        // Allow the player half a second to land on the ground in the scene
        yield return new WaitForSeconds(0.5f);

        // Get the user's initial position for comparison
        var initialPosition = player.GetPosition();

        // In the period of half a second, simulate a '->' button press
        for (float t = 0f; t < 0.5f; t += Time.deltaTime) {
            yield return null;
            player.Move(1, false);
        }

        // Check that the player's position is to the right of their initial position
        Assert.IsTrue(player.GetPosition().x > initialPosition.x);
    }

    
    [UnityTest]
    public IEnumerator JumpRight()
    {
        // Open the 'Testing' scene
        SceneManager.LoadScene("Testing");
        yield return null;

        // Get the player object and make sure it's not null
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);
        
        // Get the instance of PlayerMovement that's applied to the player
        // object and make sure it's not null
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);

        // Allow the player half a second to land on the ground in the scene
        yield return new WaitForSeconds(0.5f);

        // Get the user's initial position for comparison
        var initialPosition = player.GetPosition();

        // Simulate a player jump
        yield return null;
        player.Jump(10f);
        
        // In the period of half a second, simulate a '->' button press
        for (float t = 0f; t < 0.5f; t += Time.deltaTime) {
            yield return null;
            player.Move(1, false);
        }

        // Check that the player's position is to the right and above their initial position
        Assert.IsTrue(player.GetPosition().x > initialPosition.x && player.GetPosition().y > initialPosition.y);
    }


    [UnityTest]
    public IEnumerator JumpLeft()
    {
        // Open the 'Testing' scene
        SceneManager.LoadScene("Testing");
        yield return null;

        // Get the player object and make sure it's not null
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);
        
        // Get the instance of PlayerMovement that's applied to the player
        // object and make sure it's not null
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);
        
        // Allow the player half a second to land on the ground in the scene
        yield return new WaitForSeconds(0.5f);

        // Get the user's initial position for comparison
        var initialPosition = player.GetPosition();

        // Simulate a player jump
        yield return null;
        player.Jump(10f);

        // In the period of half a second, simulate a '<-' button press
        for (float t = 0f; t < 0.5f; t += Time.deltaTime) {
            yield return null;
            player.Move(-1, false);
        }

        // Check that the player's position is to the left and above their initial position
        Assert.IsTrue(player.GetPosition().x < initialPosition.x && player.GetPosition().y > initialPosition.y);

    }

    
    [UnityTest]
    public IEnumerator ReverseGravity()
    {
        // Open the 'Testing' scene
        SceneManager.LoadScene("Testing");
        yield return null;

        // Get the player object and make sure it's not null
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);
        
        // Get the instance of PlayerMovement that's applied to the player
        // object and make sure it's not null
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);
        
        // Allow the player half a second to land on the ground in the scene
        yield return new WaitForSeconds(0.5f);

        // Get the user's initial position & the initial value of gravity for
        // comparison
        var initialPosition = player.GetPosition();
        var initialGravity = Physics2D.gravity;

        // Simulate reversing gravity
        yield return null;
        player.ReverseGravity();

        // Wait a second for the player to move
        yield return new WaitForSeconds(1f);

        // Check that the player's position is above their initial position and
        // Physics2D.gravity has been reversed
        Assert.IsTrue(
            player.GetPosition().y > initialPosition.y &&
            Physics2D.gravity.y == -initialGravity.y
        );
    }


    [UnityTest]
    public IEnumerator PlayerDeath()
    {
        // Open the 'Testing' scene
        SceneManager.LoadScene("Testing");
        yield return null;

        // Get the player object and make sure it's not null
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);
        
        // Get the instances of PlayerMovement & PlayerHealth that are applied
        // to the player object and make sure they're not null
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);
        var health = playerObject.GetComponent<PlayerHealth>();
        Assert.IsNotNull(health);
        
        // Allow the player half a second to land on the ground in the scene
        yield return new WaitForSeconds(0.5f);

        // In the period of two seconds, simulate a '->' button press
        for (float t = 0f; t < 2f; t += Time.deltaTime) {
            yield return null;
            player.Move(1, false);
        }

        // Check that the player's health has been reduced to zero
        Assert.IsTrue(health.currentHealth == 0);
    }


    [UnityTest]
    public IEnumerator PressurePlatePress()
    {
        // Open the 'Testing' scene
        SceneManager.LoadScene("Testing");
        yield return null;

        // Get the player object and make sure it's not null
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);

        // Get the button object and make sure it's not null
        var buttonObject = GameObject.Find("Button");
        Assert.IsNotNull(buttonObject);
        
        // Get the instance of PlayerMovement that's applied to the player
        // object and make sure it's not null
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);

        // Get the instance of the PressurePlateVertical script that's applied
        // to the button object and make sure it's not null
        var button = buttonObject.GetComponent<PressurePlateVertical>();
        Assert.IsNotNull(button);
        
        // Allow the player half a second to land on the ground in the scene
        yield return new WaitForSeconds(0.5f);

        // Simulate a player jump
        yield return null;
        player.Jump(10f);

        // In the period of half a second, simulate a '<-' button press
        for (float t = 0f; t < 0.75f; t += Time.deltaTime) {
            yield return null;
            player.Move(-1, false);
        }

        // Wait a second for the player to land on the pressure plate
        yield return new WaitForSeconds(1f);

        // Check that the button of the pressure plate is currently pressed
        Assert.IsTrue(button.pressed);
    }
}
