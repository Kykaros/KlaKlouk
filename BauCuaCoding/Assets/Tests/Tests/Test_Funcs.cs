using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_Funcs
{
    // A Test behaves as an ordinary method
    [Test]
    public void Test_Mascot()
    {
        List<int> Expect_Result = new List<int>() { 0, 1, 2, 3, 4, 5 };
        int Result = Functions.RandomMascot();
        if(Expect_Result.Contains(Result))
        {
            Assert.Pass("[Test_Funcs][Test_Mascot]: Passed !");
        }
        else
        {
            Assert.Fail("[Test_Funcs][Test_Mascot]: Failed, because actual value is {0}", Result);
        }
    }

    [Test]
    public void Test_GetResultDice()
    {
        Dictionary<string, int> Results = new Dictionary<string, int>()
        {
            {"D1",0 }
            ,{"D2",2 }
            ,{"D3",5}
        };
    }
}
