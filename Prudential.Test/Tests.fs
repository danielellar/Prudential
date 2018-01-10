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
        Assert.AreEqual(PrudentialYear.value date.Years, 1980)
        Assert.AreEqual(PrudentialMonth.value date.Months, 9)

    [<TestMethod>]
    member this.CanAddMonths () =
        let month = PrudentialMonth.create 9
        let year = PrudentialYear.create 1980
        let date = { CalendarRecord.Years = year.Value; CalendarRecord.Months = month.Value }

        let newDate = date + (PrudentialMonth.create 11).Value    
        
        Assert.AreEqual(PrudentialYear.value newDate.Years, 1981)
        Assert.AreEqual(PrudentialMonth.value newDate.Months, 8)
    
    [<TestMethod>]
    member this.CanSubtractMonths () = 
        let month = PrudentialMonth.create 8
        let year = PrudentialYear.create 1981
        let date = { CalendarRecord.Years = year.Value; CalendarRecord.Months = month.Value }

        let newDate = date - (PrudentialMonth.create 11).Value   

        Assert.AreEqual(PrudentialYear.value newDate.Years, 1980)
        Assert.AreEqual(PrudentialMonth.value newDate.Months, 9)