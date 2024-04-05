using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPMI
{
    public class Vector3
    {
        private string name;
        public float x, y, z;

        public Vector3()
        {
            name = "V3_DEFAULT";
            x = 0; 
            y = 0; 
            z = 0;
        }

        public Vector3(string name, float x)
        {
            this.name = name;
            this.x = x;
            y = z = 0;
        }

        public Vector3(string name, float x, float y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            z = 0;
        }

        public Vector3(string name, float x, float y, float z)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float Modulo()
        {
            float mod = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2) + Mathf.Pow(z, 2));

            return mod;
        }

        public void Add(RPMI.Vector3 other)
        {
            x += other.x;
            y += other.y;
            z += other.z;
        }

        public void Add(float x, float y, float z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
        }

        public void Mul(float esc)
        {
            x *= esc;
            y *= esc;
            z *= esc;
        }

        public string GetName()
        {
            return name;
        }
    }
}
