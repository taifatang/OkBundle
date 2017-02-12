# OkBundle

A simple condition block alternative, with fluent API for .NET 

  - Ideas by ZhongMingChen
  - Implemented by TaiFaTang
  
###If
`If` and `ElseIf` both takes a predicate e.g. `1+1, true || true`

The follow command are available `If`, `Do`, `ElseIf`, `Else`
```sh
Ok
	.If().Do(() => {} )
	.ElseIf().Do(() => {})
	.Else( () => {})
```
Example:
```sh
Ok
  .If(1 == 2).Do( () => { Console.WriteLine("HelloWorld!") } )
  .ElseIf(3 == 3).Do( () => { Console.WriteLine("FooBar!") } )
  .Else( () => { Console.WriteLine("I am not called :[ ") } )
```
###Switch
`Switch()` will take any object. `Case()` can be same or any other type

The follow command are available `Switch`, `Case`, `Do`
```sh
Ok
  .Switch()
  .Case().Do( () => {})
  .Case().Do( () => {})
```
Example: 
```sh
Ok
  .Switch(RandomEnum.Food)
  .Case(RandomEnum.Drink).Do( () => { Console.WriteLine("I am no executed :[ ") } )
  .Case(RandomEnum.Food).Do( () => { Console.WriteLine("I am executed!") } )
```
###While

Concept phase, Work in progress

`While()` will take any initialize: `int`, conditions: `IPredicate`, Action: `Action<T>`

The follow command are available `While`, `Do`
```sh
IPredicate conditions = new PredicateBuilder.Build(condition1, condition2, (c1, c2) => { c > c2})

Ok
  .While(conditions).Do(() => {})
```

###Foreach

`ForEach()` will take an IEnumerable, and a delegate

The follow command are available `ForEach`, 
```sh
Ok
  .ForEach(IEnumerable source, s => {})
```
Example: 
```sh
Ok
  .ForEach(products, p => { Console.WriteLine( p.ToString() ) } )
```

###For

Work in progress

`For()` will take any initialize: `int`, conditions: `IPredicate`, Action: `Action<T>`

The follow command are available `For`, `Do`
```sh
IPredicate conditions = new PredicateBuilder.Build(GreaterThan(10))

Ok
  .For(0, conditions, i => i++).Do(() => {})
```

Example: 
```sh
IPredicate conditions = new PredicateBuilder.Build(LessThan(10))

Ok
  .For(0, conditions, i => i++).Do(() => { Console.WriteLine("I am executed 9 times")})
```

###More & Improvment
####PredicateBuilder.Build()
####Ok.Break()
####Ok.Continue()
