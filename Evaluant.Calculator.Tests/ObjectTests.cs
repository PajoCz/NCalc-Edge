using NUnit.Framework;

namespace NCalc.Tests
{
    [TestFixture]
    public class ObjectTests
    {
        [Test]
        public void ObjectPlusObjectTest()
        {
            var e = new Expression("[x] + [y]")
            {
                Parameters =
                {
                    ["x"] = new MyObject(10),
                    ["y"] = new MyObject(2)
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as MyObject, "Must return type MyObject");
            Assert.AreEqual(12, (actual as MyObject).Num);
        }

        [Test]
        public void ObjectMinusObjectTest()
        {
            var e = new Expression("[x] - [y]")
            {
                Parameters =
                {
                    ["x"] = new MyObject(10),
                    ["y"] = new MyObject(2)
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as MyObject, "Must return type MyObject");
            Assert.AreEqual(8, (actual as MyObject).Num);
        }

        [Test]
        public void ObjectMultiplyObjectTest()
        {
            var e = new Expression("[x] * [y]")
            {
                Parameters =
                {
                    ["x"] = new MyObject(10),
                    ["y"] = new MyObject(2)
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as MyObject, "Must return type MyObject");
            Assert.AreEqual(20, (actual as MyObject).Num);
        }

        [Test]
        public void ObjectDivideObjectTest()
        {
            var e = new Expression("[x] / [y]")
            {
                Parameters =
                {
                    ["x"] = new MyObject(10),
                    ["y"] = new MyObject(2)
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as MyObject, "Must return type MyObject");
            Assert.AreEqual(5, (actual as MyObject).Num);
        }

        [Test]
        public void ObjectPlusDecimalTest()
        {
            var e = new Expression("[x] + [y]")
            {
                Parameters =
                {
                    ["x"] = new MyObject(10),
                    ["y"] = 2m
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as MyObject, "Must return type MyObject");
            Assert.AreEqual(12, (actual as MyObject).Num);
        }
    }

    public class MyObject
    {
        public decimal Num { get; set; }

        public MyObject(decimal num)
        {
            Num = num;
        }

        public static MyObject operator +(MyObject x, MyObject y)
        {
            return new MyObject(x.Num + y.Num);
        }

        public static MyObject operator +(MyObject x, decimal y)
        {
            return new MyObject(x.Num + y);
        }

        public static MyObject operator -(MyObject x, MyObject y)
        {
            return new MyObject(x.Num - y.Num);
        }

        public static MyObject operator *(MyObject x, MyObject y)
        {
            return new MyObject(x.Num * y.Num);
        }

        public static MyObject operator /(MyObject x, MyObject y)
        {
            return new MyObject(x.Num / y.Num);
        }
    }
}
