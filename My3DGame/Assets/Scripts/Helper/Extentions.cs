using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace StatsenkoAA
{
    public static partial class Extentions
    {
        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Type must be iserializable");
            }
            if (ReferenceEquals(self, null))
            {
                return default(T);
            }

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T Random<T>(this List<T> list)
        {
            var val = list[UnityEngine.Random.Range(0, list.Count)];

            return val;
        }

        public static bool TryBool(this string self)
        {
            return Boolean.TryParse(self, out var res) && res;
        }


        public static float TrySingle(this string self)
        {
            if (Single.TryParse(self, out var res))
            {
                return res;
            }
            return 0;
        }
    }
}
