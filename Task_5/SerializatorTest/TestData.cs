using Serialization.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SerializatorTest
{
    #region Test Classes

    [Serializable]
    [ClassVersion(version = 1)]
    public class TestClass1 : ISerializable
    {
        public string field1;
        public int field2;
        public double field3;

        public TestClass1()
        {
        }

        protected TestClass1(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            field1 = (string)info.GetValue("field1", typeof(string));
            field2 = (int)info.GetValue("field2", typeof(int));
            field3 = (double)info.GetValue("field3", typeof(double));
        }

        public override bool Equals(object obj)
        {
            return obj is TestClass1 @class &&
                   field1 == @class.field1 &&
                   field2 == @class.field2 &&
                   field3 == @class.field3;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("field1", field1);
            info.AddValue("field2", field2);
            info.AddValue("field3", field3);
        }
    }

    [Serializable]
    [ClassVersion(version = 1)]
    public class TestClass2 : ISerializable
    {
        public List<string> field1;
        public int[] field2;

        public TestClass2()
        {
        }

        protected TestClass2(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            field1 = (List<string>)info.GetValue("field1", typeof(List<string>));
            field2 = (int[])info.GetValue("field2", typeof(int[]));
        }

        public override bool Equals(object obj)
        {
            return obj is TestClass2 @class &&
                   Enumerable.SequenceEqual(field1, @class.field1) &&
                   Enumerable.SequenceEqual(field2, @class.field2);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("field1", field1);
            info.AddValue("field2", field2);
        }
    }

    [ClassVersion(version = 1)]
    public class TestClassErrorSerializable : ISerializable
    {
        public string field1;
        public int field2;
        public double field3;

        public TestClassErrorSerializable()
        {
        }

        protected TestClassErrorSerializable(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            field1 = (string)info.GetValue("field1", typeof(string));
            field2 = (int)info.GetValue("field2", typeof(string));
            field3 = (double)info.GetValue("field3", typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("field1", field1);
            info.AddValue("field2", field2);
            info.AddValue("field3", field3);
        }
    }

    [Serializable]
    public class TestClassErrorClassVersion : ISerializable
    {
        public string field1;
        public int field2;
        public double field3;

        public TestClassErrorClassVersion()
        {
        }

        protected TestClassErrorClassVersion(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            field1 = (string)info.GetValue("field1", typeof(string));
            field2 = (int)info.GetValue("field2", typeof(string));
            field3 = (double)info.GetValue("field3", typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("field1", field1);
            info.AddValue("field2", field2);
            info.AddValue("field3", field3);
        }
    }

    #endregion Test Classes

}