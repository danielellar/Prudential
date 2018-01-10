namespace Prudential.Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Prudential.Calendar
open Prudential.Calendar.Date

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.CanCreateDates () =
        let month = PrudentialMonth.create 9
        let year = PrudentialYear.create 1980
        let date = { CalendarRecord.Years = year.Value; CalendarRecord.Months = month.Value }
        Assert.AreEqual(1980, PrudentialYear.value date.Years)
        Assert.AreEqual(9, PrudentialMonth.value date.Months)

    [<TestMethod>]
    member this.CanAddMonths () =
        let month = PrudentialMonth.create 9
        let year = PrudentialYear.create 1980
        let date = { CalendarRecord.Years = year.Value; CalendarRecord.Months = month.Value }

        let newDate = date + (PrudentialMonth.create 11).Value    
        
        Assert.AreEqual(1981, PrudentialYear.value newDate.Years)
        Assert.AreEqual(8, PrudentialMonth.value newDate.Months)
    
    [<TestMethod>]
    member this.CanSubtractMonths () = 
        let month = PrudentialMonth.create 8
        let year = PrudentialYear.create 1981
        let date = { CalendarRecord.Years = year.Value; CalendarRecord.Months = month.Value }

        let newDate = date - (PrudentialMonth.create 11).Value   

        Assert.AreEqual(1980, PrudentialYear.value newDate.Years)
        Assert.AreEqual(9, PrudentialMonth.value newDate.Months)
        
    [<TestMethod>]
    member this.CanSubtractDates () = 
        let month1 = PrudentialMonth.create 6
        let year1 = PrudentialYear.create 100
        let date1 = { CalendarRecord.Years = year1.Value; CalendarRecord.Months = month1.Value }

        let month2 = PrudentialMonth.create 7
        let year2 = PrudentialYear.create 1
        let date2 = { CalendarRecord.Years = year2.Value; CalendarRecord.Months = month2.Value }

        let newDate = date1 - date2  

        Assert.AreEqual(98, PrudentialYear.value newDate.Years)
        Assert.AreEqual(11, PrudentialMonth.value newDate.Months)
        let x = new System.DateTime(100, 6, 1)
        let y = x.AddYears(-1).AddMonths(-7)
        Assert.AreEqual(98, y.Year)
        Assert.AreEqual(11, y.Month)

    [<TestMethod>]
    member this.CanAddDates () = 
        let month1 = PrudentialMonth.create 6
        let year1 = PrudentialYear.create 100
        let date1 = { CalendarRecord.Years = year1.Value; CalendarRecord.Months = month1.Value }

        let month2 = PrudentialMonth.create 7
        let year2 = PrudentialYear.create 1 
        let date2 = { CalendarRecord.Years = year2.Value; CalendarRecord.Months = month2.Value }

        let newDate = date1 + date2  

        Assert.AreEqual(102, PrudentialYear.value newDate.Years)
        Assert.AreEqual(1, PrudentialMonth.value newDate.Months)

    [<TestMethod>]
    member this.CanParseDates () = 
        let date = new System.DateTime(1999, 12, 31)
        let result = Prudential.Calendar.Date.create date
        Assert.AreEqual(1999, PrudentialYear.value result.Years)
        Assert.AreEqual(12, PrudentialMonth.value result.Months)

    [<TestMethod>]
    member this.CanRoundDates () = 
        let date = new System.DateTime(1999, 11, 30)
        let result = Prudential.Calendar.Date.create date
        Assert.AreEqual(1999, PrudentialYear.value result.Years)
        Assert.AreEqual(12, PrudentialMonth.value result.Months)

    [<TestMethod>]
    member this.CanRoundDecemberDates () = 
        let date = new System.DateTime(1999, 12, 31)
        let result = Prudential.Calendar.Date.create date
        Assert.AreEqual(1999, PrudentialYear.value result.Years)
        Assert.AreEqual(12, PrudentialMonth.value result.Months)