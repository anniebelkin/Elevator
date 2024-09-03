using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarFactory : MonoBehaviour
{
    void Start()
    {
        Debug.Log("The cars collection:");
        Car[] collection = new Car[] {
            new Car("Toyota", "Corolla", 2015),
            new Car("Ford", "Mustang", 2018),
            new Car("Honda", "Civic", 2020),
            new Car("Chevrolet", "Malibu", 2016),
            new Car("BMW", "3 Series", 2017),
            new Car("Audi", "A4", 2019),
            new Car("KIA", "Picanto", 2010),
            new Car("Mercedes-Benz", "C-Class", 2018),
            new Car("Subaru", "Outback", 2021),
            new Car("Volkswagen", "Golf", 2015),
            new Car("Hyundai", "Elantra", 2019),
            new Car("Nissan", "Altima", 2016),
            new Car("Mazda", "Mazda3", 2017)
        };
        Car oldestCar = collection[0];
        foreach (Car car in collection)
        {
            Debug.Log($"* {car}");
            if (car.GetAge() > oldestCar.GetAge())
            {
                oldestCar = car;
            }
        }
        Debug.Log("------------------------------");
        Debug.Log($"The oldest car is: {oldestCar}");
    }
}