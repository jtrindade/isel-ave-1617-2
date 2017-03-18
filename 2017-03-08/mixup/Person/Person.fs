namespace Data

type Person(firstName, lastName) = 
    member this.FirstName = firstName
    member this.LastName = lastName
    override this.ToString () = this.FirstName + " " + this.LastName


