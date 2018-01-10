// Learn more about F# at http://fsharp.org

open System
open Prudential.Calendar
open Prudential.Calendar.Date

[<EntryPoint>]
let main argv =
    let month = PrudentialMonth.create 9
    let year = PrudentialYear.create 1980
    let date = { CalendarRecord.Years = year.Value; CalendarRecord.Months = month.Value }
    printfn "Years:'%i', Months:'%i'" (PrudentialYear.value date.Years) (PrudentialMonth.value date.Months)
    let newDate = date + (PrudentialMonth.create 11).Value
    
    printfn "new Years:'%i', Months:'%i'" (PrudentialYear.value newDate.Years) (PrudentialMonth.value newDate.Months)
    Console.ReadKey()
    0 // return an integer exit code
