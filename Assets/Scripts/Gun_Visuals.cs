using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Visuals : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    
    public AudioSource pistolSound;
    public AudioSource shotgunSound;
    public AudioSource machinegunSound;
    
    public void PlayMuzzleFlash()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            muzzleFlash.Play();
        }
    }
    
    public void PlayPistolSound()
    {
        if (pistolSound != null) pistolSound.Play();
    }
    
    public void PlayShotgunSound()
    {
        if (shotgunSound != null) shotgunSound.Play();
    }
    
    public void PlayMachinegunSound()
    {
        if (machinegunSound != null) machinegunSound.Play();
    }
    
    public void PlayPistolEffects()
    {
        PlayMuzzleFlash();
        PlayPistolSound();
    }
    
    public void PlayShotgunEffects()
    {
        PlayMuzzleFlash();
        PlayShotgunSound();
    }
    
    public void PlayMachinegunEffects()
    {
        PlayMuzzleFlash();
        PlayMachinegunSound();
    }
}