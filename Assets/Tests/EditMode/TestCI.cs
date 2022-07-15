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
    [Test]
    public void generate_number_2_then_number_3_and_4_cant_generate()
    {
        var spawner2 = new GameObject();
        var _spawner2 = spawner2.AddComponent<Spawner>();
        _spawner2.lastNumber = 2;
        int testNumber = _spawner2.GenerateNumber(false);
        Assert.IsTrue((testNumber != 3) && (testNumber != 4));
        
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public void more_than_3_obstacles_time_not_one(int number)
    { 
        var timerObj = new GameObject();
        var timer = timerObj.AddComponent<Time_Speed_Controller>();
        timer.changeSpeed(true);
        timer.currentObstaclesRemain = number;
        timer.DecreaseTime();
        Assert.AreNotEqual(Time.deltaTime,1);
    }
}
