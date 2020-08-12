using Newtonsoft.Json;
using Serialization.Attribute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialization
{
    /// <summary>
    /// universal sterilizer
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class Serializator<T> where T : ISerializable
    {
        private Type _type;
        /// <summary>
        /// A wrapper for the version of the class. Serializes the generic type
        /// </summary>
        [Serializable]
        public class SerializeWrapper
        {
            public double _version;
            public T _type = default;
            public List<T> _collection = null;

            /// <summary>
            /// Constructor for generic type T
            /// </summary>
            /// <param name="type">Generic user type</param>
            public SerializeWrapper(T type)
            {
                _type = type;
                _version = SetVersion(typeof(T));
            }

            /// <summary>
            /// Constructor for ICollection<T>
            /// </summary>
            /// <param name="collection">ICollection generic type</param>
            public SerializeWrapper(ICollection<T> collection)
            {
                _collection = (List<T>)collection;
                _version = SetVersion(typeof(T));
            }
            /// <summary>
            /// Empty default constructor
            /// </summary>
            public SerializeWrapper() { }

            /// <summary>
            /// Install version of the generic type
            /// </summary>
            /// <param name="type">Generic type</param>
            /// <returns>Class version</returns>
            private double SetVersion(Type type)
            {
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);

                foreach (System.Attribute attr in attrs)
                {
                    if (attr is ClassVersion)
                        return ((ClassVersion)attr).version;
                }
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Return a deserialized object from the SerializeWrapper
        /// </summary>
        /// <param name="wrapper">Deserialized data</param>
        /// <returns>Generic type ICollection<T> or T </returns>
        private object GetObjectFromWrapper(SerializeWrapper wrapper)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(typeof(T));

            double version = 0;
            foreach (System.Attribute attr in attrs)
            {
                if (attr is ClassVersion)
                {
                    version = ((ClassVersion)attr).version;
                    break;
                }
            }
            if (wrapper._version <= version)
            {
                if (wrapper._collection != null && wrapper._collection.Count > 0)
                    return wrapper._collection;
                wrapper._type ??= default;
                if (wrapper._type is null || wrapper._type is 0)
                    throw new Exception("File error.");
                return wrapper._type;
            }
            else
                throw new ArgumentException("The current version of the class is less than the version written to the file.");

            throw new ArgumentNullException();
        }

        /// <summary>
        /// Base class of the serializer. Accepts the type of object to serialize.
        ///     Checks for attributes ClassVersion, Serializable and interface ISerializable
        /// </summary>
        /// <param name="type">ICollection<T> or T type of the generic collection</param>
        public Serializator(Type type)
        {
            Type[] interfaces = type.GetInterfaces();
            System.Attribute[] attributes = System.Attribute.GetCustomAttributes(type);

            Type genericType;

            bool isCollection = interfaces.Any(i => i == typeof(ICollection<T>));

            if (isCollection)
                genericType = typeof(T);
            else
            {
                if (typeof(T) == type)
                    genericType = type;
                else
                    throw new ArgumentException("Wrong type of argument.");
            }

            bool typeIsSerializableAttribute = System.Attribute.GetCustomAttributes(genericType).
                Any(i => i is SerializableAttribute);
            bool typeIsISerializable = genericType.GetInterfaces().
                Any(i => i == typeof(ISerializable));
            bool typeIsClassVersionAttribute = System.Attribute.GetCustomAttributes(genericType).
                Any(i => i is ClassVersion);

            if (typeIsISerializable)

                if (typeIsSerializableAttribute)

                    if (typeIsClassVersionAttribute)
                        _type = type;
                    else throw new ArgumentException("Must have the ClassVersion attribure.");
                else
                    throw new ArgumentException("Must have the Serializable attribure.");
            else
                throw new ArgumentException("Must be inherited from the ISerializable.");
        }

        #region ICollection Serialization

        /// <summary>
        /// Serialize ICollection<T> to Json file
        /// </summary>
        /// <param name="collection">Serializable ICollection<T></param>
        /// <param name="path">Path to Serialization</param>
        public void ToJson(ICollection<T> collection, string path)
        {
            var serializationObject = new SerializeWrapper(collection);
            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(JsonConvert.SerializeObject(serializationObject, Formatting.Indented));
            }
        }

        /// <summary>
        /// Serialize ICollection<T> to Xml file
        /// </summary>
        /// <param name="collection">Serializable ICollection<T></param>
        /// <param name="path">Path to Serialization</param>
        public void ToXml(ICollection<T> collection, string path)
        {
            var serializationObject = new SerializeWrapper(collection);

            XmlSerializer formatter = new XmlSerializer(typeof(SerializeWrapper));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, serializationObject);
            }
        }

        /// <summary>
        /// Serialize ICollection<T> to Bin file
        /// </summary>
        /// <param name="collection">Serializable ICollection<T></param>
        /// <param name="path">Path to Serialization</param>
        public void ToBin(ICollection<T> collection, string path)
        {
            var serializationObject = new SerializeWrapper(collection);

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path,
                                                  FileMode.Create,
                                                  FileAccess.Write,
                                                  FileShare.Write))
            {
                formatter.Serialize(stream, serializationObject);
            }
        }

        #endregion ICollection Serialization

        #region ICollection Deserialization

        /// <summary>
        ///  Deserialize ICollection<T> from Json file
        /// </summary>
        /// <param name="path">Path to Deserialization</param>
        /// <returns>Deserializable ICollection<T></returns>
        public ICollection<T> FromJsonCollection(string path)
        {
            SerializeWrapper deserializeResult;
            using (StreamReader r = new StreamReader(path))
            {
                deserializeResult = JsonConvert.DeserializeObject<SerializeWrapper>(r.ReadToEnd());
            }
            return (ICollection<T>)GetObjectFromWrapper(deserializeResult);
        }

        /// <summary>
        ///  Deserialize ICollection<T> from Xml file
        /// </summary>
        /// <param name="path">Path to Deserialization</param>
        /// <returns>Deserializable ICollection<T></returns>
        public ICollection<T> FromXmlCollection(string path)
        {
            SerializeWrapper deserializeResult;
            XmlSerializer formatter = new XmlSerializer(typeof(SerializeWrapper));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                deserializeResult = (SerializeWrapper)formatter.Deserialize(fs);
            }
            return (ICollection<T>)GetObjectFromWrapper(deserializeResult);
        }


        /// <summary>
        ///  Deserialize ICollection<T> from Bin file
        /// </summary>
        /// <param name="path">Path to Deserialization</param>
        /// <returns>Deserializable ICollection<T></returns>
        public ICollection<T> FromBinCollection(string path)
        {
            SerializeWrapper deserializeResult;

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path,
                                                  FileMode.Open,
                                                  FileAccess.Read,
                                                  FileShare.Read))
            {
                deserializeResult = (SerializeWrapper)formatter.Deserialize(stream);
            }
            return (ICollection<T>)GetObjectFromWrapper(deserializeResult);
        }

        #endregion ICollection Deserialization

        #region Serialization
        /// <summary>
        /// Serialize genric type T to Json file
        /// </summary>
        /// <param name="collection">Serializable generic type T</param>
        /// <param name="path">Path to Serialization</param>
        public void ToJson(T obj, string path)
        {
            var serializationObject = new SerializeWrapper(obj);

            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(JsonConvert.SerializeObject(serializationObject, Newtonsoft.Json.Formatting.Indented));
            }
        }

        /// <summary>
        /// Serialize genric type T to Xml file
        /// </summary>
        /// <param name="collection">Serializable generic type T</param>
        /// <param name="path">Path to Serialization</param>
        public void ToXml(T obj, string path)
        {
            var serializationObject = new SerializeWrapper(obj);
            XmlSerializer formatter = new XmlSerializer(typeof(SerializeWrapper));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, serializationObject);
            }
        }

        /// <summary>
        /// Serialize genric type T to Bin file
        /// </summary>
        /// <param name="collection">Serializable generic type T</param>
        /// <param name="path">Path to Serialization</param>
        public void ToBin(T obj, string path)
        {
            var serializationObject = new SerializeWrapper(obj);
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path,
                                                  FileMode.Create,
                                                  FileAccess.Write,
                                                  FileShare.Write))
            {
                formatter.Serialize(stream, serializationObject);
            }
        }

        #endregion Serialization

        #region Deserialization

        /// <summary>
        ///  Deserialize generic type T from Json file
        /// </summary>
        /// <param name="path">Path to Deserialization</param>
        /// <returns>Deserializable generic type T</returns>
        public T FromJson(string path)
        {
            SerializeWrapper deserializeResult;
            using (StreamReader r = new StreamReader(path))
            {
                deserializeResult = JsonConvert.DeserializeObject<SerializeWrapper>(r.ReadToEnd());
            }
            return (T)GetObjectFromWrapper(deserializeResult);
        }

        /// <summary>
        ///  Deserialize generic type T from Xml file
        /// </summary>
        /// <param name="path">Path to Deserialization</param>
        /// <returns>Deserializable generic type T</returns>
        public T FromXml(string path)
        {
            SerializeWrapper deserializeResult;
            XmlSerializer formatter = new XmlSerializer(typeof(SerializeWrapper));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                deserializeResult = (SerializeWrapper)formatter.Deserialize(fs);
            }
            return (T)GetObjectFromWrapper(deserializeResult);
        }

        /// <summary>
        ///  Deserialize generic type T from Bin file
        /// </summary>
        /// <param name="path">Path to Deserialization</param>
        /// <returns>Deserializable generic type T</returns>
        public T FromBin(string path)
        {
            SerializeWrapper deserializeResult;
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path,
                                                  FileMode.Open,
                                                  FileAccess.Read,
                                                  FileShare.Read))
            {
                deserializeResult = (SerializeWrapper)formatter.Deserialize(stream);
            }
            return (T)GetObjectFromWrapper(deserializeResult);
        }

        #endregion Deserialization
    }
}