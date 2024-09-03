using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Car{
    private string _brand;
    private string _model;
    private int _year;
    
    public Car(string brand, string model, int year){
        _brand = brand;
        _model = model;
        _year = year;
    }
	
	// can add getters if needed
    
    public int GetAge(){
        return  DateTime.Now.Year - _year;
    }
    
    public override string ToString(){
        return $"{_brand} {_model} ({_year})";
    }
}