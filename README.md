# TossAnAppleToYourWitcher
Answers to https://stackoverflow.com/questions/60445306/how-to-enforce-this-one-to-many-constraint-in-c

Disclaimer: as stated by Gabriel C [in his answer][1], ideal design would be one which respects the Single Responsability Principle. The question though, if interpreted licterally, constraints to only 2 classes, which should contain all the business logic to handle apple boxing. Here my solution with this specific design.

Please note that Box.Apples property returns a clone of the underlaying array, preventing client code from breaking Apple-Box relationship by manipulating array elements. Apple.Box has private setter for same reason.


  [1]: https://stackoverflow.com/a/60446321/582792


