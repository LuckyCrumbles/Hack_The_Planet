using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Hacker");
        
    }
    void ShowMainMenu(string greeting)
    {
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Coded");
        Terminal.WriteLine("Press 2 for Calender.apk");
        Terminal.WriteLine("Press 3 for Olympus Bank");
        Terminal.WriteLine("Enter your selection:");
        
    }

    //Game state
    int level;
    string[] level1passwords = {"hashim", "hussain", "mohammed", "abdullah"};
    string[] level2passwords = {"woden", "dionysus", "thorsday", "surtur"};
    string[] level3passwords = {"yggdrasil", "jormungandr", "hecatoncheires", "charybdis"};
    string password = "dendenmushi"; 
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;


    void OnUserInput(string input)
    {
        
        if (input == "menu")
        {
            currentScreen = Screen.MainMenu;
            Terminal.ClearScreen();
            ShowMainMenu("Welcome back, Hacker");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            SetLevel(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    void SetLevel(string selectedLevel)
    {
        if (selectedLevel == "1")
        {
            level = 1;
            StartGame();
        }
        else if (selectedLevel == "2")
        {
            level = 2;
            StartGame();
        }
        else if (selectedLevel == "3")
        {
            level = 3;
            StartGame();
        }

    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("!!YOU WIN!!");
        }
        else
        {
            Terminal.WriteLine("SiKe!! TRY AGAIN XD ");
        }
    }
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length - 1)];
                Terminal.WriteLine(password.Anagram());
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length - 1)];
                Terminal.WriteLine(password.Anagram());
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length - 1)];
                Terminal.WriteLine(password.Anagram());
                break;
            default:
                Terminal.WriteLine("Invalid level does not exist");
                break;
                
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level" + level);
        Terminal.WriteLine("Enter password: " + password.Anagram());
    }
   
}
