using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;

public class testing_score
{
    // A Test behaves as an ordinary method
    [Test]
    public void testing_score()
    {
        // Use the Assert class to test conditions
        int testScore = UiManager.UpdateScore(5);
        Assert.AreEqual(5, testScore);
    }
}
