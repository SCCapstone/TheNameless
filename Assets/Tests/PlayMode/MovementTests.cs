using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MovementTests
{
    [UnityTest]
    public IEnumerator MoveLeft()
    {
        SceneManager.LoadScene("Testing");
        yield return null;

        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);
        
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);

        yield return new WaitForSeconds(0.5f);

        var initialPosition = player.GetPosition();

        for (float t = 0f; t < 0.5f; t += Time.deltaTime) {
            yield return null;
            player.Move(-1);
        }

        Assert.IsTrue(player.GetPosition().x < initialPosition.x);

    }

    
    [UnityTest]
    public IEnumerator MoveRight()
    {
        SceneManager.LoadScene("Testing");
        yield return null;

        var playerObject = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(playerObject);
        
        var player = playerObject.GetComponent<PlayerMovement>();
        Assert.IsNotNull(player);

        yield return new WaitForSeconds(0.5f);

        var initialPosition = player.GetPosition();

        for (float t = 0f; t < 0.5f; t += Time.deltaTime) {
            yield return null;
            player.Move(1);
        }

        Assert.IsTrue(player.GetPosition().x > initialPosition.x);
    }
}
