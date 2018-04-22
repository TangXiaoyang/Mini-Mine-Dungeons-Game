using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour {
    public GameObject speed1;
    public GameObject speed2;
    public GameObject speed3;
    public GameObject power1;
    public GameObject power2;
    public GameObject power3;
    public GameObject eat1;
    public GameObject eat2;
    public GameObject eat3;
    public int exp;
    GameObject root;
	public Player playerstate;


    void Start()
    {
        exp = 110;
        List<string> btnsName = new List<string>();
        btnsName.Add("Speed");
        btnsName.Add("Power");
        btnsName.Add("Eat");
        root = GameObject.Find("Second Page");
        speed1 = root.transform.Find(name: "Upgrade Menu/Speed Level1").gameObject;
        speed2 = root.transform.Find(name: "Upgrade Menu/Speed Level2").gameObject;
        speed3 = root.transform.Find(name: "Upgrade Menu/Speed Level3").gameObject;
        power1 = root.transform.Find(name: "Upgrade Menu/Power Level1").gameObject;
        power2 = root.transform.Find(name: "Upgrade Menu/Power Level2").gameObject;
        power3 = root.transform.Find(name: "Upgrade Menu/Power Level3").gameObject;
        eat1 = root.transform.Find(name: "Upgrade Menu/Eat Level1").gameObject;
        eat2 = root.transform.Find(name: "Upgrade Menu/Eat Level2").gameObject;
        eat3 = root.transform.Find(name: "Upgrade Menu/Eat Level3").gameObject;

        foreach (string btnName in btnsName)
        {
            GameObject btnObj = root.transform.Find("Upgrade Menu/"+btnName).gameObject;
            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(delegate () {
                this.OnClick(btnObj);
            });
        }
    }

    public void OnClick(GameObject sender)
    {
        switch (sender.name)
        {
            case "Speed":
                if (exp > 100)
                {
                    root.transform.Find("Upgrade Menu/Power").gameObject.GetComponent<Button>().interactable = true;
                    root.transform.Find("Upgrade Menu/Eat").gameObject.GetComponent<Button>().interactable = true;
                    sender.GetComponent<Button>().interactable = true;
                    if (speed1.GetComponent<Image>().IsActive() == false)
                    {
                        speed1.SetActive(true);
                        speed1.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0;
                        speed2.SetActive(false);
                        speed3.SetActive(false);
					playerstate.speedLV (3);

                    }
                    else if(speed2.GetComponent<Image>().IsActive() == false)
                    {
                        speed2.SetActive(true);
                        speed2.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0;
                        speed3.SetActive(false);
                    }
                    else if (speed3.GetComponent<Image>().IsActive() == false)
                    {
                        speed3.SetActive(true);
                        speed3.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0; 
                    }
                }
                else
                {
                    root.transform.Find("Upgrade Menu/Power").gameObject.GetComponent<Button>().interactable = false;
                    root.transform.Find("Upgrade Menu/Eat").gameObject.GetComponent<Button>().interactable = false;
                    sender.GetComponent<Button>().interactable = false;           
                }
                break;
            case "Power":
                if (exp > 100)
                {
                    root.transform.Find("Upgrade Menu/Speed").gameObject.GetComponent<Button>().interactable = true;
                    root.transform.Find("Upgrade Menu/Eat").gameObject.GetComponent<Button>().interactable = true;
                    sender.GetComponent<Button>().interactable = true;
                    if (power1.GetComponent<Image>().IsActive() == false)
                    {
                        power1.SetActive(true);
                        power1.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0;
                        power2.SetActive(false);
                        power3.SetActive(false);
                    }
                    else if (power2.GetComponent<Image>().IsActive() == false)
                    {
                        power2.SetActive(true);
                        power2.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0;
                        power3.SetActive(false);
                    }
                    else if (power3.GetComponent<Image>().IsActive() == false)
                    {
                        power3.SetActive(true);
                        power3.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0;                      
                    }
                }
                else
                {
                    root.transform.Find("Upgrade Menu/Speed").gameObject.GetComponent<Button>().interactable = false;
                    root.transform.Find("Upgrade Menu/Eat").gameObject.GetComponent<Button>().interactable = false;
                    sender.GetComponent<Button>().interactable = false;
                }
                break;
            case "Eat":
                if (exp > 100)
                {
                    root.transform.Find("Upgrade Menu/Speed").gameObject.GetComponent<Button>().interactable = true;
                    root.transform.Find("Upgrade Menu/Power").gameObject.GetComponent<Button>().interactable = true;
                    sender.GetComponent<Button>().interactable = true;
                    if (eat1.GetComponent<Image>().IsActive() == false)
                    {
                        eat1.SetActive(true);
                        eat1.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0;
                        eat2.SetActive(false);
                        eat3.SetActive(false);
                    }
                    else if (eat2.GetComponent<Image>().IsActive() == false)
                    {
                        eat2.SetActive(true);
                        eat2.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0;
                        eat3.SetActive(false);
                    }
                    else if (eat3.GetComponent<Image>().IsActive() == false)
                    {
                        eat3.SetActive(true);
                        eat3.GetComponent<Image>().color = new Color(114, 193, 38);
                        exp = 0;
                    }
                }
                else
                {
                    root.transform.Find("Upgrade Menu/Speed").gameObject.GetComponent<Button>().interactable = false;
                    root.transform.Find("Upgrade Menu/Power").gameObject.GetComponent<Button>().interactable = false;
                    sender.GetComponent<Button>().interactable = false;
                }
                break;
            default:
                Debug.Log("none");
                break;
        }
    }

    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitGame()
    {
        //Debug.Log("Quit!");
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
	public void EXPup(int a){
		exp += a;
	}
}
