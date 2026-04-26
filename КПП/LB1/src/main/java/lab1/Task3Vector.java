package lab1;

import java.util.Scanner;

public class Task3Vector {
    public static void run() {
        Scanner scan = new Scanner(System.in);
        double x, y, z;

        while (true) {
            System.out.print("Enter x: ");
            if (scan.hasNextDouble()) { x = scan.nextDouble(); break; }
            System.out.println("Error: enter a real number.");
            scan.next();
        }
        while (true) {
            System.out.print("Enter y: ");
            if (scan.hasNextDouble()) { y = scan.nextDouble(); break; }
            System.out.println("Error: enter a real number.");
            scan.next();
        }
        while (true) {
            System.out.print("Enter z: ");
            if (scan.hasNextDouble()) { z = scan.nextDouble(); break; }
            System.out.println("Error: enter a real number.");
            scan.next();
        }

        double length = Math.sqrt(x * x + y * y + z * z);
        System.out.printf("Vector length = sqrt(%.4f^2 + %.4f^2 + %.4f^2) = %.4f%n",
                x, y, z, length);
    }
}
