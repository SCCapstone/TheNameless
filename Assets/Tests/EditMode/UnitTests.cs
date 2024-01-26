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
}
