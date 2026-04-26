package lab1;

import java.util.Scanner;

public class Task1Logarithm {
    public static void run() {
        Scanner scan = new Scanner(System.in);
        double x;

        while (true) {
            System.out.print("Enter x: ");
            if (scan.hasNextDouble()) {
                x = scan.nextDouble();
                if (x > -2) break;
                System.out.println("Error: x must be greater than -2 (x + 2 must be > 0).");
            } else {
                System.out.println("Error: enter a real number.");
                scan.next();
            }
        }

        double y = Math.log(x + 2);
        System.out.printf("y = ln(x + 2) = ln(%.4f) = %.4f%n", x + 2, y);
    }
}
