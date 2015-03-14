/*
 * Code in "CLR via C#" book
 */

using System;

// This type is implicitly derived from System.Object.
internal class Employee {

}

internal class Manager : Employee {

}

public static class Program {
   public static void Main() {
      // No cast needed since new returns an Employee object
      // and Object is a base type of Employee.
      Object o = new Employee();

      // Cast required since Employee is derived from Object.
      // Other languages (such as Visual Basic) might not require 
      // this cast to compile.
      Employee e = (Employee) o;
   }

   public static void Main2() {
      // Construct a Manager object and pass it to PromoteEmployee.
      // A Manager IS-A Object: PromoteEmployee runs OK.
      Manager m = new Manager();
      PromoteEmployee(m);

      // Construct a DateTime object and pass it to PromoteEmployee.
      // A DateTime is NOT derived from Employee. PromoteEmployee 
      // throws a System.InvalidCastException exception. 
      DateTime newYears = new DateTime(2007, 1, 1);
      PromoteEmployee(newYears);
   }


   public static void PromoteEmployee(Object o) {
      // At this point, the compiler doesn’t know exactly what
      // type of object o refers to. So the compiler allows the 
      // code to compile. However, at run time, the CLR does know 
      // what type o refers to (each time the cast is performed) and
      // it checks whether the object’s type is Employee or any type
      // that is derived from Employee.
      Employee e = (Employee) o;
   }

   public static void PromoteEmployee2(Object o) {
      if (o is Employee) {
         Employee e = (Employee)o;
         // Use e within the remainder of the 'if' statement. 
      }
   }
   public static void PromoteEmployee3(Object o) {
      Employee e = o as Employee;
      if (e != null) {
         // Use e within the 'if' statement.
      }
   }
}
