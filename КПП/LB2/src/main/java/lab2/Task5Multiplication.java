package lab2;

import java.util.Scanner;

public class Task5Multiplication {

    public static void run() {
        Scanner scanner = new Scanner(System.in);
        int n;

        System.out.print("Enter n: ");
        while (!scanner.hasNextInt()) {
            System.out.println("Error: enter integer value.");
            scanner.next();
        }
        n = scanner.nextInt();

        System.out.println("Multiplication table for " + n + ":");
        for (int i = 1; i <= 10; i++) {
            System.out.println(n + " * " + i + " = " + (n * i));
        }
    }
}