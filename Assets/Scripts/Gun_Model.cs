using UnityEngine;

public class Gun_Model : MonoBehaviour
{
    public GameObject pistolModel;
    public GameObject shotgunModel;
    public GameObject machinegunModel;
    
    private char currentGun = 'p';
    
    public void SwitchToPistol()
    {
        currentGun = 'p';
        pistolModel.SetActive(true);
        shotgunModel.SetActive(false);
        machinegunModel.SetActive(false);
    }
    
    public void SwitchToShotgun()
    {
        currentGun = 's';
        pistolModel.SetActive(false);
        shotgunModel.SetActive(true);
        machinegunModel.SetActive(false);
    }
    
    public void SwitchToMachinegun()
    {
        currentGun = 'm';
        pistolModel.SetActive(false);
        shotgunModel.SetActive(false);
        machinegunModel.SetActive(true);
    }
}