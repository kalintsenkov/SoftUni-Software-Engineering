using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numberNights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;
            double wholeStudioPrice = 0;
            double wholeApartmentPrice = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                apartmentPrice = 65;
                if (numberNights > 7 && numberNights < 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.05);
                    wholeApartmentPrice = apartmentPrice * numberNights;
                    wholeStudioPrice = studioPrice * numberNights;
                    Console.WriteLine($"Apartment: {wholeApartmentPrice:f2} lv.");
                    Console.WriteLine($"Studio: {wholeStudioPrice:f2} lv.");
                }
                else if (numberNights > 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.30);
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                    wholeApartmentPrice = apartmentPrice * numberNights;
                    wholeStudioPrice = studioPrice * numberNights;
                    Console.WriteLine($"Apartment: {wholeApartmentPrice:f2} lv.");
                    Console.WriteLine($"Studio: {wholeStudioPrice:f2} lv.");
                }
                else
                {
                    wholeApartmentPrice = apartmentPrice * numberNights;
                    wholeStudioPrice = studioPrice * numberNights;
                    Console.WriteLine($"Apartment: {wholeApartmentPrice:f2} lv.");
                    Console.WriteLine($"Studio: {wholeStudioPrice:f2} lv.");
                }
            }

            if (month == "June" || month == "September")
            {
                studioPrice = 75.20;
                apartmentPrice = 68.70;
                if (numberNights > 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.20);
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                    wholeApartmentPrice = apartmentPrice * numberNights;
                    wholeStudioPrice = studioPrice * numberNights;
                    Console.WriteLine($"Apartment: {wholeApartmentPrice:f2} lv.");
                    Console.WriteLine($"Studio: {wholeStudioPrice:f2} lv.");
                }
                else
                {
                    wholeStudioPrice = studioPrice * numberNights;
                    wholeApartmentPrice = apartmentPrice * numberNights;
                    Console.WriteLine($"Apartment: {wholeApartmentPrice:f2} lv.");
                    Console.WriteLine($"Studio: {wholeStudioPrice:f2} lv.");
                }
            }

            if (month == "July" || month == "August")
            {
                studioPrice = 76;
                apartmentPrice = 77;
                if (numberNights > 14)
                {
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                    wholeApartmentPrice = apartmentPrice * numberNights;
                    wholeStudioPrice = studioPrice * numberNights;
                    Console.WriteLine($"Apartment: {wholeApartmentPrice:f2} lv.");
                    Console.WriteLine($"Studio: {wholeStudioPrice:f2} lv.");
                }
                else
                {
                    wholeApartmentPrice = apartmentPrice * numberNights;
                    wholeStudioPrice = studioPrice * numberNights;
                    Console.WriteLine($"Apartment: {wholeApartmentPrice:f2} lv.");
                    Console.WriteLine($"Studio: {wholeStudioPrice:f2} lv.");
                }
            }
        }
    }
}
