using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class MissionControllerTest
{
    [Test]
    public void FailMissionsOnHoldTestMethod()
    {
        Queue<IMission> missionQueue = new Queue<IMission>();

        missionQueue.Enqueue(new Easy(12.5));
        missionQueue.Enqueue(new Hard(56));
        missionQueue.Enqueue(new Hard(5));

        Assert.AreEqual(3, missionQueue.Count);
    }
}