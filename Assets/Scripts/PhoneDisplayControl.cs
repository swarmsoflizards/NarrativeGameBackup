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

    [Tooltip("The number of times the display flashes")]
    [SerializeField] float maxNumberOfFlashes;

    private int numberOfFlashes = 0;

    private void Start()
    {
        displayObject.SetActive(false);
        StartCoroutine(WaitToFlash());
    }


    private IEnumerator WaitToFlash()
    {
        while (numberOfFlashes <= maxNumberOfFlashes)
        {
            yield return new WaitForSeconds(lengthOfFlash);
            displayObject.SetActive(true);
            yield return new WaitForSeconds(lengthOfFlash);
            displayObject.SetActive(false);
            numberOfFlashes++;
        }

    }

}
