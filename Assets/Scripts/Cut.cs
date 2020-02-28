using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class PPoint
{
    public double x, y, z;
    public PPoint(double nx, double ny, double nz)
    {
        x = nx; y = ny; z = nz;
    }
    public PPoint(Vector3 vec)
    {
        x = vec.x; y = vec.y; z = vec.z;
    }
    public double Len()
        => Math.Sqrt(x * x + y * y + z * z);
    public Vector3 Vec()
    => new Vector3((float)x, (float)y, (float)z);
    public static PPoint operator +(PPoint a, PPoint b)
        => new PPoint(a.x + b.x, a.y + b.y, a.z + b.z);
    public static PPoint operator -(PPoint a, PPoint b)
        => new PPoint(a.x - b.x, a.y - b.y, a.z - b.z);
    public static PPoint operator *(PPoint a, double d)
    => new PPoint(a.x * d, a.y * d, a.z * d);
    public static PPoint operator /(PPoint a, double d)
    => new PPoint(a.x / d, a.y / d, a.z / d);
    public static PPoint operator *(PPoint a, PPoint p)
    => new PPoint(a.y * p.z - a.z * p.y, a.z * p.x - a.x * p.z, a.x * p.y - a.y * p.x);
    public static double operator %(PPoint a, PPoint p)
        => (a.x * p.x + a.y * p.y + a.z * p.z);
}

public class Cut : MonoBehaviour
{
    void Start()
    {
        Rtime = Time.time;
    }
    float Rtime;
    public float DS = 0.1f;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Resource") && Time.time - Rtime > 0.4f)
        {
            //print(111);
            Rtime = Time.time;
            GameObject GP = col.gameObject;

            PPoint p1 = new PPoint(col.gameObject.transform.GetChild(0).position);
            PPoint p2 = new PPoint(col.gameObject.transform.GetChild(1).position);
            PPoint pn = new PPoint(transform.position);
            double cf = (p2 - p1) % (pn - p1) / (p2 - p1).Len();
            PPoint rp = (p2 - p1) / (p2 - p1).Len() * cf + p1;
            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.transform.position = rp.Vec();
            print(cf / (p2 - p1).Len());
            double cc = cf / (p2 - p1).Len();
            GameObject GM1 = Instantiate(GP);
            GM1.transform.position = ((rp + p1) / 2).Vec() - new Vector3(0, 0, DS);
            GM1.transform.localScale = new Vector3(GP.transform.lossyScale.x, GP.transform.lossyScale.y * (float)cc, GP.transform.lossyScale.z);
            GM1.transform.rotation = GP.transform.rotation;

            cc = 1 - cc;
            GameObject GM2 = Instantiate(GP);
            GM2.transform.position = ((rp + p2) / 2).Vec() + new Vector3(0, 0, DS);
            GM2.transform.localScale = new Vector3(GP.transform.lossyScale.x, GP.transform.lossyScale.y * (float)cc, GP.transform.lossyScale.z);
            GM2.transform.rotation = GP.transform.rotation;

            Destroy(GP);
        }
    }

    void Update()
    {

    }
}
