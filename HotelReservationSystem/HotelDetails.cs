﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    //Class to save hotel details
    public class HotelDetails
    {
        private int hotelRating;
        //Dictionary to store hotel name and its rates
        public static Dictionary<string, List<int>> hotelRatesDict = new Dictionary<string, List<int>>();

        //Adds hotelName and rates dictionary hotelRatesDict. Overwrites rates if hotel already exists
        public bool AddHotel(string hotelName, int weekdaysRateForRegularCust, int weekendsRateForRegularCust)
        {
            bool isHotelAdded = false;
            if (String.IsNullOrEmpty(hotelName))
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_HOTEL_NAME, "Invalid Hotel Name");
            List<int> rates = new List<int> { weekdaysRateForRegularCust, weekendsRateForRegularCust };
            //Removes hotel if already exists for overiding new rates
            if (hotelRatesDict.ContainsKey(hotelName))
                hotelRatesDict.Remove(hotelName);
            //Adds rates to hotelRatesDict
            hotelRatesDict.Add(hotelName, rates);
            isHotelAdded = true;
            ColouredPrint.PrintInRed($"Added {hotelName}");
            return isHotelAdded;
        }
    }
}
