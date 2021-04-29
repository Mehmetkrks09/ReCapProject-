﻿using Business.Concrete;
using DataAccess.Abstracts;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramwork;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsolUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            context context = new context();
            //CarManager carmanager = new CarManager(new EfCarDal()))
           ;
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalsManager rentalsManager = new RentalsManager(new EfRentalsDal());
            //CarManager carManager = new CarManager(new(EfCarDal));
            //Genel(carManager, brandManager, colorManager);


            //var result = carManager.GetAll();
            //if (result.Succes == true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine("Car ID: " + car.CarId + " --- " + car.Description + " " + "Brand ID: " + car.BrandId + "  Günlük Ücret: " + car.DailyPrice + " Color ID : " + car.ColorId);
            //    }
            //}

            //Console.WriteLine();


            //--------------------------------------------------------
            //foreach (var rental in context.Rentals)
            //{
            //    rentalsManager.Add(new Rentals
            //    {
            //        Id = 4,
            //        CarId = 5,
            //        CustomerId = 7,
            //        RentDate = new DateTime(2021,02,12),
            //        ReturnDate = new DateTime(2021,02,18)
            //    });
            //}
            //-------------------------------------------------------------------------------------
            //foreach (var rental in context.Rentals)
            //{

            //    if (rental.ReturnDate <= DateTime.Now)
            //    {
            //        Console.WriteLine($"Araç {rental.ReturnDate} geri teslim edilmiştir");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Araç {rental.ReturnDate} geri teslim edilecek");
            //    }
            //--------------------------------------------------------------------------------------------

            //}

            //private static void Genel(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
            //{
            //    Console.WriteLine("Brand Id'si 1 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //    foreach (var car in carManager.GetByBrandId(1))
            //    {
            //        Console.WriteLine($"{car.Id}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //    }
            //    Console.WriteLine("Brand Id'si 2 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //    foreach (var car in carManager.GetByBrandId(2))
            //    {
            //        Console.WriteLine($"{car.Id}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //    }

            //    Console.WriteLine("\n\nColor Id'si 1 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //    foreach (var car in carManager.GetByColorId(1))
            //    {
            //        Console.WriteLine($"{car.Id}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //    }

            //    Console.WriteLine("\n\nColor Id'si 2 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //    foreach (var car in carManager.GetByColorId(2))
            //    {
            //        Console.WriteLine($"{car.Id}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            //    }
            //}
        }





    }
}







