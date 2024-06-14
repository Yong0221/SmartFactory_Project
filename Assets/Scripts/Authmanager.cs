using System;
using System.Threading;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Collections;
using UnityEngine.SceneManagement;

public class Authmanager : MonoBehaviour
{
    public string dbURL = "";

    [Header("LogIn Panel")]
    [SerializeField] GameObject logInPanel;
    [SerializeField] TMP_InputField emailInput_logIn;
    [SerializeField] TMP_InputField passwordInput_logIn;

    [SerializeField] Button logInBtn;

    [Header("SignUp Panel")]
    [SerializeField] GameObject SignUpPanel;
    [SerializeField] TMP_InputField userNameInput_signUp;
    [SerializeField] TMP_InputField emailInput_signUp;
    [SerializeField] TMP_InputField passwordInput_signUp;
    [SerializeField] TMP_InputField confirmPasswordInput_signUp;

    [SerializeField] Button signUpBtn;

    [Header("SendMail Panel")]
    [SerializeField] GameObject SendMailPanel;
    [SerializeField] TMP_InputField emailInput_mail;

    [SerializeField] Button sendBtn;
    [SerializeField] Image check;

    [Header("Admin Panel")]
    [SerializeField] GameObject adminMainPanel;
    [SerializeField] TMP_Text userName;

    FirebaseAuth auth;
    FirebaseUser authUser;
    public bool isAuthenticated = false;
    public bool tologin = false;
    public bool tosignup = false;
    public bool tosendmail = false;
    public bool toadminmain = false;

    public void Start()
    {
        emailInput_logIn.text = "valen0705@naver.com";
        passwordInput_logIn.text = "123456789";

        auth = FirebaseAuth.DefaultInstance;

        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new System.Uri(dbURL);
        logInBtn.onClick.AddListener(() => LogIn(emailInput_logIn.text, passwordInput_logIn.text));
        signUpBtn.onClick.AddListener(() => SignUp(userNameInput_signUp.text, emailInput_signUp.text, passwordInput_signUp.text, confirmPasswordInput_signUp.text));

    }

    public void Update()
    {
        if (isAuthenticated && toadminmain)
        {
            logInPanel.SetActive(false);
            SignUpPanel.SetActive(false);
            SendMailPanel.SetActive(false);
            adminMainPanel.SetActive(true);
            userName.text = authUser.DisplayName.ToString();

            tologin = false;
            tosignup = false;
            tosendmail = false;
            toadminmain = false;
        }
        if (tosendmail)
        {
            logInPanel.SetActive(false);
            SignUpPanel.SetActive(false);
            SendMailPanel.SetActive(true);
            tologin = false;
            tosignup = false;

        }
        if(tosignup)
        {
            logInPanel.SetActive(false);
            SignUpPanel.SetActive(true);
            SendMailPanel.SetActive(false);
            tologin = false;
            tosendmail = false;
        }
        if (tologin)
        {
            logInPanel.SetActive(true);
            SignUpPanel.SetActive(false);
            SendMailPanel.SetActive(false);
            tosignup = false;
            tosendmail = false;
        }

    }

    public void LogIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                print("로그인 실패 - " + ": \n" + task.Exception);
            }
            else if (task.IsCanceled)
            {
                print("로그인 취소 - " + ": \n" + task.Exception);
            }
            else if (task.IsCompleted)
            {

                AuthResult result = task.Result;
                authUser = result.User;

                if (authUser.IsEmailVerified)
                {
                    print("로그인되었습니다. \n 환영합니다. " + result.User.DisplayName + "님");
                    isAuthenticated = true;
                    toadminmain = true;
                }
                else
                {
                    print("인증이 되지 않은 계정입니다. 인증 화면으로 이동합니다...");
                    tosendmail = true;
                }
            }
        });
    }


    public bool SignUp(string name, string email, string password, string confirmedPassword)
    {
        if (name == "" || email == "" || password == "" || confirmedPassword == "")
        {
            print("입력하지 않은 정보가 있습니다. \n 모든 칸에 정보를 입력해주세요.");
            return false;
        }
        //DB에서 name과 email 중복체크
        //PW CPW 일치여부 체크
        if (password != confirmedPassword)
        {
            print("회원가입 실패: 비밀번호 - 비밀번호 확인이 불일치합니다.");

            return false;
        }
        else
        {
            auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    print("회원가입 실패" + ": " + task.Exception);
                }
                else if (task.IsCanceled)
                {
                    print("회원가입 취소" + ": " + task.Exception);
                }
                else if (task.IsCompleted)
                {
                    AuthResult result = task.Result;
                    FirebaseUser authUser = result.User;

                    print(result.User.DisplayName + "(" + result.User.UserId + ")님의 "
                        + "가입이 신청되었습니다. " +
                        "\n 이메일 인증 이후 가입이 완료됩니다." +
                        "\n 인증 화면으로 이동합니다...");
                    tosendmail = true;
                }
            });
            return true;
        }
    }

    UserProfile userProfile;
    public void SendEmailVerification()
    {
        authUser.SendEmailVerificationAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                print("이메일 인증 실패");
            }

            else if (task.IsCanceled)
            {
                print("이메일 인증 취소");
            }
            else if (task.IsCompleted)
            {
                print($"인증 메시지를 {authUser.Email}로 전송했습니다.");
            }
        });
    }
}
