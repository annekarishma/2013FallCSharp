public void VehiclesCanTransform()
{
var v = new Vehicle();
v.Transform();

Assert.IsTrue(v.Log.Contains("autobot"));
}

[TestMethod]
public void Linq101()
{
var numbers = new[] { 0, 1, 2, 3, 4, 5 };
var actual = new List<int>();
foreach (var x in numbers)
{
if (x % 2 ==0) actual.Add(x);
}
Assert.AreEqual(3, actual.Count);
var actual2 = numbers.Where(i => i % 2 == 0).Reverse();
Assert.ArweEqual(3, actual2.Count());
}
}
}
