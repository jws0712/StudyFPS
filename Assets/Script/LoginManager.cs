using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField id;
    public InputField password;
    public Text notify;

    private void Start()
    {
        notify.text = "";
    }

    public void SaveUserData()
    {
        if (!PlayerPrefs.HasKey(id.text))
        {
            if(!CheckInput(id.text, password.text))
            {
                return;
            }
            PlayerPrefs.SetString(id.text, password.text);
            notify.text = "���̵� ������ �Ϸ�ƽ��ϴ�.";
        }
        else
        {
            notify.text = "�̹� �����ϴ� ���̵� �Դϴ�.";
        }
    }

    public void CheckUserData()
    {
        if (!CheckInput(id.text, password.text))
        {
            return;
        }
        string pass = PlayerPrefs.GetString(id.text);

        if(password.text == pass)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            notify.text = "�Է��Ͻ� ���̵�� �н����尡 ��ġ���� �ʽ��ϴ�.";
        }
    }

   bool CheckInput(string id, string pwd)
    {
        if(id == "" || pwd == "")
        {
            notify.text = "���̵� �Ǵ� �н����带 �Է����ּ���.";
            return false;
        }
        else
        {
            return true;
        }
    }

}
