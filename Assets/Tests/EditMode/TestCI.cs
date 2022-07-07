using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestCI
{
    // A Test behaves as an ordinary method
    [Test]
    public void RandomNumberInRange()
    {
        var gameobject = new GameObject();
        var spam = gameobject.AddComponent<Spam_Obstacle>();
        spam.duplicateObstacle();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.

        Debug.Log(spam.currentDuplicateNumber);
        Assert.IsTrue((spam.currentDuplicateNumber >= 3) && (spam.currentDuplicateNumber <= spam.maxTimesToDuplicate));
    }

}
