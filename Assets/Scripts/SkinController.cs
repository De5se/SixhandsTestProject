using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Open");
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    
    [SerializeField] private List<GameObject> shirts = new List<GameObject>();
    public void ChangeShirt(int plusCounter)
    {
        int nextShirt = (PlayerPrefs.GetInt("Shirt", 0) + plusCounter) % shirts.Count;
        shirts[PlayerPrefs.GetInt("Shirt")].SetActive(false);
        shirts[nextShirt].SetActive(true);
        
        PlayerPrefs.SetInt("Shirt", nextShirt);
    }
    
    [SerializeField] private List<GameObject> boots = new List<GameObject>();
    public void ChangeBoots(int plusCounter)
    {
        int nextBoots = (PlayerPrefs.GetInt("Boots", 0) + plusCounter) % boots.Count;
        boots[PlayerPrefs.GetInt("Boots")].SetActive(false);
        boots[nextBoots].SetActive(true);
        
        PlayerPrefs.SetInt("Boots", nextBoots);
    }
    
    [SerializeField] private List<GameObject> trousers = new List<GameObject>();
    public void ChangeTrousers(int plusCounter)
    {
        int nextShirt = (PlayerPrefs.GetInt("Trousers", 0) + plusCounter) % trousers.Count;
        trousers[PlayerPrefs.GetInt("Trousers")].SetActive(false);
        trousers[nextShirt].SetActive(true);
        
        PlayerPrefs.SetInt("Trousers", nextShirt);
    }
}
