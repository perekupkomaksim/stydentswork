package lab1;

import java.util.Scanner;

public class Task4Power {
    public static void run() {
        Scanner scan = new Scanner(System.in);
        double a;

        while (true) {
            System.out.print("Enter a: ");
            if (scan.hasNextDouble()) { a = scan.nextDouble(); break; }
            System.out.println("Error: enter a real number.");
            scan.next();
        }

        double a2 = a * a;
        double a3 = a2 * a;
        double a6 = a3 * a3;

        System.out.println("a^6 = " + a6);
    }
}
