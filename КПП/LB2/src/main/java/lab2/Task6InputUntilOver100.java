package lab2;

import java.util.Scanner;

public class Task6InputUntilOver100 {

    public static void run() {
        Scanner scanner = new Scanner(System.in);
        int value;

        System.out.println("Enter numbers (number > 100 to stop):");

        do {
            while (!scanner.hasNextInt()) {
                System.out.println("Error: enter integer value.");
                scanner.next();
            }
            value = scanner.nextInt();

            if (value > 100) {
                System.out.println("You entered " + value + " (> 100). Stopping.");
                break;
            }

            System.out.println("You entered: " + value);
        } while (true);

        System.out.println("Input finished.");
    }
}