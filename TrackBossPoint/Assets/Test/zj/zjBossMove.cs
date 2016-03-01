using UnityEngine;
using System.Collections;
public class zjBossMove : MonoBehaviour
{
    public GameObject self;
     public GameObject obj;
    public RectTransform _img;
    public float a=300, b = 200;
    public ImgShowType show_type = ImgShowType.矩形;


    private float direction = 0, direction_new;
    void Start()
    {
        a = UnityEngine.Screen.width / 2-50;
        b= UnityEngine.Screen.height / 2-50;
    }

    void Update()
    {
        var dir = obj.transform.position - transform.position;
        dir.y = 0;
        dir = dir.normalized;
        direction = Vector3.Dot(dir, self.transform.forward);
        Vector3 u = Vector3.Cross(dir, self.transform.forward);
        if (direction > 1) { direction = 1f; }
        if (direction < -1) { direction = -1f; }
        direction = Mathf.Acos(direction) * Mathf.Rad2Deg;
       
        _img.rotation =Quaternion.Euler(new Vector3(0, 0, direction * (u.y > 0 ? 1 : -1)));
        Vector3 result = Vector3.zero;
        //Debug.Log(direction);
        if (direction == 0)
        {
            result = new Vector3(0, b, 0);
        }
        else if (direction == 180)
        {
            result = new Vector3(0, -b, 0);
        }
        else
        {
            direction_new = 90 - direction;
            float k = Mathf.Tan(Mathf.PI / 180 * direction_new);

            switch (show_type)
            {
                case ImgShowType.椭圆:
                    //==========椭圆========
                    result.x = a * b * Mathf.Sqrt((1.00f / (b * b + a * a * k * k)));
                    result.y = k * result.x;
                    result.z = 0;
                    if (u.y > 0) { result.x = result.x * -1; }
                    break;
                case ImgShowType.矩形:
                    //======矩形=================
                    result.x = b / k;
                    if ((result.x > (a * -1)) && (result.x < a))
                    {//线1,3
                        result.y = b;
                        if(direction>90)
                        {
                            result.y = b * -1;
                            result.x = result.x * -1;
                        }
                    }
                    else
                    {
                        result.y = a * k;
                        if ((result.y > (b * -1)) && (result.y < b))
                        {//线2,4
                            result.x = result.y / k;
                        }
                    }
                    if (u.y > 0)
                    {
                        result.x = result.x * -1;
                    }
                    break;
            }
        }
        _img.localPosition = result;
    }

    //手柄使用-------
    private float angle;
    /// <summary>
    /// 方向舵移动控制执行
    /// </summary>
    /// <param name="move"></param>
    public void Move(Vector2 move)
    {
        try
        {
            float x = move.x;
            float y = move.y;
            angle = Axis2Angle(x, y, true);
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            transform.Translate(transform.forward * 6 * Time.deltaTime, Space.World);
        }
        catch
        {
            Debug.Log("==========================ActorMove Error!========================");
        }
    }

    /// <summary>
    /// xy二维角度-
    /// </summary>
    /// <returns>
    /// The angle.
    /// </returns>
    private float Axis2Angle(float x, float y, bool inDegree = true)
    {
        float angle = Mathf.Atan2(x, y);
        if (inDegree)
        {
            return angle * Mathf.Rad2Deg;
        }
        else
        {
            return angle;
        }
    }
}
public enum  ImgShowType
{
    椭圆,
    矩形
}


    
