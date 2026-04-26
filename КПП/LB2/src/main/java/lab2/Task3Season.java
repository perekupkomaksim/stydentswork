package lab2;

import java.util.Scanner;

public class Task3Season {

    public static void run() {
        Scanner scanner = new Scanner(System.in);
        int month;

        System.out.print("Enter month number (1-12): ");
        while (!scanner.hasNextInt()) {
            System.out.println("Error: enter integer value.");
            scanner.next();
        }
        month = scanner.nextInt();

        switch (month) {
            case 12, 1, 2 -> System.out.println("Winter");
            case 3, 4, 5  -> System.out.println("Spring");
            case 6, 7, 8  -> System.out.println("Summer");
            case 9, 10, 11 -> System.out.println("Autumn");
            default -> System.out.println("Error: invalid month number.");
        }
    }
}