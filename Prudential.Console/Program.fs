// Learn more about F# at http://fsharp.org

open System
open Prudential.Calendar
open Prudential.Calendar.Date

[<EntryPoint>]
let main argv =
    let month = PrudentialMonth.create 9
    let year = PrudentialYear.create 1980
    let date = { CalendarRecord.Years = year.Value; CalendarRecord.Months = month.Value }
    printfn "Years: '%i', Months: '%i'" (PrudentialYear.value date.Years) (PrudentialMonth.value date.Months)
    let newDate = date + (PrudentialMonth.create 11).Value    
    printfn "Years: '1980', Months: '9' + Months: '11' = Months: '%i', Years: '%i'" (PrudentialMonth.value newDate.Months) (PrudentialYear.value newDate.Years) 
    Console.ReadKey()
    0 
