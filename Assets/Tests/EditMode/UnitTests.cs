using NUnit.Framework;
using UnityEngine;

public class UnitTests
{
    [Test]
    public void VolumeString()
    {
        var gameObject = new GameObject();
        var soundSettings = gameObject.AddComponent<SoundSettings>();

        var volume = soundSettings.VolumeToString(50f);

        Assert.AreEqual("50%", volume);
    }
}
