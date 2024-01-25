using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTests
{
    [UnityTest]
    public IEnumerator MoveLeft()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<Rigidbody2D>();

        player.velocity = PlayerMovement.Move(-1, player.velocity.y);

        player.position += player.velocity; 

        yield return null;

        Assert.AreEqual(new Vector2(-10f, 0), player.position);
    }

    
    [UnityTest]
    public IEnumerator MoveRight()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<Rigidbody2D>();

        player.velocity = PlayerMovement.Move(1, player.velocity.y);

        player.position += player.velocity; 

        yield return null;

        Assert.AreEqual(new Vector2(10f, 0), player.position);
    }
}
