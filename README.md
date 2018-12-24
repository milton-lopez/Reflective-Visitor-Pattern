# Reflective-Visitor-Pattern
An implementation of the Visitor design pattern using reflection.

This pattern was described in [Reflective Visitor Pattern](https://hillside.net/europlop/HillsideEurope/Papers/EuroPLoP2001/2001_MaiEtAl_ReflectiveVisitorPattern.pdf) by Yun Mai and Michel de Champlain 

## Intent
Define a new operation over the object structure without changing the classes of the
elements on which it operates, while in the meantime, allow the element classes in the
object structure to be extended constantly without changing the existing system.

![Reflective_Visitor](https://raw.githubusercontent.com/milton-lopez/Reflective-Visitor-Pattern/master/Diagram/Class%20Model.png "Reflective Visitor")

## Pros
* Cyclic dependencies are broken.
* No accept-methods.

## Cons
* Slower code due to reflection mechanism.
* Not statically safe.

## Applicability
Use the Reflective Visitor pattern when:

* The object structure may be changed often.
* Performance is not a major concern.
* You want/need to break the cyclic dependencies and decouple the object structure and the Visitor hierarchy.
