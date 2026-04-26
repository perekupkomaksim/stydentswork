package lab2;

import java.util.Scanner;

public class Task2EqualCheck {

    public static void run() {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter first number (a): ");
        int a = readInt(scanner);

        System.out.print("Enter second number (b): ");
        int b = readInt(scanner);

        if (a == b) {
            System.out.println("Numbers are equal: " + a + " == " + b);
        } else {
            System.out.println("Numbers are NOT equal: " + a + " != " + b);
        }
    }

    private static int readInt(Scanner scanner) {
        while (!scanner.hasNextInt()) {
            System.out.println("Error: enter integer value.");
            scanner.next();
        }
        return scanner.nextInt();
    }
}