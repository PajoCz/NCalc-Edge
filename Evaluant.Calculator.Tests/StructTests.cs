using NUnit.Framework;

namespace NCalc.Tests
{
    [TestFixture]
    public class StructTests
    {
        [Test]
        public void StructPlusStructTest()
        {
            var e = new Expression("[x] + [y]")
            {
                Parameters =
                {
                    ["x"] = new Struct<decimal>(10),
                    ["y"] = new Struct<decimal>(2)
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as Struct<decimal>, "Must return type Struct<decimal>");
            Assert.AreEqual(12, (actual as Struct<decimal>).Num);
        }

        [Test]
        public void StructMinusStructTest()
        {
            var e = new Expression("[x] - [y]")
            {
                Parameters =
                {
                    ["x"] = new Struct<decimal>(10),
                    ["y"] = new Struct<decimal>(2)
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as Struct<decimal>, "Must return type Struct<decimal>");
            Assert.AreEqual(8, (actual as Struct<decimal>).Num);
        }

        [Test]
        public void StructMultiplyStructTest()
        {
            var e = new Expression("[x] * [y]")
            {
                Parameters =
                {
                    ["x"] = new Struct<decimal>(10),
                    ["y"] = new Struct<decimal>(2)
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as Struct<decimal>, "Must return type Struct<decimal>");
            Assert.AreEqual(20, (actual as Struct<decimal>).Num);
        }

        [Test]
        public void StructDivideStructTest()
        {
            var e = new Expression("[x] / [y]")
            {
                Parameters =
                {
                    ["x"] = new Struct<decimal>(10),
                    ["y"] = new Struct<decimal>(2)
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as Struct<decimal>, "Must return type Struct<decimal>");
            Assert.AreEqual(5, (actual as Struct<decimal>).Num);
        }

        [Test]
        public void StructPlusDecimalTest()
        {
            var e = new Expression("[x] + [y]")
            {
                Parameters =
                {
                    ["x"] = new Struct<decimal>(10),
                    ["y"] = 2m
                }
            };

            var actual = e.Evaluate();
            Assert.IsNotNull(actual as Struct<decimal>, "Must return type Struct<decimal>");
            Assert.AreEqual(12, (actual as Struct<decimal>).Num);
        }
    }

    public class Struct<T> where T : struct
    {
        public T Num { get; set; }

        public Struct(T num)
        {
            Num = num;
        }

        public static Struct<T> operator +(Struct<T> x, Struct<T> y)
        {
            return new Struct<T>((dynamic)x.Num + y.Num);
        }

        public static Struct<T> operator +(Struct<T> x, decimal y)
        {
            return new Struct<T>((dynamic)x.Num + y);
        }

        public static Struct<T> operator -(Struct<T> x, Struct<T> y)
        {
            return new Struct<T>((dynamic)x.Num - y.Num);
        }

        public static Struct<T> operator *(Struct<T> x, Struct<T> y)
        {
            return new Struct<T>((dynamic)x.Num * y.Num);
        }

        public static Struct<T> operator /(Struct<T> x, Struct<T> y)
        {
            return new Struct<T>((dynamic)x.Num / y.Num);
        }
    }
}
