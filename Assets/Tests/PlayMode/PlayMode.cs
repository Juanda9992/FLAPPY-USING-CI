using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayMode
{

    [UnityTest]
    public IEnumerator TestPlayerDeath()
    {
        var character = new GameObject();
        var rb = character.AddComponent<Rigidbody2D>();
        yield return new WaitForSeconds(2);
        Assert.Less(character.transform.position.y,-6);
    }
}
