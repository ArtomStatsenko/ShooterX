﻿using System;
using UnityEngine;


namespace StatsenkoAA
{
    [Serializable]
    public struct SerializableGameObject
    {
        public string Name;
        public bool IsEnable;
        public SerializableVector3 Position;
        public SerializableQuaternion Rotation;
        public SerializableVector3 Scale;

        public override string ToString()
        {
            return $"Name = {Name}; IsEnable = {IsEnable}; Position = ({Position});";
        }
    }

    [Serializable]
    public struct SerializableVector3
    {
        public float X;
        public float Y;
        public float Z;
        public SerializableVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static implicit operator Vector3(SerializableVector3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator SerializableVector3(Vector3 value)
        {
            return new SerializableVector3(value.x, value.y, value.z);
        }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}, Z = {Z}";
        }
    }

    [Serializable]
    public struct SerializableQuaternion
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public SerializableQuaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator Quaternion(SerializableQuaternion value)
        {
            return new Quaternion(value.X, value.Y, value.Z, value.W);
        }

        public static implicit operator SerializableQuaternion(Quaternion value)
        {
            return new SerializableQuaternion(value.x, value.y, value.z, value.w);
        }

        public override string ToString()
        {
            return $"X = {X}; Y = {Y}; Z = {Z}; W = {W};";
        }
    }
}