using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialPortScript : MonoBehaviour
{
    private static SerialPortScript instance;

    private void Awake()
    {
        if(null == instance) 
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SerialPortScript Instance
    {
        get 
        {
            if (null == instance) return null;
            return instance; 
        }
    }
    SerialPort sp;
    
    // Start is called before the first frame update
    void Start()
    {
        sp = new SerialPort("COM5", 9600);
        //?�트 ?�름, 보드?�이???�신?�도)
        OpenConnection();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenConnection()
    {
        if(sp != null) 
        {
            if (sp.IsOpen)
            { 
                sp.Close();
                Debug.Log("port is already open!");
            }
            else 
            {
                sp.Open();
                sp.ReadTimeout = 16;
                Debug.Log("part open!");
            }
        }
        else
        {
            if(sp.IsOpen)
            {
                Debug.Log("port is already open!");
            }
            else
            {
                Debug.Log("port is null");
            }
        }
        
    }

    public void SendSignal()
    {
        sp.Write("a");
    }

    public void SendStopSignal()
    {
        sp.Write("s");
    }
}
