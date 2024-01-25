using NUnit.Framework;
using UnityEngine;

public class MovementTests
{
    [Test]
    public void MoveLeft()
    {
        Vector2 left = PlayerMovement.Move(-1f, 0f);
        Assert.AreEqual(new Vector2(-10f, 0), left);
    }

    [Test]
    public void MoveRight()
    {
        Vector2 right = PlayerMovement.Move(1f, 0f);
        Assert.AreEqual(new Vector2(10f, 0), right);
    }
}
