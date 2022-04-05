using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInManager : MonoBehaviour
{
    public void SignIn()
    {
        CloudSaveSample.CloudSaveSample.Instance.SignInAnonymously();
    }
}
