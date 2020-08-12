using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Serialization.Attribute;

namespace Serialization
{
    [Serializable]
    [ClassVersion(version = 1)]
    public class Radec : ISerializable
    {
        public double jail;
        public double jail2;

        private double srik = 2000;

        public Radec()
        {
        }

        protected Radec(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            srik = (double)info.GetValue("srik", typeof(double));
            jail = (double)info.GetValue("jail", typeof(double));
            jail2 = (double)info.GetValue("jail2", typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("srik", srik);
            info.AddValue("jail", jail);
            info.AddValue("jail2", jail2);

            
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var fff = new Radec() { jail = 22 };
            var ggg = new List<Radec>();
            ggg.Add(fff);


            Serializator<Radec> serializator = new Serializator<Radec>(typeof(List<Radec>));
            Serializator<Radec> serializator1 = new Serializator<Radec>(typeof(Radec));

            serializator1.ToBin(fff, "Bin.bin");
            serializator1.ToJson(fff, "Json.json");
            serializator1.ToXml(fff, "Xml.xml");

            var radec1 = serializator.FromBin("Bin.bin");
            var radec2 = serializator.FromJson("Json.json");
            var radec3 = serializator.FromXml("Xml.xml");
        }
    }
}