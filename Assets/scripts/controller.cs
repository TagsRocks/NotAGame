using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{

    public GameObject cam;
    float x, y;
	
    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 100, 50), "x: " + Input.mousePosition.x.ToString("f0") + " : " + Screen.width.ToString() + "\n" +
		           								"y: " + Input.mousePosition.y.ToString("f0") + " : " + Screen.height.ToString());
    }
    public GameObject go;
    public float sensitivity = 1F;
    public Camera goCamera;
    private Vector3 MousePos;
    private float MyAngle = 0F;

    void Start()
    {
        // Инициализируем кординаты мышки и ищем главную камеру
        go = goCamera.transform.parent.gameObject;
        // Cursor.lockState = CursorLockMode.Locked;
       // Screen.lockCursor = true;
    }

    void Update()
    {
        MousePos = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.G))
        {
             Cursor.lockState = (CursorLockMode)(((int)Cursor.lockState+1)%2);
        }
    }

    void FixedUpdate()
    {
        
        MyAngle = 0;
        // расчитываем угол, как:
        // разница между позицией мышки и центром экрана, делённая на размер экрана
        //  (чем дальше от центра экрана тем сильнее поворот)
        // и умножаем угол на чуствительность из параметров
        MyAngle = sensitivity * ((MousePos.x - (Screen.width / 2)) / Screen.width);
        goCamera.transform.RotateAround(go.transform.position, goCamera.transform.up, MyAngle);
        MyAngle = sensitivity * ((MousePos.y - (Screen.height / 2)) / Screen.height);
        goCamera.transform.RotateAround(go.transform.position, goCamera.transform.right, -MyAngle);
       
    }



    }
