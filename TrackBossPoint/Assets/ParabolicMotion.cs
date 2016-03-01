using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 抛物运动
/// </summary>
public class ParabolicMotion : MonoBehaviour {
    /// <summary>
    /// 轨迹点列表集合
    /// </summary>
    public List<Vector3> Points = new List<Vector3>();
    /// <summary>
    /// 起始点
    /// </summary>
    private Vector3 StartPoint = Vector3.zero;
    /// <summary>
    /// _speed速度，_angle角度
    /// </summary>
    public float _speed,_angle;
}
