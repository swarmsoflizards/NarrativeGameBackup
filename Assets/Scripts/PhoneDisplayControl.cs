using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the flashing of the low battery display on the phone
/// </summary>
public class PhoneDisplayControl : MonoBehaviour
{
    [Tooltip("The display GameObject to toggle")]
    [SerializeField] GameObject displayObject;

    [Tooltip("The display GameObject to toggle")]
    [SerializeField] float lengthOfFlash;


    private void Start()
    {
        displayObject.SetActive(false);
        StartCoroutine(WaitToFlash()); 
    }

    private IEnumerator WaitToFlash()
    {
        yield return new WaitForSeconds(lengthOfFlash);
        displayObject.SetActive(true);
        yield return new WaitForSeconds(lengthOfFlash);
        displayObject.SetActive(false);
        yield return new WaitForSeconds(lengthOfFlash);
        displayObject.SetActive(true);
        yield return new WaitForSeconds(lengthOfFlash);
        displayObject.SetActive(false);
    }
}
