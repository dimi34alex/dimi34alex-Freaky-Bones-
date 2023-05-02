using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Этот скрипт нужен для обнуления угла в месте, куда персонаж берет предметы. Чтобы после выхода из замаха
// предметы принимали нормальный угол и их не перекашивало в сомнительные стороны. 
public class RegulatorAngle : MonoBehaviour
{

    void Update()
    {            
        if(Input.GetMouseButton(1) == false)
        {
            transform.localEulerAngles = new Vector3(0.001f,-36.769f,0f);
        }
    }
}
