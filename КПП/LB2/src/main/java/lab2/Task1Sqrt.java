package lab2;

import java.util.Scanner;

public class Task1Sqrt {

    public static void run() {
        Scanner scanner = new Scanner(System.in);
        double x;

        System.out.print("Enter x: ");
        while (!scanner.hasNextDouble()) {
            System.out.println("Error: enter real number.");
            scanner.next();
        }
        x = scanner.nextDouble();

        if (x > 1) {
            double y = Math.sqrt(x);
            System.out.println("y = sqrt(" + x + ") = " + y);
        } else {
            System.out.println("Condition x > 1 is not satisfied. x = " + x);
        }
    }
}