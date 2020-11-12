using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour, IDummy
{
    Collider2D collider2D;

    void Start()
    {
        var boidColliders = Physics2D.OverlapCircleAll(transform.position, 5f);
        Stopwatch sw = new Stopwatch();
        List<IDummy> dummies = new List<IDummy>();
        List<GameObject> others = new List<GameObject>();

        sw.Start();

        for (int i = 0; i < 100; i++)
        {
            foreach (var item in boidColliders)
            {
                IDummy f = item.GetComponent<IDummy>();
                if (f != null)
                {
                    others.Add(item.gameObject);
                }
                else
                {
                    dummies.Add(f);
                }
            }
        }
        
        sw.Stop();
        UnityEngine.Debug.Log(sw.Elapsed.TotalMilliseconds);
        sw.Reset();
        sw.Start();
        for (int i = 0; i < 100; i++)
        {
            dummies = boidColliders.Select(o => o.GetComponent<IDummy>()).ToList();
            others = boidColliders.Where(o => o.GetComponent<IDummy>() == null).Select(o  => o.GetComponent<GameObject>()).ToList();
        }
        sw.Stop();
        UnityEngine.Debug.Log(sw.Elapsed.TotalMilliseconds);
    }

    void Template()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        sw.Stop();
        UnityEngine.Debug.Log(sw.Elapsed.TotalMilliseconds);
        sw.Reset();
        sw.Start();

        sw.Stop();
        UnityEngine.Debug.Log(sw.Elapsed.TotalMilliseconds);
    }

    //void Test1()
    //{
    //    collider2D = GetComponent<Collider2D>();
    //    var boidColliders = Physics2D.OverlapCircleAll(transform.position, 5f);
    //    Stopwatch sw = new Stopwatch();

    //    sw.Start();
    //    for (int i = 0; i < 100; i++)
    //    {
    //        var boids = boidColliders.Select(o => o.GetComponent<IDummy>()).ToList();
    //        boids.Remove(this);
    //        //This is 4x faster than the other
    //    }
    //    sw.Stop();
    //    UnityEngine.Debug.Log(sw.Elapsed.TotalMilliseconds);
    //    sw.Reset();
    //    sw.Start();
    //    for (int i = 0; i < 100; i++)
    //    {
    //        List<IDummy> all = new List<IDummy>();
    //        foreach (var item in boidColliders)
    //        {
    //            if (item != collider2D)
    //            {
    //                all.Add(item.GetComponent<test>());
    //            }
    //        }

    //    }
    //    sw.Stop();
    //    UnityEngine.Debug.Log(sw.Elapsed.TotalMilliseconds);
    //}

}
