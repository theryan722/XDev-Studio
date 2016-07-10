'Engineering Calculator v2.1
'Conversion Module
'Jeremy Gragg
'Gragg Software Solutions
Imports System.String
Imports System.Math

Module Conversion

    'The following is formulation functions for conversion solutions (more boaring stuff)__

    Public Function MeterToKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1000)
    End Function

    Public Function MeterToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 100)
    End Function

    Public Function MeterToMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000)
    End Function

    Public Function MeterToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3.28084)
    End Function

    Public Function MeterToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 39.37)
    End Function

    Public Function MeterToYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.093613)
    End Function

    Public Function MeterToMiles(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 1000) * 0.621371)
    End Function

    Public Function MeterToNMiles(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 1000) * 0.539957)
    End Function

    Public Function KilometerToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000)
    End Function

    Public Function KilometerToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 100000)
    End Function

    Public Function KilometerToMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000000)
    End Function

    Public Function KilometerToFeet(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1000) * 3.28084)
    End Function

    Public Function KilometerToInches(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1000) * 39.37)
    End Function

    Public Function KilometerToYards(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1000) * 1.093613)
    End Function

    Public Function KilometerToMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.621371)
    End Function

    Public Function KilometerToNMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.539957)
    End Function

    Public Function CentimeterToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 100)
    End Function

    Public Function CentimeterToKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 100000)
    End Function

    Public Function CentimeterToMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 10)
    End Function

    Public Function CentimeterToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.032808)
    End Function

    Public Function CentimeterToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.393701)
    End Function

    Public Function CentimeterToYards(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.032808) / 3)
    End Function

    Public Function CentimeterToMiles(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.032808) / 5280)
    End Function

    Public Function CentimeterToNMiles(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.032808) / 6076.115)
    End Function

    Public Function MillimeterToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1000)
    End Function

    Public Function MillimeterTokilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1000000)
    End Function

    Public Function MillimeterToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 10)
    End Function

    Public Function MillimeterToFeet(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 1000) * 3.28084)
    End Function

    Public Function MillimeterToInches(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 1000) * 39.37)
    End Function

    Public Function MillimeterToYards(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 1000) * 1.0936)
    End Function

    Public Function MillimeterToMiles(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 1000000) * 0.621371)
    End Function

    Public Function MillimeterToNMiles(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 1000000) * 0.539957)
    End Function

    Public Function FeetToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.3048)
    End Function

    Public Function FeetToKilometers(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.3048) / 1000)
    End Function

    Public Function FeetToCentimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.3048) * 100)
    End Function

    Public Function FeetToMillimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.3048) * 1000)
    End Function

    Public Function FeetToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 12)
    End Function

    Public Function FeetToYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 3)
    End Function

    Public Function FeetToMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 5280)
    End Function

    Public Function FeetToNMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 6076.115)
    End Function

    Public Function InchToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 39.37)
    End Function

    Public Function InchToKilometers(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 39.37) / 1000)
    End Function

    Public Function InchToCentimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 39.37) * 100)
    End Function

    Public Function InchToMillimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 39.37) * 1000)
    End Function

    Public Function InchToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 12)
    End Function

    Public Function InchToYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 36)
    End Function

    Public Function InchToMiles(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 12) / 5280)
    End Function

    Public Function InchToNMiles(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 12) / 6076.115)
    End Function

    Public Function YardToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.9144)
    End Function

    Public Function YardToKilometers(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.9144) / 1000)
    End Function

    Public Function YardToCentimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.9144) * 100)
    End Function

    Public Function YardToMillimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.9144) * 1000)
    End Function

    Public Function YardToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3)
    End Function

    Public Function YardToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 36)
    End Function

    Public Function YardToMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1760)
    End Function

    Public Function YardToNMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 2025.3718)
    End Function

    Public Function MileToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1609.344)
    End Function

    Public Function MileToKilometers(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1609.344) / 1000)
    End Function

    Public Function MileToCentimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1609.344) * 100)
    End Function

    Public Function MileToMillimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1609.344) * 1000)
    End Function

    Public Function MileToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 5280)
    End Function

    Public Function MileToInches(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 5280) * 12)
    End Function

    Public Function MileToYards(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 5280) / 3)
    End Function

    Public Function MileToNMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.868976)
    End Function

    Public Function NMileToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1852)
    End Function

    Public Function NMileToKilometers(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1852) / 1000)
    End Function

    Public Function NMileToCentimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1852) * 100)
    End Function

    Public Function NMileToMillimeters(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1852) * 1000)
    End Function

    Public Function NMileToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 6076.115)
    End Function

    Public Function NMileToInches(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 6076.115) * 12)
    End Function

    Public Function NMileToYards(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 6076.115) / 3)
    End Function

    Public Function NMileToMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.1508)
    End Function

    Public Function SquareMeterToSquareKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1000000)
    End Function

    Public Function SquareMeterToSquareCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 10000)
    End Function

    Public Function SquareMeterToSquareMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000000)
    End Function

    Public Function SquareMeterToSquareFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 10.7639104167)
    End Function

    Public Function SquareMeterToSquareInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1550.00310001)
    End Function

    Public Function SquareMeterToSquareYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.1959900463)
    End Function

    Public Function SquareMeterToSquareMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 2589988.11034)
    End Function

    Public Function SquareMeterToAcres(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 4046.8564224)
    End Function

    Public Function SquareKilometerToSquareMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000000)
    End Function

    Public Function SquareKilometerToSquareCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 10000000000)
    End Function

    Public Function SquareKilometerToSquareMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000000000000)
    End Function

    Public Function SquareKilometerToSquareFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 10763910.4167)
    End Function

    Public Function SquareKilometerToSquareInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1550003100.01)
    End Function

    Public Function SquareKilometerToSquareYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1195990.0463)
    End Function

    Public Function SquareKilometerToSquareMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.386102158542)
    End Function

    Public Function SquareKilometerToAcres(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 247.105381467)
    End Function

    Public Function SquareCentimeterToSquareMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 10000)
    End Function

    Public Function SquareCentimeterToSquareKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 10000000000)
    End Function

    Public Function SquareCentimeterToSquareMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 100)
    End Function

    Public Function SquareCentimeterToSquareFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001076391042)
    End Function

    Public Function SquareCentimeterToSquareInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.155000310001)
    End Function

    Public Function SquareCentimeterToSquareYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 8361.2736)
    End Function

    Public Function SquareCentimeterToSquareMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 25899881103.4)
    End Function

    Public Function SquareCentimeterToAcres(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 40468564.224)
    End Function

    Public Function SquareMillimeterToSquareMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1000000)
    End Function

    Public Function SquareMillimeterToSquareKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1000000000000)
    End Function

    Public Function SquareMillimeterToSquareCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 100)
    End Function

    Public Function SquareMillimeterToSquareFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.00001076391)
    End Function

    Public Function SquareMillimeterToSquareInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0015500031)
    End Function

    Public Function SquareMillimeterToSquareYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 836127.36)
    End Function

    Public Function SquareMillimeterToSquareMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 2589988110340)
    End Function

    Public Function SquareMillimeterToAcres(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 4046856422.4)
    End Function

    Public Function SquareFeetToSquareMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.09290304)
    End Function

    Public Function SquareFeetToSquareKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 10763910.4167)
    End Function

    Public Function SquareFeetToSquareCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 929.0304)
    End Function

    Public Function SquareFeetToSquareMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 92903.04)
    End Function

    Public Function SquareFeetToSquareInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 144)
    End Function

    Public Function SquareFeetToSquareYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.111111111111)
    End Function

    Public Function SquareFeetToSquareMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 27878400)
    End Function

    Public Function SquareFeetToAcres(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 43560)
    End Function

    Public Function SquareInchToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1550.00310001)
    End Function

    Public Function SquareInchToKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1550003100.01)
    End Function

    Public Function SquareInchToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 6.4516)
    End Function

    Public Function SquareInchToMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 645.16)
    End Function

    Public Function SquareInchToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.006944444444)
    End Function

    Public Function SquareInchToYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1296)
    End Function

    Public Function SquareInchToMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 4014489600)
    End Function

    Public Function SquareInchToAcres(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 6272640)
    End Function

    Public Function SquareYardToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.83612736)
    End Function

    Public Function SquareYardToKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1195990.0463)
    End Function

    Public Function SquareYardToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 8361.2736)
    End Function

    Public Function SquareYardToMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 836127.36)
    End Function

    Public Function SquareYardToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 9)
    End Function

    Public Function SquareYardToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1296)
    End Function

    Public Function SquareYardToMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 3097600)
    End Function

    Public Function SquareYardToAcres(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 4840)
    End Function

    Public Function SquareMileToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2589988.11034)
    End Function

    Public Function SquareMileToKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2.58998811034)
    End Function

    Public Function SquareMileToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 25899881103.4)
    End Function

    Public Function SquareMileToMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2589988110340)
    End Function

    Public Function SquareMileToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 27878400)
    End Function

    Public Function SquareMileToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4014489600)
    End Function

    Public Function SquareMileToYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3097600)
    End Function

    Public Function SquareMileToAcres(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 640)
    End Function

    Public Function AcresToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4046.8564224)
    End Function

    Public Function AcresToKilometers(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.004046856422)
    End Function

    Public Function AcresToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 40468564.224)
    End Function

    Public Function AcresToMillimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4046856422.4)
    End Function

    Public Function AcresToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 43560)
    End Function

    Public Function AcresToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 6272640)
    End Function

    Public Function AcresToYards(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4840)
    End Function

    Public Function AcresToMiles(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0015625)
    End Function

    Public Function CubicMeterToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000000)
    End Function

    Public Function CubicMeterToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 35.3146667215)
    End Function

    Public Function CubicMeterToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 61023.7440947)
    End Function

    Public Function CubicMeterToLiters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000)
    End Function

    Public Function CubicMeterToGallons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 264.172052358)
    End Function

    Public Function CubicMeterToCups(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4226.75283773)
    End Function

    Public Function CubicMeterToTablespoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 67628.0454037)
    End Function

    Public Function CubicMeterToTeaspoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 202884.136211)
    End Function

    Public Function CubicCentimeterToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1000000)
    End Function

    Public Function CubicCentimeterToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 28316.846592)
    End Function

    Public Function CubicCentimeterToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.061023744095)
    End Function

    Public Function CubicCentimeterToLiters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001)
    End Function

    Public Function CubicCentimeterToGallons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 3785.411784)
    End Function

    Public Function CubicCentimeterToCups(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.004226752838)
    End Function

    Public Function CubicCentimeterToTablespoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.067628045404)
    End Function

    Public Function CubicCentimeterToTeaspoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.202884136211)
    End Function

    Public Function CubicFeetToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.028316846592)
    End Function

    Public Function CubicFeetToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 28316.846592)
    End Function

    Public Function CubicFeetToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1728)
    End Function

    Public Function CubicFeetToLiters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 28.316846592)
    End Function

    Public Function CubicFeetToGallons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 7.48051948052)
    End Function

    Public Function CubicFeetToCups(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 119.688311688)
    End Function

    Public Function CubicFeetToTablespoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1915.01298701)
    End Function

    Public Function CubicFeetToTeaspoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 5745.03896104)
    End Function

    Public Function CubicInchToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 61023.7440947)
    End Function

    Public Function CubicInchToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 16.387064)
    End Function

    Public Function CubicInchToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1728)
    End Function

    Public Function CubicInchToLiters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 61.0237440947)
    End Function

    Public Function CubicInchToGallons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 231)
    End Function

    Public Function CubicInchToCups(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.069264069264)
    End Function

    Public Function CubicInchToTablespoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.10822510823)
    End Function

    Public Function CubicInchToTeaspoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3.32467532468)
    End Function

    Public Function LiterToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001)
    End Function

    Public Function LiterToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000)
    End Function

    Public Function LiterToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.035314666721)
    End Function

    Public Function LiterToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 61.0237440947)
    End Function

    Public Function LiterToGallons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.264172052358)
    End Function

    Public Function LiterToCups(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4.22675283773)
    End Function

    Public Function LiterToTablespoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 67.6280454037)
    End Function

    Public Function LiterToTeaspoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 202.884136211)
    End Function

    Public Function GallonToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.003785411784)
    End Function

    Public Function GallonToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3785.411784)
    End Function

    Public Function GallonToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.133680555556)
    End Function

    Public Function GallonToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 231)
    End Function

    Public Function GallonToLiters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3.785411784)
    End Function

    Public Function GallonToCups(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 16)
    End Function

    Public Function GallonToTablespoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 256)
    End Function

    Public Function GallonToTeaspoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 768)
    End Function

    Public Function CupsToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 4226.75283773)
    End Function

    Public Function CupsToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 236.5882365)
    End Function

    Public Function CupsToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.008355034722)
    End Function

    Public Function CupsToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 14.4375)
    End Function

    Public Function CupsToLiters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.2365882365)
    End Function

    Public Function CupsToGallons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 16)
    End Function

    Public Function CupsToTablespoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 16)
    End Function

    Public Function CupsToTeaspoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 48)
    End Function

    Public Function TablespoonToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 67628.0454037)
    End Function

    Public Function TablespoonToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 14.7867647813)
    End Function

    Public Function TablespoonToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1915.01298701)
    End Function

    Public Function TablespoonToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.90234375)
    End Function

    Public Function TablespoonToLiters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 67.6280454037)
    End Function

    Public Function TablespoonToGallons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 256)
    End Function

    Public Function TablespoonToCups(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0625)
    End Function

    Public Function TablespoonToTeaspoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3)
    End Function

    Public Function TeaspoonToMeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 202884.136211)
    End Function

    Public Function TeaspoonToCentimeters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4.92892159375)
    End Function

    Public Function TeaspoonToFeet(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 5745.03896104)
    End Function

    Public Function TeaspoonToInches(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.30078125)
    End Function

    Public Function TeaspoonToLiters(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 202.884136211)
    End Function

    Public Function TeaspoonToGallons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 768)
    End Function

    Public Function TeaspoonToCups(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.020833333333)
    End Function

    Public Function TeaspoonToTablespoons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.333333333333)
    End Function

    Public Function DyneToNewtons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 100000)
    End Function

    Public Function DyneToPounds(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 4.448221615)
    End Function

    Public Function DyneToGramForce(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 980665)
    End Function

    Public Function DyneToTons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 889644323.052)
    End Function

    Public Function NewtonToDynes(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 100000)
    End Function

    Public Function NewtonToPounds(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.224808943)
    End Function

    Public Function NewtonToGramForce(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.101971621)
    End Function

    Public Function NewtonToTons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 8896.44323052)
    End Function

    Public Function PoundToDynes(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 444822.161526)
    End Function

    Public Function PoundToNewtons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4.448221615)
    End Function

    Public Function PoundToGramForce(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.45359237)
    End Function

    Public Function PoundToTons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 2000)
    End Function

    Public Function GramForceToDynes(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 980665)
    End Function

    Public Function GramForceToNewtons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 9.80665)
    End Function

    Public Function GramForceToPounds(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2.204622622)
    End Function

    Public Function GramForceToTons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001102311)
    End Function

    Public Function TonToDynes(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 889644323.052)
    End Function

    Public Function TonToNewtons(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 8896.44323052)
    End Function

    Public Function TonToPounds(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2000)
    End Function

    Public Function TonToGramForce(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 907.18474)
    End Function

    Public Function BTUPerHrToFtLbPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 778.169262266)
    End Function

    Public Function BTUPerHrToHorsepower(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.41485320412)
    End Function

    Public Function BTUPerHrToCalPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 251.995761111)
    End Function

    Public Function BTUPerHrToWatts(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1055.05585262)
    End Function

    Public Function FtLbPerSecToBTUPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001285067463)
    End Function

    Public Function FtLbPerSecToHorsepower(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001818181818)
    End Function

    Public Function FtLbPerSecToCalPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.323831553533)
    End Function

    Public Function FtLbPerSecToWatts(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.35581794833)
    End Function

    Public Function HorsepowerToBTUPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.706787104901)
    End Function

    Public Function HorsepowerToFtLbPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 550)
    End Function

    Public Function HorsepowerToCalPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 178.107354443)
    End Function

    Public Function HorsepowerToWatts(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 745.699871582)
    End Function

    Public Function CalPerSecToBTUPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.003968320719)
    End Function

    Public Function CalPerSecToFtLbPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3.08802520659)
    End Function

    Public Function CalPerSecToHorsepower(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.005614591285)
    End Function

    Public Function CalPerSecToWatts(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4.1868)
    End Function

    Public Function WattsToBTUPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0094781720313)
    End Function

    Public Function WattsToFtLbPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.737562149277)
    End Function

    Public Function WattsToHorsepower(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.00134102209)
    End Function

    Public Function WattsToCalPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.238845896628)
    End Function

    Public Function BTUToFtLb(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 778.169262266)
    End Function

    Public Function BTUToHorsepowerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 2545)
    End Function

    Public Function BTUToJoule(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1055.05585262)
    End Function

    Public Function BTUToCalorie(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 251.995761111)
    End Function

    Public Function BTUToKilowattHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 3412.14163313)
    End Function

    Public Function FtLbToBTU(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001285067463)
    End Function

    Public Function FtLbToHorsepowerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0000005051)
    End Function

    Public Function FtLbToJoule(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.35581794833)
    End Function

    Public Function FtLbToCalorie(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.323831553533)
    End Function

    Public Function FtLbToKilowattHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 2655223.7374)
    End Function

    Public Function HorsepowerHrToBTU(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2545)
    End Function

    Public Function HorsepowerHrToFtLb(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1980000)
    End Function

    Public Function HorsepowerHrToJoule(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2685000)
    End Function

    Public Function HorsepowerHrToCalorie(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 641300)
    End Function

    Public Function HorsepowerHrToKilowattHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.7457)
    End Function

    Public Function JouleToBTU(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 1055.05585262)
    End Function

    Public Function JouleToFtLb(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.737562149277)
    End Function

    Public Function JouleToHorsepowerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 2685000)
    End Function

    Public Function JouleToCalorie(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.238845896628)
    End Function

    Public Function JouleToKilowattHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 3600000)
    End Function

    Public Function CalorieToBTU(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.003968320719)
    End Function

    Public Function CalorieToFtLb(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3.08802520659)
    End Function

    Public Function CalorieToHorsepowerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 641300)
    End Function

    Public Function CalorieToJoule(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4.1868)
    End Function

    Public Function CalorieToKilowattHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 859845.227859)
    End Function

    Public Function KilowattHrToBTU(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3412.14163313)
    End Function

    Public Function KilowattHrToFtLb(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2655223.7374)
    End Function

    Public Function KilowattHrToHorsepowerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.341)
    End Function

    Public Function KilowattHrToJoule(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3600000)
    End Function

    Public Function KilowattHrToCalorie(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 859845.227859)
    End Function

    Public Function AtmToMmHg(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 760)
    End Function

    Public Function AtmToPascal(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 101300)
    End Function

    Public Function AtmToPSI(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 14.6959487755)
    End Function

    Public Function AtmToPSF(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2116)
    End Function

    Public Function AtmToDynePerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1013000)
    End Function

    Public Function AtmToBar(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.01325)
    End Function

    Public Function MmHgToAtm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001315789474)
    End Function

    Public Function MmHgToPascal(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 133.3)
    End Function

    Public Function MmHgToPSI(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.019336774705)
    End Function

    Public Function MmHgToPSF(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2.785)
    End Function

    Public Function MmHgToDynePerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1333)
    End Function

    Public Function MmHgToBar(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001333223684)
    End Function

    Public Function PascalToAtm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.000009869)
    End Function

    Public Function PascalToMmHg(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 133.3)
    End Function

    Public Function PascalToPSI(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.000145)
    End Function

    Public Function PascalToPSF(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.02089)
    End Function

    Public Function PascalToDynePerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 10)
    End Function

    Public Function PascalToBar(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 100000)
    End Function

    Public Function PSIToAtm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.06804596391)
    End Function

    Public Function PSIToMmHg(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 51.7149325715)
    End Function

    Public Function PSIToPascal(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 6895)
    End Function

    Public Function PSIToPSF(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 144)
    End Function

    Public Function PSIToDynePerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 68950)
    End Function

    Public Function PSIToBar(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.068947572932)
    End Function

    Public Function PSFToAtm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.004725)
    End Function

    Public Function PSFToMmHg(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.3591)
    End Function

    Public Function PSFToPascal(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 47.88020833333)
    End Function

    Public Function PSFToPSI(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.006944444444)
    End Function

    Public Function PSFToDynePerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 478.8020833)
    End Function

    Public Function PSFToBar(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.000478802083)
    End Function

    Public Function DynePerCmToAtm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0000009869)
    End Function

    Public Function DynePerCmToMmHg(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0007501)
    End Function

    Public Function DynePerCmToPascal(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.1)
    End Function

    Public Function DynePerCmToPSI(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.00001405)
    End Function

    Public Function DynePerCmToPSF(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.002089)
    End Function

    Public Function DynePerCmToBar(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.0000009869) * 1.01325)
    End Function

    Public Function BarToAtm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.986923266716)
    End Function

    Public Function BarToMmHg(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 750.061682704)
    End Function

    Public Function BarToPascal(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.986923266716) * 101300)
    End Function

    Public Function BarToPSI(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 14.503773773)
    End Function

    Public Function BarToPSF(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.986923266716) * 2116)
    End Function

    Public Function BarToDynePerCm(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 0.986923266716) * 1013000)
    End Function

    Public Function FtLbToInLb(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 12)
    End Function

    Public Function FtLbToNm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.3048 * 4.448221615)
    End Function

    Public Function InLbToFtLb(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 12)
    End Function

    Public Function InLbToNm(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 12) * 0.3048 * 4.448221615)
    End Function

    Public Function NmToFtLb(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (0.3048 * 4.448221615))
    End Function

    Public Function NmToInLb(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / (0.3048 * 4.448221615)) * 12)
    End Function

    Public Function GramToKilogram(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001)
    End Function

    Public Function GramToSlug(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 14593.9029372)
    End Function

    Public Function GramToOunce(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.03527)
    End Function

    Public Function GramToPound(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 453.59237)
    End Function

    Public Function KilogramToGram(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000)
    End Function

    Public Function KilogramToSlug(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.068521765857)
    End Function

    Public Function KilogramToOunce(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 35.27)
    End Function

    Public Function KilogramToPound(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2.20462262185)
    End Function

    Public Function SlugToGram(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 14593.9029372)
    End Function

    Public Function SlugToKilogram(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 14.5939029372)
    End Function

    Public Function SlugToOunce(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 514.8)
    End Function

    Public Function SlugToPound(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 32.1740485564)
    End Function

    Public Function OunceToGram(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 28.35)
    End Function

    Public Function OunceToKilogram(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.02835)
    End Function

    Public Function OunceToSlug(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001943)
    End Function

    Public Function OunceToPound(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0625)
    End Function

    Public Function PoundToGram(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 453.59237)
    End Function

    Public Function PoundToKilogram(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.45359237)
    End Function

    Public Function PoundToSlug(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.031080950172)
    End Function

    Public Function PoundToOunce(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 16)
    End Function

    Public Function GramPerCubicCmToKgPerM(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1000)
    End Function

    Public Function GramPerCubicCmToSlugPerFt(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.94)
    End Function

    Public Function GramPerCubicCmToLbPerFt(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 62.43)
    End Function

    Public Function GramPerCubicCmToLbPerIn(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.03613)
    End Function

    Public Function KilogramPerCubicMToGramPerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.001)
    End Function

    Public Function KilogramPerCubicMToSlugPerFt(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.00194)
    End Function

    Public Function KilogramPerCubicMToLbPerFt(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.06243)
    End Function

    Public Function KilogramPerCubicMToLbPerIn(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.00003613)
    End Function

    Public Function SlugPerCubicFootToGramPerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.5154)
    End Function

    Public Function SlugPerCubicFootToKgPerM(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 515.4)
    End Function

    Public Function SlugPerCubicFootToLbPerFt(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 32.17)
    End Function

    Public Function SlugPerCubicFootToLbPerIn(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.01862)
    End Function

    Public Function PoundPerCubicFootToGramPerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.1602)
    End Function

    Public Function PoundPerCubicFootToKgPerM(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 16.02)
    End Function

    Public Function PoundPerCubicFootToSlugPerFt(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.03108)
    End Function

    Public Function PoundPerCubicFootToLbPerIn(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0005787)
    End Function

    Public Function PoundPerCubicInchToGramPerCm(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 27.68)
    End Function

    Public Function PoundPerCubicInchToKgPerM(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 27680)
    End Function

    Public Function PoundPerCubicInchToSlugPerFt(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 53.71)
    End Function

    Public Function PoundPerCubicInchToLbPerFt(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1728)
    End Function

    Public Function FeetPerSecToKmPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.09728)
    End Function

    Public Function FeetPerSecToMeterPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.3048)
    End Function

    Public Function FeetPerSecToMilPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.68181818181818177)
    End Function

    Public Function FeetPerSecToKnots(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.592483801296)
    End Function

    Public Function KilometerPerHrToFtPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.911344415281)
    End Function

    Public Function KilometerPerHrToMeterPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.277777777778)
    End Function

    Public Function KilometerPerHrToMilPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.621371192237)
    End Function

    Public Function KilometerPerHrToKnots(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.539956803456)
    End Function

    Public Function MetersPerSecToFtPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3.28083989501)
    End Function

    Public Function MetersPerSecToKmPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3.6)
    End Function

    Public Function MetersPerSecToMilPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 2.23693629205)
    End Function

    Public Function MetersPerSecToKnots(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.94384449244)
    End Function

    Public Function MilesPerHrToFtPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.466666666667)
    End Function

    Public Function MilesPerHrToKmPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.609344)
    End Function

    Public Function MilesPerHrToMetersPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.44704)
    End Function

    Public Function MilesPerHrToKnot(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.868976241901)
    End Function

    Public Function KnotsToFtPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.6878098571)
    End Function

    Public Function KnotsToKmPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.852)
    End Function

    Public Function KnotsToMetersPerSec(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.514444444444)
    End Function

    Public Function KnotsToMilPerHr(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 1.15077944802)
    End Function

    Public Function DegreeToMinute(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 60)
    End Function

    Public Function DegreeToSecond(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3600)
    End Function

    Public Function DegreeToRadian(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * (PI / 180))
    End Function

    Public Function DegreeToRevolution(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 360)
    End Function

    Public Function AngleMinuteToDegree(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 60)
    End Function

    Public Function AngleMinuteToSecond(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 60)
    End Function

    Public Function AngleMinuteToRadian(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.0002909)
    End Function

    Public Function AngleMinuteToRevolution(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 60) / 360)
    End Function

    Public Function AngleSecondToDegree(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 3600)
    End Function

    Public Function AngleSecondToMinute(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 60)
    End Function

    Public Function AngleSecondToRadian(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.000004848)
    End Function

    Public Function AngleSecondToRevolution(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber / 3600) / 360)
    End Function

    Public Function RadianToDegree(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * (180 / PI))
    End Function

    Public Function RadianToMinute(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3438)
    End Function

    Public Function RadianToSecond(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 206300)
    End Function

    Public Function RadianToRevolution(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 0.1592)
    End Function

    Public Function RevolutionToDegree(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 360)
    End Function

    Public Function RevolutionToMinute(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 360) * 60)
    End Function

    Public Function RevolutionToSecond(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 360) * 3600)
    End Function

    Public Function RevolutionToRadian(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 6.283)
    End Function

    Public Function YearToMonth(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 12)
    End Function

    Public Function YearToWeek(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 52.177)
    End Function

    Public Function YearToDay(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 365.242)
    End Function

    Public Function YearToHour(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 365.242) * 24)
    End Function

    Public Function YearToMinute(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 52.177) * (24 * 60))
    End Function

    Public Function YearToSecond(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 52.177) * (24 * 60 * 60))
    End Function

    Public Function MonthToYear(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 12)
    End Function

    Public Function MonthToWeek(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 4.36)
    End Function

    Public Function MonthToDay(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 30.5)
    End Function

    Public Function MonthToHour(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 30.5) * 24)
    End Function

    Public Function MonthToMinute(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 30.5) * (24 * 60))
    End Function

    Public Function MonthToSecond(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 30.5) * (24 * 60 * 60))
    End Function

    Public Function WeekToYear(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 52.177)
    End Function

    Public Function WeekToMonth(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 4.36)
    End Function

    Public Function WeekToDay(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 7)
    End Function

    Public Function WeekToHour(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * (7 * 24))
    End Function

    Public Function WeekToMinute(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * (7 * 24 * 60))
    End Function

    Public Function WeekToSecond(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * (7 * 24 * 60 * 60))
    End Function

    Public Function DayToYear(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 365.242)
    End Function

    Public Function DayToMonth(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 30.5)
    End Function

    Public Function DayToWeek(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 7)
    End Function

    Public Function DayToHour(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 24)
    End Function

    Public Function DayToMinute(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * (24 * 60))
    End Function

    Public Function DayToSecond(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * (24 * 60 * 60))
    End Function

    Public Function HourToYear(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (365.242 * 24))
    End Function

    Public Function HourToMonth(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (30.5 * 24))
    End Function

    Public Function HourToWeek(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (7 * 24))
    End Function

    Public Function HourToDay(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 24)
    End Function

    Public Function HourToMinute(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 60)
    End Function

    Public Function HourToSecond(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 3600)
    End Function

    Public Function MinuteToYear(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (365.242 * 24 * 60))
    End Function

    Public Function MinuteToMonth(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (30.5 * 24 * 60))
    End Function

    Public Function MinuteToWeek(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (7 * 24 * 60))
    End Function

    Public Function MinuteToDay(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (24 * 60))
    End Function

    Public Function MinuteToHour(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 60)
    End Function

    Public Function MinuteToSecond(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber * 60)
    End Function

    Public Function SecondToYear(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (365.242 * 24 * 60 * 60))
    End Function

    Public Function SecondToMonth(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (30.5 * 24 * 60 * 60))
    End Function

    Public Function SecondToWeek(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (7 * 24 * 60 * 60))
    End Function

    Public Function SecondToDay(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / (24 * 60 * 60))
    End Function

    Public Function SecondToHour(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 3600)
    End Function

    Public Function SecondToMinute(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber / 60)
    End Function

    Public Function DegreeFToDegreeC(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber - 32) / 1.8)
    End Function

    Public Function DegreeFToDegreeK(ByVal ConversionNumber As Double) As Double
        Return (((ConversionNumber - 32) / 1.8) + 273.15)
    End Function

    Public Function DegreeCToDegreeF(ByVal ConversionNumber As Double) As Double
        Return ((ConversionNumber * 1.8) + 32)
    End Function

    Public Function DegreeCToDegreeK(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber + 273.15)
    End Function

    Public Function DegreeKToDegreeF(ByVal ConversionNumber As Double) As Double
        Return (((ConversionNumber - 273.15) * 1.8) + 32)
    End Function

    Public Function DegreeKToDegreeC(ByVal ConversionNumber As Double) As Double
        Return (ConversionNumber - 273.15)
    End Function

End Module
