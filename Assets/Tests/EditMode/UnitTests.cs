using NUnit.Framework;
using UnityEngine;

public class UnitTests
{
    [Test]
    public void VolumeToStringTest()
    {
        // Initialize vars
        var gameObject = new GameObject();
        var soundSettings = gameObject.AddComponent<SoundSettings>();

        // The VolumeToString function should round down the float value
        // to the nearest integer, convert it to a string, and append a
        // '%' symbol.
        var volume = soundSettings.VolumeToString(50.5f);

        // We should be getting the value "50%"
        Assert.AreEqual("50%", volume);
    }

    [Test]
    public void GetSignPositive()
    {

        // Initialize vars
        var gameObject = new GameObject();
        var playerMovement = gameObject.AddComponent<PlayerMovement>();
        var i = 12f;
        var j = 0.5f;

        // Calling the function on i and j should return 1
        Assert.AreEqual(1, playerMovement.GetSign(i));
        Assert.AreEqual(1, playerMovement.GetSign(j));

    }
    
    [Test]
    public void GetSignNegative()
    {

        // Initialize vars
        var gameObject = new GameObject();
        var playerMovement = gameObject.AddComponent<PlayerMovement>();
        var i = -13.4f;
        var j = -0.2f;

        // Calling the function on i and j should return -1
        Assert.AreEqual(-1, playerMovement.GetSign(i));
        Assert.AreEqual(-1, playerMovement.GetSign(j));

    }
    
    [Test]
    public void GetSignZero()
    {

        // Initialize vars
        var gameObject = new GameObject();
        var playerMovement = gameObject.AddComponent<PlayerMovement>();
        var i = 0f;

        // Calling the function on i should return 0
        Assert.AreEqual(0, playerMovement.GetSign(i));

    }
}
