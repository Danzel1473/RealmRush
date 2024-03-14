using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalace { get { return currentBalance; } }

    void Awake(){
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount){
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

      public void Withdraw(int amount){
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(CurrentBalace < 0){
            ReloadScene();
        }
    }

    void UpdateDisplay(){
        displayBalance.text = "Gold:" + CurrentBalace;
    }

    void ReloadScene(){
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    
}
