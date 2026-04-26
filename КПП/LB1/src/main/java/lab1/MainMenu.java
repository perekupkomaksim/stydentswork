package lab1;

import java.util.Scanner;

public class MainMenu {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int choice;

        do {
            System.out.println("\n===== LAB 1 : Variant 18 =====");
            System.out.println("1 - Task 1 (Logarithm: y = ln(x + 2))");
            System.out.println("2 - Task 2 (Square area)");
            System.out.println("3 - Task 3 (Vector length)");
            System.out.println("4 - Task 4 (Power a^6)");
            System.out.println("5 - Task 5 (Time conversion)");
            System.out.println("0 - Exit");
            System.out.print("Enter task number: ");

            while (!scan.hasNextInt()) {
                System.out.println("Error: enter an integer number.");
                scan.next();
            }
            choice = scan.nextInt();

            switch (choice) {
                case 1 -> Task1Logarithm.run();
                case 2 -> Task2Square.run();
                case 3 -> Task3Vector.run();
                case 4 -> Task4Power.run();
                case 5 -> Task5Time.run();
                case 0 -> System.out.println("Program finished.");
                default -> System.out.println("Error: unknown menu option.");
            }
        } while (choice != 0);

        scan.close();
    }
}
