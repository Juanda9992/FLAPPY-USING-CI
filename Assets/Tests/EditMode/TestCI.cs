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

    [Test]
    [TestCase(1)]
    [TestCase(0.3f)]
    [TestCase(2)]
    [TestCase(0.2f)]
    public void time_greater_than_zero_not_spawn_object(float number)
    {
        var spawner = new GameObject();
        var _spawner = spawner.AddComponent<Spawner>();
        _spawner.currentTimeBetweenSpawn = number;
        _spawner.checkForSpawn();
        Assert.IsFalse(_spawner.spawned);

    }

    
    [Test]
    [TestCase(-1)]
    [TestCase(-0.3f)]
    [TestCase(0)]
    [TestCase(-0.2f)]
    public void time_smaller_than_zero_spawn_object(float number)
    {
        var spawner1 = new GameObject();
        var _spawner1 = spawner1.AddComponent<Spawner>();
        _spawner1.timeBetweenSpawn = number;
        _spawner1.currentTimeBetweenSpawn = number;
        _spawner1.checkForSpawn();
        Assert.IsTrue(_spawner1.spawned);
    }



}
