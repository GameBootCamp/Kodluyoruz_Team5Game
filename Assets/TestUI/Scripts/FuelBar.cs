using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] private float _fuel = 100f;
    private float _currentFuel;

    [SerializeField] private Slider _fuelSilder;
    [SerializeField] float fuelBurnRate = 20f;
    [SerializeField] float fuelRefillRate = 20f;

    private void Awake()
    {
        _currentFuel = _fuel;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        _fuelSilder.value = _currentFuel / _fuel;

        if (Input.GetKey(KeyCode.Space))
        {
            _currentFuel -= fuelBurnRate * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.Space))
        {
            RefillFuel();
        }
        
    }

    private void RefillFuel()
    {
        if (_currentFuel < _fuel)
        {
            _currentFuel += fuelRefillRate * Time.deltaTime;
        }
    }
}
