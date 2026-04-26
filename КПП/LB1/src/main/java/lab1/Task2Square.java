package lab1;

import java.util.Scanner;

public class Task2Square {
    public static void run() {
        Scanner scan = new Scanner(System.in);
        double a;

        while (true) {
            System.out.print("Enter side a: ");
            if (scan.hasNextDouble()) {
                a = scan.nextDouble();
                if (a > 0) break;
                System.out.println("Error: side must be a positive number.");
            } else {
                System.out.println("Error: enter a real number.");
                scan.next();
            }
        }

        double area = a * a;
        System.out.printf("Square area = a^2 = %.4f^2 = %.4f%n", a, area);
    }
}
