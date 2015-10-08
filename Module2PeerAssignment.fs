open System

// Moduke 2 KOAN assignment.

/// Parse age nd return Some(int) or None if parse failed.
let parseInt (str: string) =
    let mutable intvalue = 0
    // Some/None is a F# alternative to Nullable (not really, but close).
    // TryParse returns TRUE/FALSE if string could be parsed as Int and parsed int as ref (need mutable).
    if System.Int32.TryParse(str, &intvalue) then Some(intvalue)
    else None

/// Get explanation based on age.
let getText (age:int) = 
    if age >= 20 then "no longer a teenager"
    elif age <=20 && age > 13 then "is a teenager"
    elif age <= 13 then "is a child"
    else "Age is strange."

[<EntryPoint>]
let main argv = 
    printfn "%s" "Enter nr of people:"
    let nrStr = Console.ReadLine()
    let nr = parseInt nrStr

    // Check if nr of people is Int and exit if not.
    if nr.IsNone then 
        printfn "%s" "Nr of elements is not a number."
        // ERROR_INVALID_DATA, 13 (0xD), The data is invalid.
        Environment.Exit(13)
    
    // Loop input.
    for i = 1 to nr.Value do
        printfn "%s" "Enter name:"
        let nameStr = Console.ReadLine()
        if String.IsNullOrWhiteSpace(nameStr) then
            printfn "%s" "Nr of elements is not a number."
            Environment.Exit(13)

        printfn "%s" "Enter age:"
        let ageStr = Console.ReadLine()
        let age = parseInt ageStr

        // Check if age is a Int.
        if age.IsSome then
            let state = getText age.Value
            printfn "Name: %s, age: %d, status: %s." nameStr age.Value state
        else
            printfn "%s" "Age is not a number."
            Environment.Exit(13)

    0 // return an integer exit code
