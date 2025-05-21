using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PachinkoTesting
{

    // A Test behaves as an ordinary method
    [Test]
    public void PachinkoMinAdd()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score =holes.ScoreAddWithMultiplier(100, 1);

        Assert.AreEqual(score, 100);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoNegAdd()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score = holes.ScoreAddWithMultiplier(-200, 1);

        Assert.AreNotEqual(score, 200);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoMultAdd()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score = holes.ScoreAddWithMultiplier(100, 2);

        Assert.Greater(score, 100);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoScorePenalty()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score =300+ holes.ScoreAddWithMultiplier(-100, 1.5f);

        Assert.Less(score, 200);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoJackpotAdd()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score = holes.ScoreAddWithMultiplier(1000, 1);

        Assert.AreEqual(score, 1000);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoJackpotMultAdd()
    { 
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score = holes.ScoreAddWithMultiplier(1000, 2);

        Assert.AreEqual(score, 2000);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoNegMult()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score = holes.ScoreAddWithMultiplier(200, -2);

        Assert.AreNotEqual(score, -200);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoNegMultNegWinnings()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score = holes.ScoreAddWithMultiplier(-100, -1);

        Assert.AreEqual(score, -100);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoStartingScorePlusWinnings()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score = 100+holes.ScoreAddWithMultiplier(1000, 2);

        Assert.AreEqual(score, 2100);

        // Use the Assert class to test conditions
    }

    [Test]
    public void PachinkoMaxWinningsPlusScore()
    {
        GameObject scoreboard = new GameObject("Score");
        Holes holes = scoreboard.AddComponent<Holes>();

        float score = 100+holes.ScoreAddWithMultiplier(1000, 5);

        Assert.AreEqual(score, 5100);

        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

}
