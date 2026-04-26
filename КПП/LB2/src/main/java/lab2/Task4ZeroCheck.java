package lab2;

import java.util.Scanner;

public class Task4ZeroCheck {

    public static void run() {
        Scanner scanner = new Scanner(System.in);
        int n;

        System.out.print("Enter integer number: ");
        while (!scanner.hasNextInt()) {
            System.out.println("Error: enter integer value.");
            scanner.next();
        }
        n = scanner.nextInt();

        String result = (n == 0) ? "zero" : "non-zero";
        System.out.println("Number " + n + " is " + result);
    }
}