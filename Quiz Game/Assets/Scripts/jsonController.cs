using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonController : MonoBehaviour
{
    public string jsonURL;  //Variable to hold URL
    public RootObject myObject = new RootObject();   //class to store json file data.


    [Serializable]
    public class QuestionandAnswers     //serializable class with the structure as the given json file
    {
        public string question;     // string variable with the same identifier as given in the json file
        public List<string> options;    //list variable to store options
        public int correctOptionIndex;      //integer variable to store correct option

    }

    [Serializable]
    public class RootObject //class to hold the array from the json file inside an object
    {
        public QuestionandAnswers[] qanda;  //the parent object is created with the name qanda
    }
     
    // Start is called before the first frame update
    [Obsolete]
    void Awake()
    {
        StartCoroutine(getData());  //subroutine to get all the data from json file
        
    }

    [Obsolete]
    IEnumerator getData()
    {

        using (WWW www = new WWW(jsonURL)) //get the file from the url
        {
            yield return www;
           // Debug.Log(www.text);

            if (www.isDone) //if url is found
            {
                myObject = JsonUtility.FromJson<RootObject>("{\"qanda\":" + www.text + "}");    //create an object, since there's no root object, added one.
               // string json = JsonUtility.ToJson(myObject);
               // myObject = JsonUtility.FromJson<RootObject>(json);
                

            }
            
        }


        
       
    }

  
}
