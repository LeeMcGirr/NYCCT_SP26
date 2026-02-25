using UnityEngine;
using System;

public class moreMaths : MonoBehaviour
{
    //this is a container for math functions

    //simple remapFloat operation
    public static float RemapFloat(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public static float RemapFloat(float value, float from1, float to1)
    {
        return (value - from1) / (to1 - from1) * (1 - 0) + 0;
    }

    public static Vector3 RemapVector(Vector3 value, Vector3 from1, Vector3 to1, Vector3 from2, Vector3 to2)
    {

        float x = RemapFloat(value.x, from1.x, to1.x, from2.x, to2.x);
        if (Single.IsNaN(x)){ x = 0; }
        float y = RemapFloat(value.y, from1.y, to1.y, from2.y, to2.y);
        if(Single.IsNaN(y)){ y = 0; }
        float z = RemapFloat(value.z, from1.z, to1.z, from2.z, to2.z);
        if(Single.IsNaN(z)){ z = 0; }
        return new Vector3(x, y, z);
    }

    //unsafe fast inverse square root - consider benching this against mathf. on mobile and iOS 
    //public static float FastSqrt(float number)
    //{
    //    if (number <= 0)
    //    {
    //        return 0; // Return 0 for non-positive numbers to avoid undefined behavior
    //    }

    //    //this is slower than mathf.Sqrt on windows x64 architecture
    //    //benchmark it on mobile to see if it's better on ARM or iOS
    //    //not all hardware will sqrt the same!!
    //    unsafe
    //    {
    //        float threeHalfs = 1.5f;
    //        float x2 = number * 0.5f;
    //        int i = *(int*)&number; // Interpret the float as an int
    //        i = 0x5f3759df - (i >> 1); // Magic number for approximation
    //        float y = *(float*)&i; // Interpret the int back as a float
    //        y = y * (threeHalfs - (x2 * y * y)); // First iteration of Newton's method
    //        return 1 / y; // Invert the result to get the square root
    //    }
    //}

    //----------------------- LERP with an animation curve as a shaping function - floats and vectors -----------------//
    #region animCurveLerps
    public static float LerpCurved(float a, float b, AnimationCurve curve, float time)
    {
        //lerp using an animation curve as the t value
        float t = curve.Evaluate(time);
        return Mathf.Lerp(a, b, t);
    }

    public static Vector3 VLerpCurved(Vector3 a, Vector3 b, AnimationCurve curve, float time)
    {
        //lerp using an animation curve as the t value
        float t = curve.Evaluate(time);
        t = Mathf.Clamp(t, 0f, Mathf.Infinity);
        return Vector3.Lerp(a, b, t);
    }
    #endregion


    // -------------------------- ADDITIONAL QUATERNION FUNCTIONS -------------------------------------//
    #region moreQuaternions

    public static bool IsValid(Quaternion quaternion) //from: https://discussions.unity.com/t/checking-for-quaternion-values-to-not-be-nan/31006
    {
        bool isNaN = float.IsNaN(quaternion.x + quaternion.y + quaternion.z + quaternion.w);

        bool isZero = quaternion.x == 0 && quaternion.y == 0 && quaternion.z == 0 && quaternion.w == 0;

        return !(isNaN || isZero);
    }

    public static Quaternion QMultiply(Quaternion q, float s)
    {
        return new Quaternion(q.x * s, q.y * s, q.z * s, q.w * s);
    }

    public static Quaternion QAdd(Quaternion l, Quaternion r)
    {
        return new Quaternion(l.x + r.x, l.y + r.y, l.z + r.z, l.w + r.w);
    }

    public static Quaternion Conj(Quaternion q)
    {
        return new Quaternion(q.x, q.y, q.z, -q.w);
    }
    #endregion




}
