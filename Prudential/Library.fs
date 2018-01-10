namespace Prudential.Calendar

module PrudentialYear =
    type Years = Years of int

    let create value = 
        let min = 0
        let max = 2038
        if value < min || value > max
        then None
        else Some (Years value)
        
    let value (Years e) = e

module PrudentialMonth =
    type Months = Months of int

    let create value = 
        let min = 1
        let max = 12
        if value < min || value > max
        then None
        else Some (Months value)

    let value (Months e) = e

module Round = 
    let month (date : System.DateTime) =
        if date.Month = 12 then 
            date
        else
            let daysInMonth = 
                match date.Month with
                    | 2 -> 28 // Sorry, no leap year handling
                    | 4 | 6 | 9 | 11 -> 30
                    | _ -> 31
            let midway = daysInMonth / 2
            let result = if date.Day < midway then date else date.AddMonths(1)
            result

module Date =
    type CalendarRecord = { Years : PrudentialYear.Years; Months : PrudentialMonth.Months } with
        static member (+) (x : CalendarRecord, y : PrudentialMonth.Months) =
            let monthsSum = PrudentialMonth.value x.Months + PrudentialMonth.value y
            let months = monthsSum % 12
            let years = PrudentialYear.value x.Years + (if monthsSum >= 12 then 1 else 0)
            let resultMonths = PrudentialMonth.create months
            let resultYears = PrudentialYear.create years
            
            if resultMonths.IsNone then raise (System.ArgumentException("Value given for month is invalid"))
            if resultYears.IsNone then raise (System.ArgumentException("Value given for year is invalid"))
            { Years = resultYears.Value; Months = resultMonths.Value } 

        static member (-) (x : CalendarRecord, y : PrudentialMonth.Months) =
            let months = PrudentialMonth.value x.Months - PrudentialMonth.value y
            let isMonthsNegative = months < 0
            let years = PrudentialYear.value x.Years - (if isMonthsNegative then 1 else 0)
            let resultMonths = PrudentialMonth.create (months + (if isMonthsNegative then 12 else 0))
            let resultYears = PrudentialYear.create years
            
            if resultMonths.IsNone then raise (System.ArgumentException("Value given for month is invalid"))
            if resultYears.IsNone then raise (System.ArgumentException("Value given for year is invalid"))
            { Years = resultYears.Value; Months = resultMonths.Value } 

        static member (+) (x : CalendarRecord, y : CalendarRecord) =
            let monthsSum = PrudentialMonth.value x.Months + PrudentialMonth.value y.Months
            let months = monthsSum % 12
            let years = PrudentialYear.value x.Years + PrudentialYear.value y.Years + (if monthsSum >= 12 then 1 else 0)
            let resultMonths = PrudentialMonth.create months
            let resultYears = PrudentialYear.create years
            
            if resultMonths.IsNone then raise (System.ArgumentException("Value given for month is invalid"))
            if resultYears.IsNone then raise (System.ArgumentException("Value given for year is invalid"))
            { Years = resultYears.Value; Months = resultMonths.Value } 

        static member (-) (x : CalendarRecord, y : CalendarRecord) =
            let months = PrudentialMonth.value x.Months - PrudentialMonth.value y.Months
            let isMonthsNegative = months < 0
            let years = PrudentialYear.value x.Years - PrudentialYear.value y.Years - (if isMonthsNegative then 1 else 0)
            let resultMonths = PrudentialMonth.create (months + (if isMonthsNegative then 12 else 0))
            let resultYears = PrudentialYear.create years
            
            if resultMonths.IsNone then raise (System.ArgumentException("Value given for month is invalid"))
            if resultYears.IsNone then raise (System.ArgumentException("Value given for year is invalid"))
            { Years = resultYears.Value; Months = resultMonths.Value } 
    
    let create date =
        let roundedDate = Round.month date
        let month = PrudentialMonth.create roundedDate.Month
        if month.IsNone then raise (System.ArgumentException("Value given for month is invalid"))                
        let year = PrudentialYear.create roundedDate.Year
        if year.IsNone then raise (System.ArgumentException("Value given for year is invalid"))
        { CalendarRecord.Years = year.Value; CalendarRecord.Months = month.Value  }

