using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class QuadTests : MonoBehaviour
{
    [Test]
    public void UnitTestingSimplePasses()
    {
        float large = 1e20f;
        float one = 1;
        Assert.AreEqual(large+one, large);
        Assert.AreEqual(large-one, large);


        QuadFloat largeQuad = new QuadFloat(large);
        QuadFloat oneQuad = new QuadFloat(one);
        QuadFloat smallQuad = new QuadFloat(1e-45f);
        QuadFloat tooSmallQuad = new QuadFloat(1e-46f);
        assertQuadsAreNotEqual(largeQuad + oneQuad, largeQuad);
        assertQuadsAreNotEqual(largeQuad - oneQuad, largeQuad);
        assertQuadsAreNotEqual(largeQuad + smallQuad, largeQuad);
        assertQuadsAreNotEqual(largeQuad - smallQuad, largeQuad);
        assertQuadsAreEqual(largeQuad + tooSmallQuad, largeQuad);
        assertQuadsAreEqual(largeQuad - tooSmallQuad, largeQuad);
    }

    private void assertAlmostEqual(float a, float b, float threshold = 1e-6f)
    {
        Assert.Less(Mathf.Abs(a - b), threshold);
    }
    private void assertAlmostEqual(Complex a, Complex b, float threshold = 1e-6f)
    {
        Assert.Less((a - b).abs(), threshold);
    }

    private void assertAlmostEqual(QuadFloat a, QuadFloat b, float threshold = 1e-6f)
    {
        Assert.Less(Mathf.Abs(a.a - b.a), threshold);
        Assert.Less(Mathf.Abs(a.b - b.b), threshold);
        Assert.Less(Mathf.Abs(a.c - b.c), threshold);
        Assert.Less(Mathf.Abs(a.d - b.d), threshold);
    }

    private void assertQuadsAreEqual(QuadFloat a, QuadFloat b)
    {
        Assert.AreEqual(a.a, b.a);
        Assert.AreEqual(a.b, b.b);
        Assert.AreEqual(a.c, b.c);
        Assert.AreEqual(a.d, b.d);
    }

    private void assertQuadsAreNotEqual(QuadFloat a, QuadFloat b)
    {
        bool allEqual = a.a == b.a && a.b == b.b && a.c == b.c && a.d == b.d;
        Assert.IsFalse(allEqual);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator UnitTestingWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
